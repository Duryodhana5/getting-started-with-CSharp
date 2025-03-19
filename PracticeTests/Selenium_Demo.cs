using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;

using OpenQA.Selenium.Edge;

namespace Selenium_Demo.TestCases
{
    public class InteractWithElements
    {
        public IWebDriver dr;
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("I am from setup method");
            //dr = new ChromeDriver(@"C:\Users\Anand.Gummadilli\Downloads");
            dr = new EdgeDriver("C:C:\\Users\\duryo\\OneDrive\\Desktop");

        }

        [Test]
        public void InteractWithtextbox()
        {
            dr.Navigate().GoToUrl("http://google.com");
            dr.FindElement(By.Name("q")).SendKeys("India");
            dr.FindElement(By.Name("q")).SendKeys(Keys.Enter);
            IWebElement txtSrch2 = dr.FindElement(By.Name("q"));
            Console.WriteLine(txtSrch2.GetAttribute("value"));
            Assert.IsTrue(txtSrch2.GetAttribute("value") == "India", "Search keyword not matching");
            Assert.IsTrue(txtSrch2.GetAttribute("maxlength") == "2048", "maxlength not matching");
            Console.WriteLine(txtSrch2.GetAttribute("name"));
        }
        [Test]
        public void InteractWithCheckBoxAndRadio()
        {
            dr.Navigate().GoToUrl("https://www.ironspider.ca/forms/checkradio.htm");
            IWebElement chkRed = dr.FindElement(By.XPath("//input[@value='red']"));
            //Console.WriteLine("blue color is selected:" + chkRed.Selected);
            if (chkRed.Selected == false)
            {
                chkRed.Click(); //select
            }
            IWebElement radioOpera = dr.FindElement(By.XPath("(//input[@type='radio'])[3]"));
            Console.WriteLine("Opera is selected1:" + radioOpera.Selected);
            if (radioOpera.Selected == false)
            {
                radioOpera.Click();
            }
            Console.WriteLine("Opera is selected2:" + radioOpera.Selected);
        }

        [Test]
        public void HandlingSelectBox()
        {
            dr.Navigate().GoToUrl("https://demo.guru99.com/test/newtours/register.php");
            IWebElement ddCountry = dr.FindElement(By.Name("country"));
            //ddCountry.SendKeys("HYDERABAD");
            //SelectElement objSelect = new SelectElement(dr.FindElement(By.Name("country")));
            SelectElement objSelect = new SelectElement(ddCountry);

            objSelect.SelectByIndex(2);
            objSelect.SelectByText("INDIA");
            objSelect.SelectByValue("CHINA");
            Console.WriteLine("Multiple values allowed:" + objSelect.IsMultiple);

            int optCount = objSelect.Options.Count;
            Console.WriteLine("options count is:" + optCount);

            //objSelect.DeselectByValue("CHINA");
            //for (int i = 0; i < optCount; i++)
            //{
            //    objSelect.SelectByIndex(i);
            //}
        }
        [Test]
        public void InteractWithListbox()
        {
            dr.Navigate().GoToUrl("https://output.jsbin.com/osebed/2");
            IWebElement fruitsLB = dr.FindElement(By.XPath("//select[@id='fruits']"));
            SelectElement objSelect = new SelectElement(fruitsLB);
            Console.WriteLine("Multi select allowed:" + objSelect.IsMultiple);
            objSelect.SelectByValue("apple");
            objSelect.SelectByText("Grape");
            Console.WriteLine("Selected options count before:" + objSelect.AllSelectedOptions.Count);
            objSelect.DeselectByText("Apple");

            //objSelect.DeselectAll();
            //objSelect.DeselectByText("Grape");
            Console.WriteLine("Selected options count after:" + objSelect.AllSelectedOptions.Count);

        }
    }
}