using Service.IServices;
using System.Security.Cryptography;
using System.Text;

namespace Service.Services
{
    public class HashHelperService : IHashHelper
    {

        public string GenerateHash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                return hash;
            }
        }
    }
}
