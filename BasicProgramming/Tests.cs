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
            Console.WriteLine("House Info:");
            Methods.getHouseInfo house = new Methods.getHouseInfo();
            string houseInfo = house.houseDetails();
            Console.WriteLine(houseInfo);
            Console.WriteLine("House Price:");
            Methods.GetHousePrice();
            Console.WriteLine("Today's Date:");
            Methods.GetHousePrice();
        }
    }
}
