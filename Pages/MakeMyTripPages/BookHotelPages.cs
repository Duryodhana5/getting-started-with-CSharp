using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Actions = getting_started_with_CSharp.Common.Actions;


namespace getting_started_with_CSharp.Pages.MakeMyTripPages
{
    public class BookHotelPages
    {
        private readonly IWebDriver driver;
        private readonly Actions actions;

        public BookHotelPages(IWebDriver driver)
        {
            this.driver = driver;
            actions = new Actions(driver);

        }
    }
}
