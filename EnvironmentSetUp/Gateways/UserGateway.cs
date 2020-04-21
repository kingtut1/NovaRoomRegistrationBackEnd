using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

namespace EnvironmentSetUp.Gateways
{
    public class UserGateway
    {

        public string Hash (string Pass)
        {
            HashAlgorithm sha = new SHA256CryptoServiceProvider();
            var data = Encoding.ASCII.GetBytes(Pass);
            byte[] password = sha.ComputeHash(data);
            Pass = Convert.ToBase64String(password);
            return Pass;
        }
        public bool Login(int Id, string pass)
        {
            pass = Hash(pass);
            string SQLQuery = "SELECT Password FROM NovaRoomRegistrationTest.User where NNumber like " + Convert.ToString(Id) + " and Password Like '" + Convert.ToString(pass) + "'";
            string output = "";
            using (MySqlConnection connection = new MySqlConnection(SQL_String.GetRDSConnectionString()))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(SQLQuery, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            output = reader.GetString(0);
                        }
                    }
                }

            }
            if (output != "")
                return true;
            else
                return false;
        }


        public bool ChangePass(int Id, string newPass)
        {
            string Pass = newPass;
            newPass = Hash(newPass);
            string SQLQuery = "UPDATE NovaRoomRegistrationTest.User SET Password = '" + newPass + "' where NNumber = " + Convert.ToString(Id);
            using (MySqlConnection connection = new MySqlConnection(SQL_String.GetRDSConnectionString()))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(SQLQuery, connection);
                command.ExecuteReader();
            }
            
            return Login(Id, Pass);
        }
    }
}