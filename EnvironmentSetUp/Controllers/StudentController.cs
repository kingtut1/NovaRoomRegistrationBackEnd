using EnvironmentSetUp.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EnvironmentSetUp.Controllers
{
    
    public class StudentController : ApiController
    {
        StudentGateways sg = new StudentGateways();
        
        [HttpGet]
        [Route("api/Student/ID/{username}")]
        public string GetStudentPassword(int username)
        {
            return "Hello";
            //return sg.GetStudent(username);
        }
    }
}
