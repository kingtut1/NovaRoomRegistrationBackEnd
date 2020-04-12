using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Cryptography;
using EnvironmentSetUp.Gateways;
using System.Text;

namespace EnvironmentSetUp.Controllers
{
    public class UserController : ApiController
    {
        private UserGateway LoginGateway = new UserGateway();


        [HttpPost]
        public bool LoginStudent(int NNumber, string Pass)
        {
            HashAlgorithm sha = new SHA256CryptoServiceProvider();
            var data = Encoding.ASCII.GetBytes(Pass);
            byte[] password = sha.ComputeHash(data);
            string Password = Convert.ToBase64String(password);
            return LoginGateway.Login(NNumber, Password);
        }


        [HttpPost]
        public bool ChangePassword(int NNumber, string newPassword)
        {
            HashAlgorithm sha = new SHA256CryptoServiceProvider();
            var data = Encoding.ASCII.GetBytes(newPassword);
            byte[] password = sha.ComputeHash(data);
            string Password = Convert.ToBase64String(password);
            return LoginGateway.ChangePass(NNumber, Password);
        }

    }
}
