﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter.Config;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using getting_started_with_CSharp.Drivers;
using getting_started_with_CSharp.Pages.MakeMyTripPages;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace getting_started_with_CSharp.Utilities
{
    public class ConfrimTicketBaseTest
    {
        protected IWebDriver driver;
        protected BookHotelPages bookHotelPages;
        private static ExtentReports extent;
        protected ExtentTest test;
        protected string browserType;

        public ConfrimTicketBaseTest(string browser)
        {
            this.browserType = browser;
        }

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            DateTime currentTime = DateTime.Now;
            string filename = "Extent_" + currentTime.ToString("yyyy_MM_dd_HH_mm_ss") + ".html";
            extent = CreateInstance(filename);

            driver = WebDriverManager.GetDriver(browserType);
            driver.Navigate().GoToUrl("https://www.confirmtkt.com/rbooking-d/");
            driver.Manage().Window.Maximize();
            bookHotelPages = new BookHotelPages(driver);
        }

        public static ExtentReports CreateInstance(string filename)
        {
            var reportPath = Path.Combine(Directory.GetCurrentDirectory(), "reports", filename);
            var htmlReport = new ExtentSparkReporter(reportPath);
            htmlReport.Config.Theme = Theme.Standard;
            htmlReport.Config.DocumentTitle = "Automation Report";
            htmlReport.Config.ReportName = "Automation Testing";
            htmlReport.Config.Encoding = "UTF-8";

            extent = new ExtentReports();
            extent.AttachReporter(htmlReport);
            extent.AddSystemInfo("Automation Tester", "Test User");
            return extent;
        }

        [SetUp]
        public void SetUp()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void AfterTest()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            switch (testStatus)
            {
                case TestStatus.Passed:
                    test.Pass("Pass: " + TestContext.CurrentContext.Result.Message);
                    test.Pass(MarkupHelper.CreateLabel("PASS", ExtentColor.Green));
                    break;
                case TestStatus.Failed:
                    test.Fail("Fail: " + TestContext.CurrentContext.Result.Message);
                    test.Fail(MarkupHelper.CreateLabel("FAIL", ExtentColor.Red));
                    break;
                case TestStatus.Skipped:
                    test.Skip("Skip: " + TestContext.CurrentContext.Result.Message);
                    test.Skip(MarkupHelper.CreateLabel("SKIP", ExtentColor.Orange));
                    break;
            }
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            extent.Flush();
        }
    }
}