using Domain.Entities;
using Service.IServices;

namespace Service.Services
{
    public class AuthService : IAuth
    {
        private readonly IPersona _persona;
        private readonly HashHelperService _hashHelper;

        public AuthService(IPersona persona, HashHelperService hashHelper)
        {
            _persona = persona;
            _hashHelper = hashHelper;
        }

        public LoginPersona? Login(string email, string password)
        {
            LoginPersona userFind = new LoginPersona();
            var listPerson = _persona.SearchEmployee();
            var person = listPerson.Where(x => x.Email == email && x.Password == _hashHelper.GenerateHash(password)).FirstOrDefault();
            
            if(person != null) return person;
            return null;
        }
    }
}
