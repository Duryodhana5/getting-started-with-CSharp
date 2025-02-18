using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace getting_started_with_CSharp.Drivers
{
    public class WebDriverManager
    {
        // Store all driver instances
        private static List<IWebDriver> activeDrivers = new List<IWebDriver>();

        // This method will return the driver instance
        public static IWebDriver GetDriver(string browser)
        {
            IWebDriver driver = InitializeDriver(browser);
            activeDrivers.Add(driver);
            return driver;
        }

        // Initialize the WebDriver based on the browser
        private static IWebDriver InitializeDriver(string browser)
        {
            IWebDriver driver;
            switch (browser.ToLower())
            {
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                case "edge":
                    driver = new EdgeDriver();
                    break;
                default:
                    throw new ArgumentException("Unsupported browser: " + browser);
            }
            return driver;
        }

        // Method to quit all active drivers
        public static void QuitAllDrivers()
        {
            foreach (var driver in activeDrivers)
            {
                driver.Quit();
                driver.Dispose();
            }
            activeDrivers.Clear();
        }
    }
}
