using OpenQA.Selenium;
using Actions = getting_started_with_CSharp.Common.Actions;


namespace getting_started_with_CSharp.Pages.MakeMyTripPages
{
    public class BookHotelPages
    {
        private readonly IWebDriver driver;
        private readonly Actions actions;

        public BookHotelPages(IWebDriver driver)
        {
            this.driver = driver;
            actions = new Actions(driver);
        }

        // Locators for Hotel Page
        private By popUp = By.XPath("//span[@class='commonModal__close']");
        private By Hotel = By.XPath("//span[@class='headerIconTextAlignment chNavText darkGreyText'][normalize-space()='Hotels']");
        private By ClickOncity = By.XPath("//input[@id='city']");
        private By EnterCityName = By.XPath("//input[@placeholder='Where do you want to stay?']");
        private By SelectFirstDropdown = By.XPath("//ul[@role='listbox']/li/descendant::b[contains(text(),'Hyderabad')]");
        private By Startingdate = By.XPath("//div[@aria-label='Sat Mar 15 2025']");
        private By EndDate = By.XPath("//div[@aria-label='Wed Mar 26 2025']");
        private By ApplyFilter = By.XPath("//button[normalize-space()='Apply']");
        private By SearchButton = By.XPath("//button[@id='hsw_search_button']");
        private By HyderabadHotels = By.XPath("//div[@class ='latoBlack blackText appendBottom20 ']//p[@class = 'font26']");

        // Locators for Book ITC Kohenur Hotel
        private By SearchHotelName = By.XPath("//input[@placeholder='Search for locality / hotel name']");

        public void SearchHotel(string City)
        {
            actions.ClickOnElement(popUp);
            actions.ClickOnElement(Hotel);
            actions.ClickOnElement(ClickOncity);
            actions.EnterText(EnterCityName, City);
            actions.ClickOnElement(SelectFirstDropdown);
            actions.ClickOnElement(Startingdate);
            actions.ClickOnElement(EndDate);
            actions.ClickOnElement(ApplyFilter);
            actions.ClickOnElement(SearchButton);

        }

        public bool ShowingHotelsInHyderabad()
        {
            return actions.IsElementVisible(HyderabadHotels);
        }

        public void BookHotelInHyderabad(string HotelName)
        {
            actions.EnterText(SearchHotelName, HotelName);
        }
    }
}
