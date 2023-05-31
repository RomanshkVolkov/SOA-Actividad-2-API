using Domain.Entities;

namespace Service.IServices
{
    public interface IActivo
    {
        List<ActivoVM> ObtenerLista();
        bool CrearActivo(ActivoRequest activo);
        bool EditarActivo(UpdateActivoRequest activo);
        List<ActivoEmpleadoVM> EmpleadoLista();

    }
}
