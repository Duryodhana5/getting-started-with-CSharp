using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace getting_started_with_CSharp.BasicProgramming
{
    public class Methods
    {
        public int AddTwoNumber(int x, int y)
        {
            int z = x + y;
            return z;
        }

        public class getHouseInfo
        {
            public string ownerName = "Duryodhana";
            public string constructionYear = "2014";
            public bool garage = true;
            public static bool swimmingPool = true;
            public static string builderCompany = "Aparna Builders Inc.";
            public string houseType = "Villa";
            public string colour = "Pale green";

            public string houseDetails()
            {
                return "Owner Name: " + ownerName + "\n" +
                       "Construction Year: " + constructionYear + "\n" +
                       "Has Garage: " + garage + "\n" +
                       "Has Swimming Pool: " + swimmingPool + "\n" +
                       "Builder Company: " + builderCompany + "\n" +
                       "House Type: " + houseType + "\n" +
                       "House Color: " + colour;
            }

        }

        public static void GetHousePrice()
        {
            Console.WriteLine("The house price is: 5000000");
        }

        public void DisplayTodaysDate()
        {
            Console.WriteLine("Today's date is: " + DateTime.Now);
        }
    }
}
