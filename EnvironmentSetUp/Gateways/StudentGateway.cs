using EnvironmentSetUp.Models;
using System;
using System.Collections.Generic;
using MySql.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace EnvironmentSetUp.Gateways
{
    public class StudentGateway
    {
        public Student GetStudent(int Id)
        {
            string SQLQuery = "Select * from Student where NNumber = " + Id;
            Student output = new Student();
            using (MySqlConnection connection = new MySqlConnection(SQL_String.GetRDSConnectionString()))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(SQLQuery, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            output.FirstName = reader["FirstName"].ToString();
                            output.LastName = reader["LastName"].ToString();
                            output.RazorsEdge = Convert.ToBoolean(reader["RazorsEdge"]);
                            output.Athlete = Convert.ToBoolean(reader["Athlete"]);
                            output.Sex = reader["Sex"].ToString();
                            output.Level = reader["Level"].ToString();
                            output.NNumber = Id;
                        }
                    }
                }

            }
            return output;
            /*
            using (var ctx = new NovaRoomRegistrationTestEntities())
            {
                
                try
                {
                    return ctx.Student.SqlQuery("Select * from Student where NNumber = " + Id).FirstOrDefault();
                }
                catch (Exception e)
                {
                    Student se = new Student();
                    se.FirstName = Convert.ToString(e);
                    return (se);
                }
            }*/
        }

    }
}