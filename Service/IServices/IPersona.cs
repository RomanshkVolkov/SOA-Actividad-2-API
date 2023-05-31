using Domain.Entities;

namespace Service.IServices
{
    public interface IPersona
    {
        List<Persona> ObtenerLista();
        List<EmpleadoVM> GetEmpleados();
        List<EmpleadosActivosVM> GetEmpleadosActivos();
        bool CreatePerson(CreatePersonRequest data);
        List<LoginPersona> SearchEmployee();
        bool UpdatePerson(UpdatePersonRequest data);
        bool DeletePerson(int id);
    }
}
