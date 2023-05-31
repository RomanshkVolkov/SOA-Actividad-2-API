using Domain.Entities;
using Repository.Context;
using Repository.DAO;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ActivoServicio : IActivo
    {
        public readonly ActivoRepositorio activoRepositorio;

        public ActivoServicio(ApplicationDbContext context)
        {
            activoRepositorio = new ActivoRepositorio(context);
        }

        public List<ActivoVM> ObtenerLista()
        {
            List<ActivoVM> activos = new List<ActivoVM>();

            try
            {
                activos = activoRepositorio.ObtenerLista();
            }
            catch (Exception)
            {
            }

            return activos;
        }

        public bool CrearActivo(ActivoRequest activo)
        {
            bool isCreated = false;
            try
            {
                isCreated = activoRepositorio.CrearActivo(activo);
            }
            catch (Exception)
            {
            }

            return isCreated;
        }

        public bool EditarActivo(UpdateActivoRequest activo)
        {
            bool isEdited = false;
            try
            {
                isEdited = activoRepositorio.EditarActivo(activo);
            }
            catch (Exception)
            {
            }

            return isEdited;
        }

        public List<ActivoEmpleadoVM> EmpleadoLista()
        {
            List<ActivoEmpleadoVM> activos = new List<ActivoEmpleadoVM>();

            try
            {
                activos = activoRepositorio.EmpleadoLista();
            }
            catch (Exception)
            {
            }

            return activos;
        }
    }
}
