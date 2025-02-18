using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using getting_started_with_CSharp.Drivers;
using getting_started_with_CSharp.Utilities;

namespace getting_started_with_CSharp.TestsCases.HrmOrangeTests
{
    [TestFixture("chrome")]
    //[TestFixture("firefox")]
    //[TestFixture("edge")]
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture, Order(1)]
    public class LoginTest : BaseTest
    {
        public LoginTest(string browser) : base(browser) { }
        [Test, Order(1)]
        public void LoginOrangeHRM()
        {
            loginPage.ClickOnLogin("Admin", "admin123");
            Assert.IsTrue(loginPage.IsDashboardVisible(), "Login failed or Dashboard not visible.");
            test.Log(Status.Pass, "LoginOrangeHRM test passed");
        }
        [Test, Order(2)]
        public void AddNewEmployeeInList()
        {
            loginPage.AddNewEmployeeInList("John", "Leo", "551");
            Assert.IsTrue(loginPage.IsAddedPersonalDetails(), "John Leo Profile visible");
            test.Log(Status.Pass, "Add Employee test passed");
        }
        [Test, Order(3)]
        public void DeleteAddedEmployeeInList()
        {
            loginPage.DeleteEmployeeFromList("Basava Duryodhana", "0423551");
            Assert.IsTrue(loginPage.IsEmployeeDeleted(), "Basava Duryodhana Profile not deleted");
            test.Log(Status.Pass, "Delete Added EmployeeInList test passed");
        }
    }
}
