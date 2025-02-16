using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace getting_started_with_CSharp.Drivers
{
    public class WebDriverManager
    {
        private static IWebDriver _driver;

        // This method will return the driver instance
        public static IWebDriver GetDriver(string browser = "chrome")
        {
            if (_driver == null)
            {
                _driver = InitializeDriver(browser);
            }
            return _driver;
        }

        // Initialize the WebDriver based on the browser
        private static IWebDriver InitializeDriver(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    return new ChromeDriver();
                case "firefox":
                    return new FirefoxDriver();
                case "edge":
                    return new EdgeDriver();
                default:
                    throw new ArgumentException("Unsupported browser: " + browser);
            }
        }

        // Method to quit the driver and clean up
        public static void QuitDriver()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null;
            }
        }
    }
}
