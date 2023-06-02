using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DAO
{
    public class PersonaRepositorio
    {
        //private readonly ILogger _logger;
        private readonly ApplicationDbContext _context;
        //private readonly SPRepositorio _sp;

        public PersonaRepositorio(ApplicationDbContext context/*, SPRepositorio sp, ILogger logger*/)
        {
            _context = context;
            //_sp = sp;
            //_logger = logger;
        }
        public List<Persona> ObtenerLista()
        {
            List<Persona> Lista = new List<Persona>();

            Lista = _context.Personas.ToList();

            return Lista;
        }

        public List<EmpleadoVM> GetEmpleados()
        {
            List<EmpleadoVM> list = new List<EmpleadoVM>();

            list = _context.Empleados.Select(e => new EmpleadoVM
            {
                Id = e.Persona.Id,
                NumEmpleado = e.NumEmpleado.ToString(),
                Nombre = e.Persona.Nombre,
                Apellidos = e.Persona.Apellidos,
                CURP = e.Persona.CURP,
                FechaNacimiento = e.Persona.FechaNacimiento.ToString("yyyy-MM-dd"),
                Correo = e.Persona.Correo,
                Estado = e.Estado ? "Activo" : "Inactivo"
            })
        .ToList();

            return list;
        }

        public List<EmpleadosActivosVM> GetEmpleadosToInput()
        {
            List<EmpleadosActivosVM> list = new List<EmpleadosActivosVM>();

            list = _context.Empleados.Where(e => e.Estado == true).Select(e => new EmpleadosActivosVM
            {
                Id = e.Id,
                Nombre = $"{e.Persona.Nombre} {e.Persona.Apellidos}",
            })
                .ToList();
            return list;
        }

        public List<LoginPersona> GetEmpleado()
        {
            List<LoginPersona> loginPersona = new List<LoginPersona>();
            loginPersona = _context.Empleados.Select(e => new LoginPersona
            {
                Email = e.Persona.Correo,
                Password = e.Password
            }).ToList();
            return loginPersona;
        }

        public bool CreatePerson(CreatePersonRequest data)
        {
            bool isCreated = false;
            try
            {
                Persona persona = new Persona()
                {
                    Nombre = data.name,
                    Apellidos = data.lastname,
                    CURP = data.curp,
                    FechaNacimiento = Convert.ToDateTime(data.birthdate),
                    Correo = data.email
                };

                var personaSave = _context.Personas.Add(persona);


                Empleado empleado = new Empleado()
                {
                    NumEmpleado = data.numEmployee,
                    Persona = personaSave.Entity,
                    FechaIngreso = data.startDate,
                    Password = data.password,
                    Estado = data.status
                };

                _context.Empleados.Add(empleado);
                _context.SaveChanges();
                isCreated = true;
            }
            catch (Exception)
            {
                //_logger.LogError(e.Message);
            }
            return isCreated;
        }

        public bool UpdatePerson(UpdatePersonRequest data)
        {
            bool isUpdated = false;
            try
            {
                var persona = _context.Personas.Where(p => p.Id == data.id).FirstOrDefault();
                if (persona != null)
                {
                    persona.Nombre = data.name;
                    persona.Apellidos = data.lastname;
                    persona.CURP = data.curp;
                    persona.FechaNacimiento = Convert.ToDateTime(data.birthdate);
                    persona.Correo = data.email;

                    var empleado = _context.Empleados.Where(e => e.Persona.Id == data.id).FirstOrDefault();
                    if (empleado != null)
                    {
                        empleado.Estado = data.status;
                    }

                    _context.SaveChanges();

                    isUpdated = true;
                }
            }
            catch (Exception)
            {
                //_logger.LogError(e.Message);
            }
            return isUpdated;
        }

        public bool DeletePerson(int id)
        {
            bool isDeleted = false;
            try
            {
                var persona = _context.Personas.Where(p => p.Id == id).FirstOrDefault();
                if (persona != null)
                {
                    var empleado = _context.Empleados.Where(e => e.Persona.Id == id).FirstOrDefault();
                    if (empleado != null)
                    {
                        _context.Empleados.Remove(empleado);
                    }
                    _context.Personas.Remove(persona);
                    _context.SaveChanges();
                    isDeleted = true;
                }
            }
            catch (Exception)
            {
                //_logger.LogError(e.Message);
            }
            return isDeleted;
        }

        public List<EmpleadoRecordatorio> GetPersonasByDeadLineToday()
        {
            List<EmpleadoRecordatorio> list = new List<EmpleadoRecordatorio>();

            list = _context.Activos_Empleados.Where(list => list.FechaEntrega == DateTime.Now.Date).Select(list =>
            
                    new EmpleadoRecordatorio
                    {
                        Id = list.Empleado.Persona.Id,
                        Nombre = list.Empleado.Persona.Nombre,
                        Apellidos = list.Empleado.Persona.Apellidos,
                        Correo = list.Empleado.Persona.Correo,
                        Activo = list.Activo.Nombre,
                    }
            )
                .ToList();

            return list;
        }

        //    public async Task<List<T>> ReadCRUD<T>()
        //    {
        //        List<T> list = new List<T>();
        //        Dictionary<string, Object> parameters = new Dictionary<string, Object>()
        //{
        //    {"Action", "READ" }
        //};

        //        try
        //        {
        //            await _sp.ExecuteStoredProcedureAsync("sp_CRUD", parameters);
        //            list = _context.Set<T>().ToList();
        //        }
        //        catch (Exception e)
        //        {
        //            _logger.LogError(e.Message);
        //        }

        //        return list;
        //    }

    }
}
