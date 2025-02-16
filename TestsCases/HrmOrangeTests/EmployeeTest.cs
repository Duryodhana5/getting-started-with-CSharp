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
    [TestFixture, Order(2)]
   // [Parallelizable]
   public class EmployeeTest : BaseTest
    {
        [Test, Order(2)]
        public void AddNewEmployeeInList()
        {
            loginPage.AddNewEmployeeInList("Basava", "Duryodhana", "551");
            Assert.IsTrue(loginPage.IsAddedPersonalDetails(), "Basava Duryodhana Profile visible");
            test.Log(Status.Pass, "Add Employee test passed");

        }

        [Test, Order(3)]
        public void DeleteAddedEmployeeInList()
        {
            loginPage.DeleteEmployeeFromList("Basava Duryodhana", "0396551");
            Assert.IsTrue(loginPage.IsEmployeeDeleted(), "Basava Duryodhana Profile not deleted");
            test.Log(Status.Pass, "Delete Added EmployeeInList test passed");
            WebDriverManager.QuitDriver();
        }
    }
}
