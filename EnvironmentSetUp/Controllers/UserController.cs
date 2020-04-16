using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EnvironmentSetUp.Gateways;
using System.Text;

namespace EnvironmentSetUp.Controllers
{
    public class UserController : ApiController
    {
        private UserGateway LoginGateway = new UserGateway();


        [HttpPost]
        [Route("/api/Login/{NNumber}/{Pass}")]
        public bool LoginStudent(int NNumber, string Pass)
        {
            return LoginGateway.Login(NNumber, Pass);
        }


        [HttpPost]
        [Route("/api/ChangePassword/{NNumber}/{newPassword}")]
        public bool ChangePassword(int NNumber, string newPassword)
        {
            return LoginGateway.ChangePass(NNumber, newPassword);
        }

    }
}
