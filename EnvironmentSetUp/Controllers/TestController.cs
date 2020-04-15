using EnvironmentSetUp.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EnvironmentSetUp.Controllers
{
    public class TestController : ApiController
    {
        TestGateway  sg = new TestGateway();


        [HttpGet]
        [Route("api/Test/ID/")]
        public string GetStudentPassword(int username)
        {
            return "Hello";

            //return sg.GetStudent(username);
        }
    }
}
