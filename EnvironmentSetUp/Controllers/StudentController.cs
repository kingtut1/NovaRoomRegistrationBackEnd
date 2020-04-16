using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EnvironmentSetUp.Models;
using EnvironmentSetUp.Gateways;

namespace EnvironmentSetUp.Controllers
{
    public class StudentController : ApiController
    {
        private StudentGateway studentGateway = new StudentGateway();

        [HttpGet]
        [Route("api/GetStudent/{NNumber}")]
        public Student GetStudent(int NNumber)
        {
            return studentGateway.GetStudent(NNumber);
        }

        [HttpGet]
        [Route("api/GetBF/{NNumber}")]
        public List<BuildingFloor> GetBF(int NNumber)
        {
            return studentGateway.GetBuildingFloors(NNumber);
        }


    }
}
