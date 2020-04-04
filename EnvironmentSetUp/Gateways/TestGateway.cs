using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvironmentSetUp.Gateways
{
    public class TestGateway
    {
        readonly string connectionString = "server=aa1629zf2rz0nr2.cyl7ndw9icyi.us-east-2.rds.amazonaws.com;database=NovaRoomRegistrationTest;username=minitoadmin;password=easypass;";

        public string GetStudent(int username)
        {
            string SQLQuery = "SELECT * FROM NovaRoomRegistrationTest.User where NNumber like " + username + " ;";
            string output = "";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(SQLQuery, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            output = reader.GetString(1);
                        }
                    }
                }

            }
            return output;
        }
    }
}