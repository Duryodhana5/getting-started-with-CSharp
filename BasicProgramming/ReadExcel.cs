using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OfficeOpenXml; // EPPlus for Excel handling

namespace SeleniumTests
{
    public class ReadExcel
    {
        private IWebDriver driver;
        private string excelFilePath = @"C:\Users\duryo\Downloads\Test.xlsx";

        [SetUp]
        public void Setup()
        {
            // Ensure the Excel file exists
            Assert.IsTrue(File.Exists(excelFilePath), "Excel file does not exist: " + excelFilePath);

            // Initialize ChromeDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestGoogleSearchFromExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Required for EPPlus 5+

            var fileInfo = new FileInfo(excelFilePath);

            using (var package = new ExcelPackage(fileInfo))
            {
                var worksheet = package.Workbook.Worksheets[0]; 
                // Get first worksheet
                var rowCount = worksheet.Dimension?.Rows ?? 0; // Safe null handling

                Assert.Greater(rowCount, 1, "Excel file should have at least one data row.");

                for (int row = 2; row <= rowCount; row++) // Assuming first row is headers
                {
                    var searchQuery = worksheet.Cells[row, 1].Text; // Read search term from column 1
                    Assert.IsNotEmpty(searchQuery, $"Search term in row {row} is empty!");

                    Console.WriteLine($"Searching for: {searchQuery}");

                    // Open Google and search
                    driver.Navigate().GoToUrl("https://www.google.com");
                    var searchBox = driver.FindElement(By.Name("q"));
                    searchBox.SendKeys(searchQuery);
                    searchBox.SendKeys(Keys.Enter);

                    // Wait for results to load
                    System.Threading.Thread.Sleep(2000); // Better to use WebDriverWait in real tests

                    // Verify results are displayed
                    var results = driver.FindElements(By.CssSelector("h3"));
                    Assert.IsTrue(results.Count > 0, "No search results found!");

                    Console.WriteLine($"Search successful for: {searchQuery}");
                }
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit(); // Close browser
        }
    }
}
