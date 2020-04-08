using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvironmentSetUp.Gateways
{
    public class SQL_String
    {
        public static string GetRDSConnectionString()
        {
            return "server=aa1629zf2rz0nr2.cyl7ndw9icyi.us-east-2.rds.amazonaws.com;database=NovaRoomRegistrationTest;username=minitoadmin;password=easypass;";
        }
    }
}