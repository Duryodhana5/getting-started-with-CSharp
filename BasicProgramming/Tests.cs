using System;

namespace getting_started_with_CSharp.BasicProgramming
{
    public class Tests
    {
        Methods practice = new Methods();

        [Test]
        public void VerifyAddTwoNumber()
        {
            int result = practice.AddTwoNumber(10, 20);
            Console.WriteLine("Result of AddTwoNumber(10, 20): " + result);
        }

        [Test]
        public void GetHouseInfo()
        {
            // Call the common method for house information
            DisplayHouseDetails();
        }

        // Common method to display house details, price, and date
        private void DisplayHouseDetails()
        {
            // Getting house details
            Methods.getHouseInfo house = new Methods.getHouseInfo();
            Console.WriteLine("House Info:");
            Console.WriteLine(house.houseDetails());

            // Getting house price
            Console.WriteLine("House Price:");
            Methods.GetHousePrice();

            // Getting current date
            Console.WriteLine("Today's Date:");
            practice.DisplayTodaysDate();
        }
    }
}
