using EnvironmentSetUp.Models;
using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvironmentSetUp.Gateways
{
    public class ProjectGateway
    {
        public Room GetReservationByUsername(int NNumber)
        {
            string SQLQuery = "SELECT * from NovaRoomRegistrationTest.Project " +
                "WHERE Occupant1 = " + NNumber + " || Occupant2 = " + NNumber + " || Occupant3 = " + NNumber + " || Occupant4 =" + NNumber;
            Room output = new Room();
            using (MySqlConnection connection = new MySqlConnection(SQL_String.GetRDSConnectionString()))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(SQLQuery, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            output.RoomNumber = (int)reader["RoomNumber"];
                            output.Price = (int)reader["Price"];
                            if (reader["Occupant1"] == DBNull.Value)
                                output.Occupant1 = null;
                            else
                                output.Occupant1 = (int)reader["Occupant1"];
                            if (reader["Occupant2"] == DBNull.Value)
                                output.Occupant2 = null;
                            else
                                output.Occupant2 = (int)reader["Occupant2"];
                            if (reader["Occupant3"] == DBNull.Value)
                                output.Occupant3 = null;
                            else
                                output.Occupant3 = (int)reader["Occupant3"];
                            if (reader["Occupant4"] == DBNull.Value)
                                output.Occupant4 = null;
                            else
                                output.Occupant4 = (int)reader["Occupant4"];
                        }
                    }
                }

            }
            return output;
        }
        public List<Room> GetAvailableRoomsByFloor(string BuildingName, int FloorNumber)
        {
            //Lines 16-57 checks for all rooms except for rooms with no null occupants to the listOfOutputs
            string SQLQuery =
                "SELECT RoomNumber, Price, Occupant1, Occupant2, Occupant3, Occupant4 " +
                "FROM NovaRoomRegistrationTest.Project " +
                "WHERE (Occupant1 IS null || Occupant2 IS null || Occupant3 IS null || Occupant4 IS null) " +
                "AND BuildingName LIKE \"" + BuildingName + "\" and Left(RoomNumber, 1) LIKE " + FloorNumber;
            
            List<Room> listOfOutputs = new List<Room>();
            using (MySqlConnection connection = new MySqlConnection(SQL_String.GetRDSConnectionString()))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(SQLQuery, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Room output = new Room();
                            output.RoomNumber = (int)reader["RoomNumber"];
                            output.Price = (int)reader["Price"];
                            if(reader["Occupant1"] == DBNull.Value)
                                output.Occupant1 = null;
                            else
                                output.Occupant1 = (int)reader["Occupant1"];
                            if (reader["Occupant2"] == DBNull.Value)
                                output.Occupant2 = null;
                            else
                                output.Occupant2 = (int)reader["Occupant2"];
                            if (reader["Occupant3"] == DBNull.Value)
                                output.Occupant3 = null;
                            else
                                output.Occupant3 = (int)reader["Occupant3"];
                            if (reader["Occupant4"] == DBNull.Value)
                                output.Occupant4 = null;
                            else
                                output.Occupant4 = (int)reader["Occupant4"];
                            listOfOutputs.Add(output);
                        }
                    }
                }
            }
            return listOfOutputs;
        }

        public bool ReserveRoom(int NNumber, string BuildingName, int RoomNum)
        {
            //Lines 62-94 check if the student already exists in the table, returning false if they do
            string SQLQuery = "SELECT Occupant1,Occupant2,Occupant3,Occupant4 " +
                "FROM NovaRoomRegistrationTest.Project " +
                "WHERE Occupant1 = " + NNumber + " || Occupant2 = "+ NNumber + " || Occupant3 = " + NNumber + " || Occupant4 = " + NNumber;

            using (MySqlConnection connection = new MySqlConnection(SQL_String.GetRDSConnectionString()))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(SQLQuery, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if(reader["Occupant1"] != DBNull.Value)
                            {
                                return false;
                            }
                            else if (reader["Occupant2"] != DBNull.Value)
                            {
                                return false;
                            }
                            else if (reader["Occupant3"] != DBNull.Value)
                            {
                                return false;
                            }
                            else if (reader["Occupant4"] != DBNull.Value)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            //Line 97-130 gets all the occupants of a room, sets them in the Room class called output
            SQLQuery =
                "SELECT Occupant1, Occupant2, Occupant3, Occupant4 " +
                "FROM NovaRoomRegistrationTest.Project " +
                "WHERE BuildingName LIKE \"" + BuildingName + "\" and RoomNumber LIKE " + RoomNum;
            Room output = new Room();
            using (MySqlConnection connection = new MySqlConnection(SQL_String.GetRDSConnectionString()))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(SQLQuery, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        { 
                            if (reader["Occupant1"] == DBNull.Value)
                                output.Occupant1 = null;
                            else
                                output.Occupant1 = (int)reader["Occupant1"];
                            if (reader["Occupant2"] == DBNull.Value)
                                output.Occupant2 = null;
                            else
                                output.Occupant2 = (int)reader["Occupant2"];
                            if (reader["Occupant3"] == DBNull.Value)
                                output.Occupant3 = null;
                            else
                                output.Occupant3 = (int)reader["Occupant3"];
                            if (reader["Occupant4"] == DBNull.Value)
                                output.Occupant4 = null;
                            else
                                output.Occupant4 = (int)reader["Occupant4"];
                        }
                    }
                }
            }

            //133- 143 Checks to see which room is available, returning false if it's ever not available (though it should never reach that point)
            int OccNum = 0;
            if (output.Occupant1 == null)
                OccNum = 1;
            else if (output.Occupant2 == null)
                OccNum = 2;
            else if (output.Occupant3 == null)
                OccNum = 3;
            else if (output.Occupant4 == null)
                OccNum = 4;
            else
                return false;

            //146-155 Adds the student to the occupant column that is available.
            SQLQuery = "UPDATE NovaRoomRegistrationTest.Project SET Occupant" + OccNum + " = '" + NNumber + "' " +
                "WHERE (BuildingName = '" + BuildingName + "' ) and (`RoomNumber` = '" + RoomNum + "')";
            
            using (MySqlConnection connection = new MySqlConnection(SQL_String.GetRDSConnectionString()))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(SQLQuery, connection);
                try { command.ExecuteReader(); }
                catch (Exception e)
                {
                    return false;
                };
                return true;
            }
        }
    }
}