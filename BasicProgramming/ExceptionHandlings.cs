using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.IO;
using System.Drawing;

namespace GettingStartedWithCSharp.BasicProgramming
{
    public class ExceptionHandlings
    {
        IWebDriver dr;

        [SetUp]
        public void Setup()
        {
            dr = new ChromeDriver();
            dr.Manage().Window.Maximize();
        }

        [Test]
        public void Getscreenshot()
        {
            try
            {
                dr.Navigate().GoToUrl("https://www.axismf.com");
                dr.FindElement(By.XPath("(//ion-button[@id='origin'])[2]")).Click(); //click on Login button

                IWebElement elementPan = dr.FindElement(By.XPath("(//input[@name='pan'])[2]"));
                elementPan.SendKeys("India"); //enter india in PAn number

                IWebElement panError = dr.FindElement(By.XPath("//div[text()='Please enter a correct PAN']"));
                //Thread.Sleep(2000);
                Assert.IsTrue(panError.Size != Size.Empty, "validation error is not displayed for PAN"); //Error is displayed

            }
            catch (ElementClickInterceptedException clickex)
            {
                Console.WriteLine(clickex.Message);

                ITakesScreenshot screenshotDriver = dr as ITakesScreenshot;
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                // Creating UIScreenshot folder if not exists
                System.IO.Directory.CreateDirectory(Environment.CurrentDirectory + "/UIScreenshots/");
                string fileName = Environment.CurrentDirectory + "/UIScreenshots/" + "sampletestcase" + "_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss");
                //string fileName = Environment.CurrentDirectory + "/UIScreenshots/" + "Sample1.png";
                //screenshot.SaveAsFile(fileName, ScreenshotImageFormate.Bmp);
            }
            catch (NoSuchElementException nosuchex)
            {
                Console.WriteLine(nosuchex.Message);
                ITakesScreenshot screenshotDriver = dr as ITakesScreenshot;
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                // Creating UIScreenshot folder if not exists
                System.IO.Directory.CreateDirectory(Environment.CurrentDirectory + "/UIScreenshots/");
                string fileName = Environment.CurrentDirectory + "/UIScreenshots/" + "sampletestcase" + "_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".png";
                //string fileName = Environment.CurrentDirectory + "/UIScreenshots/" + "Sample1.png";

                //screenshot.SaveAsFile(fileName, ScreenshotImageFormat.Bmp);
            }
            //catch (NoSuchWindowException ex)
            //{
            //    ITakesScreenshot screenshotDriver = dr as ITakesScreenshot;
            //    Screenshot screenshot = screenshotDriver.GetScreenshot();
            //    // Creating UIScreenshot folder if not exists
            //    System.IO.Directory.CreateDirectory(Environment.CurrentDirectory + "/UIScreenshots/");
            //    //string fileName = Environment.CurrentDirectory + "/UIScreenshots/" + "sampletestcase" + "_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".png";
            //    string fileName = Environment.CurrentDirectory + "/UIScreenshots/" + "Sample1.png";

            //    screenshot.SaveAsFile(fileName, ScreenshotImageFormat.Png);
            //}
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                dr.Quit();
            }
        }

        [TearDown]
        public void Tear()
        {
            dr.Quit();
            dr.Dispose();
        }
    }
}