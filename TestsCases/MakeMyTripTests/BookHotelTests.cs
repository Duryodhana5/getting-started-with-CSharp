using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using getting_started_with_CSharp.Utilities;

namespace getting_started_with_CSharp.TestsCases.MakeMyTripTests
{
    [TestFixture("firefox")]
    public class BookHotelTests : MakeMyTripBaseTest
    {
        public BookHotelTests(string browser) : base(browser)
        {
        }

        [Test, Order(1)]
        public void SearchHotelsInHyderabad()
        {
            bookHotelPages.SearchHotel("Hyderabad");
            Assert.IsTrue(bookHotelPages.ShowingHotelsInHyderabad(), "Hotels not visible");
        }

        [Test, Order(2)]
        public void BookSuiteRoomInITCKohenur()
        {
            bookHotelPages.BookRoomInITCKohenur("ITC Kohenur");
        }
    }
}
