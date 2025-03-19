using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Actions = getting_started_with_CSharp.Common.Actions;


namespace getting_started_with_CSharp.Pages.ConfrimTicketPages
{
    public class BookTrainTicketPages
    {
        private readonly IWebDriver driver;
        private readonly Actions actions;

        public BookTrainTicketPages(IWebDriver driver)
        {
            this.driver = driver;
            actions = new Actions(driver);
        }
    }
}