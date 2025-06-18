using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using getting_started_with_CSharp.Common;
using Actions = getting_started_with_CSharp.Common.Actions;
using System.Security.Cryptography.X509Certificates;

namespace getting_started_with_CSharp.Pages.HrmOrangePages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        private readonly Actions actions;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            actions = new Actions(driver);
        }

        // Locators for Login Page
        private By userName = By.Name("username");
        private By passWord = By.Name("password");
        private By loginButton = By.XPath("//button[text()=' Login ']");
        private By dashboard = By.XPath("//h6[text()='Dashboard']");

        // Locators for Adding new employee list page
        private By pimMenu = By.XPath("//span[text()='PIM']");
        private By addEmployee = By.XPath("//a[text()='Add Employee']");
        private By EmployeeList = By.XPath("//a[text()='Employee List']");  
        private By firstName = By.Name("firstName");
        private By lastName = By.Name("lastName");
        private By employeeId = By.XPath("//label[text()='Employee Id']/following::input[1]");
        private By saveButton = By.XPath("//button[text()=' Save ']");
        private By personalDetails = By.XPath("//a[text()='Personal Details']");
       
        // Locators for Delete Employee from List
        private By searchEmployeeName = By.XPath("//label[text()='Employee Name']/following::input[1]");
        private By searchEmployeeId = By.XPath("//label[text()='Employee Id']/following::input[1]");
        private By searchButton = By.XPath("//button[text()=' Search ']");
        private By selectEmployee = By.XPath("//div[@class='oxd-table-card'][1]//label/span/i");
        private By deleteButton = By.XPath("//button[@class='oxd-button oxd-button--medium oxd-button--label-danger orangehrm-horizontal-margin']");
        private By confirmDeleteButton = By.XPath("//button[@class='oxd-button oxd-button--medium oxd-button--label-danger orangehrm-button-margin']");


        public void ClickOnLogin(string username, string password)
        {
            actions.EnterText(userName, username);
            actions.EnterText(passWord, password);
            actions.ClickOnElement(loginButton);
        }

        public bool IsDashboardVisible()
        {
            return actions.IsElementVisible(dashboard);
        }

        public void AddNewEmployeeInList(string firstNameValue, string lastNameValue, string employeeValue)
        {
            // Navigate to Add Employee Page
            actions.ClickOnElement(pimMenu);
            actions.ClickOnElement(addEmployee);

            // Enter Employee Details
            actions.EnterText(firstName, firstNameValue);
            actions.EnterText(lastName, lastNameValue);
            actions.EnterText(employeeId, employeeValue);
            actions.ClickOnElement(saveButton);
            // Enable Login Details and Enter Credentials
            actions.ClickOnElement(createLoginDetailsCheckbox);
        }
        public bool IsAddedPersonalDetails()
        {
            return actions.IsElementVisible(personalDetails);
        }
        public void DeleteEmployeeFromList(string SearchEmployeeName, string SearchEmployeeID)
        {
            // Navigate to Employee List Page
            actions.ClickOnElement(pimMenu);
            actions.ClickOnElement(EmployeeList);
            // Search for Employee and Delete
            actions.EnterText(searchEmployeeName, SearchEmployeeName);
            actions.EnterText(searchEmployeeId, SearchEmployeeID);
            actions.ClickOnElement(searchButton);
            actions.ClickOnElement(selectEmployee);
            actions.ClickOnElement(deleteButton);
            // actions.ClickOnElement(confirmDeleteButton);
        }

        public bool IsEmployeeDeleted()
        {
            return actions.IsElementVisible(searchButton);
        }
    }
}
