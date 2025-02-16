using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using getting_started_with_CSharp.Utilities;

namespace getting_started_with_CSharp.TestsCases.HrmOrangeTests
{
    //[Parallelizable]
    [TestFixture, Order(1)]
    public class LoginTest : BaseTest
    {
        [Test, Order(1)]
        public void LoginOrangeHRM()
        {
            loginPage.ClickOnLogin("Admin", "admin123");
            Assert.IsTrue(loginPage.IsDashboardVisible(), "Login failed or Dashboard not visible.");
            test.Log(Status.Pass, "LoginOrangeHRM test passed");
        }
       
    }
}