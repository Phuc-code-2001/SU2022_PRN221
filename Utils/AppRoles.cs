using System.Collections.Generic;

namespace ShinyTeeth.Utils
{
    public class AppRoles
    {
        public static string Admin = "admin";
        public static string Doctor = "doctor";
        public static string Receptionist = "receptionist";
        public static string Customer = "customer";


        public static List<string> Items = new List<string>()
        {
            Admin,
            Doctor,
            Receptionist,
            Customer,
        };
    
    }

}
