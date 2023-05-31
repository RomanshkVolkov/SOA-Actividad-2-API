using Domain.Entities;

namespace Service.IServices
{
    public interface IAuth
    {
        LoginPersona? Login(string email, string password);
    }
}
