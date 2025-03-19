using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using getting_started_with_CSharp.Pages.ConfrimTicketPages;
using getting_started_with_CSharp.Utilities;

namespace getting_started_with_CSharp.TestsCases.ConfrimTicketTests
{

    [TestFixture("edge")]
    public class BookTrainTicketTests : ConfrimTicketBaseTest
    {
        public BookTrainTicketTests(string browser) : base(browser)
        {
        }
        [Test, Order(1)]
        public void SearchTrainsToSompeta()
        {
            BookTrainTicketPages.SearchTrain("Hyderabad");
            Assert.IsTrue(bookTrainPages.ShowingTrainsInHyderabad(), "Trains not visible");
        }
        [Test, Order(2)]
        public void BookACFirstClassTicketInShatabdiExpress()
        {
            BookTrainTicketPages.BookTicketInShatabdiExpress("Shatabdi Express");
        }
    }
    
}
