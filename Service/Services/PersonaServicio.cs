using Domain.Entities;
using Microsoft.Extensions.Logging;
using Repository.Context;
using Repository.DAO;
using Service.IServices;

namespace Service.Services
{
    public class PersonaServicio : IPersona
    {
        private readonly ILogger<PersonaServicio> _logger;
        public readonly PersonaRepositorio personaRepositorio;
        private readonly HashHelperService _hashHelperService;

        public PersonaServicio(ILogger<PersonaServicio> logger, ApplicationDbContext context, HashHelperService hashHelperService)
        {
            _logger = logger;
            personaRepositorio = new PersonaRepositorio(context);
            _hashHelperService = hashHelperService;
        }

        public List<Persona> ObtenerLista()
        {
            List<Persona> personas = new List<Persona>();

            try
            {
                personas = personaRepositorio.ObtenerLista();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return personas;
        }

        public List<EmpleadoVM> GetEmpleados()
        {
            List<EmpleadoVM> empleadoVMs = new List<EmpleadoVM>();
            try
            {
                empleadoVMs = personaRepositorio.GetEmpleados();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return empleadoVMs;
        }

        public List<EmpleadosActivosVM> GetEmpleadosActivos()
        {
            List<EmpleadosActivosVM> empleadosActivosVMs = new();
            try
            {
                empleadosActivosVMs = personaRepositorio.GetEmpleadosToInput();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return empleadosActivosVMs;
        }

        public bool CreatePerson(CreatePersonRequest data)
        {
            bool isCreated = false;
            try
            {
                data.password = _hashHelperService.GenerateHash(data.password);
                isCreated = personaRepositorio.CreatePerson(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return isCreated;
        }

        public bool UpdatePerson(UpdatePersonRequest data)
        {
            bool isUpdated = false;
            try
            {
                isUpdated = personaRepositorio.UpdatePerson(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return isUpdated;
        }

        public bool DeletePerson(int id)
        {
            bool isDeleted = false;
            try
            {
                isDeleted = personaRepositorio.DeletePerson(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return isDeleted;
        }

        public List<LoginPersona> SearchEmployee()
        {                
            List<LoginPersona> findUser = new List<LoginPersona>();
            try
            {
                findUser = personaRepositorio.GetEmpleado().Select(x => new LoginPersona()
                {
                    Email = x.Email,
                    Password = x.Password,
                }).ToList();

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
                return findUser;
        }

        public List<EmpleadoRecordatorio> GetPersonasByDeadLineToday()
        {
            List<EmpleadoRecordatorio> personas = new List<EmpleadoRecordatorio>();

            try
            {
                personas = personaRepositorio.GetPersonasByDeadLineToday();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return personas;
        }
    }
}
