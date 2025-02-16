using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
namespace getting_started_with_CSharp.Common
{
    public class Actions
    {
        private readonly IWebDriver driver;

        public Actions(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement FindElement(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(20));
            var element= wait.Until(ExpectedConditions.ElementExists(locator));
            return element; 
            
        }

        public void ClickOnElement(By locator)
        {
            FindElement(locator).Click();
        }

        public void EnterText(By locator, string text)
        {  
            FindElement(locator).Clear();
            FindElement(locator).SendKeys(text);
        }

        public bool IsElementVisible(By locator)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}