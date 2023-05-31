using Domain.Entities;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DAO
{
    public class ActivoRepositorio
    {
        private readonly ApplicationDbContext _context;

        public ActivoRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ActivoVM> ObtenerLista()
        {
            List<ActivoVM> Lista = new List<ActivoVM>();

            Lista = _context.Activos.Select(x => new ActivoVM
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion,
                Estado = x.Estado ? "Disponible" : "Asignado"
            }).ToList();

            return Lista;
        }

        public List<ActivoEmpleadoVM> EmpleadoLista()
        {
              List<ActivoEmpleadoVM> Lista = new List<ActivoEmpleadoVM>();

            Lista = _context.Activos_Empleados.Select(x => new ActivoEmpleadoVM
            {
                Id = x.Empleado.Persona.Id,
                Label = x.Empleado.Persona.Nombre+ ' '  + x.Empleado.Persona.Apellidos,
                Empleado_Estado = x.Empleado.Estado,
                Activo_Id = x.Activo.Id,
                Activo_Nombre = x.Activo.Nombre,
                FechaAsignacion = x.FechaAsignacion.ToString("yyyy-MM-dd"),
                FechaEntrega = x.FechaEntrega.ToString("yyyy-MM-dd"),
                FechaLiberacion = x.FechaLiberacion
            }).ToList();

            return Lista;
        }

        public bool CrearActivo(ActivoRequest activo)
        {
            bool isCreated = false;

            try
            {
                Activo nuevoActivo = new()
                {
                    Nombre = activo.name,
                    Descripcion = activo.description,
                    Estado = activo.status ? true : false
                };

                _context.Activos.Add(nuevoActivo);
                _context.SaveChanges();

                isCreated = true;
            }
            catch (Exception)
            {
            }

            return isCreated;
        }

        public bool EditarActivo(UpdateActivoRequest activo)
        {
            try
            {
                // Encuentra el activo para editar.
                Activo activoEditado = _context.Activos.FirstOrDefault(x => x.Id == activo.id);
                if (activoEditado == null)
                    return false;

                // Actualiza los campos del activo editado.
                activoEditado.Nombre = activo.name;
                activoEditado.Descripcion = activo.description;
                activoEditado.Estado = activo.releaseDate != null;

                // Encuentra el activo asignable, si existe.
                Activo_Empleado activoAsignable = _context.Activos_Empleados.FirstOrDefault(x => x.Activo.Id == activo.id);

                if (activoAsignable != null)
                {
                    // Actualiza los campos del activo asignable.
                    activoAsignable.FechaAsignacion = activo.assignmentDate ?? DateTime.Now;
                    activoAsignable.FechaEntrega = activo.deadLine ?? DateTime.Now;
                    activoAsignable.FechaLiberacion = activo.releaseDate;
                    if (activo.releaseDate != null) _context.Activos_Empleados.Remove(activoAsignable);
                }
                else
                {
                    // Encuentra el empleado al que se le asignará el activo.
                    var empleado = _context.Empleados.FirstOrDefault(x => x.Id == activo.employeeId);
                    if (empleado == null) return false;

                    // Crea y asigna el nuevo activo al empleado.
                    Activo_Empleado nuevoActivoEmpleado = new()
                    {
                        Activo = activoEditado,
                        Empleado = empleado,
                        FechaAsignacion = activo.assignmentDate ?? DateTime.Now,
                        FechaEntrega = activo.releaseDate ?? DateTime.Now,
                        FechaLiberacion = activo.releaseDate
                    };
                    _context.Activos_Empleados.Add(nuevoActivoEmpleado);

                    // Actualiza el estado del activo editado.
                    activoEditado.Estado = false;
                }

                // Guarda los cambios.
                _context.SaveChanges();
            }
            catch (Exception)
            {
                // Algo salió mal, así que devuelve false.
                return false;
            }

            // Si todo salió bien, devuelve true.
            return true;
        }


    }
}
