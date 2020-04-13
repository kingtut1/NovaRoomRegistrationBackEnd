using EnvironmentSetUp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EnvironmentSetUp.Gateways
{
    public class StudentGateway
    {
        public Student GetStudent(int Id)
        {
            using (var ctx = new NovaRoomRegistrationTestEntities())
            {
                return ctx.Student.SqlQuery("Select * from Student where NNumber = " + Id).FirstOrDefault();
            }
        }

    }
}