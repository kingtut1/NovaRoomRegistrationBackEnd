using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvironmentSetUp.Models
{
    public class Room
    {
        public int RoomNumber { get; set; }
        public int Price { get; set; }
        public Nullable<int> Occupant1 { get; set; }
        public Nullable<int> Occupant2 { get; set; }
        public Nullable<int> Occupant3 { get; set; }
        public Nullable<int> Occupant4 { get; set; }
    }
}