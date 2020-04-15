using EnvironmentSetUp.Gateways;
using EnvironmentSetUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EnvironmentSetUp.Controllers
{
    public class ProjectController : ApiController
    {
        private ProjectGateway projectGateway = new ProjectGateway();

        [HttpGet]
        public List<Room> GetAvailableRoomsByFloor(string BuildingName, int FloorNumber)
        {
            return projectGateway.GetAvailableRoomsByFloor(BuildingName, FloorNumber);
        }

        [HttpPost]
        public bool ReserveRoom(int NNumber, string BuildingName, int RoomNum)
        {
            return projectGateway.ReserveRoom(NNumber, BuildingName, RoomNum);
        }
    }
}
