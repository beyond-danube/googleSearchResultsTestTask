using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;

namespace CertentTestTask
{
    [TestFixture]
    public class SearchResultsTests
    {
        IWebDriver driver;

        static object[] QSource =
        {
            new object[] { "Cheese", "" },
            new object[] { "Cheese", "wikipedia.org" },
            new object[] { "Milk", "" },
            new object[] { "Milk", "wikipedia.org" }
        };

        [OneTimeSetUp]
        public void RunChrome()
        {
             driver = new ChromeDriver();
        }

        [TestCaseSource("QSource")]
        public void GoogleSerachResultsCheckTest(string qstr, string site)
        {
            driver.Url = "https://www.google.com";
            string search = qstr;

            if (!string.IsNullOrEmpty(site))
            {
                search += " site:" + site;
            }

            var searchPage = new GoogleSearchPage();
            PageFactory.InitElements(driver, searchPage);

            searchPage.GooleSearch(search);

            var resutsPage = new GoogleSearchResultsPage();
            PageFactory.InitElements(driver, resutsPage);

            GoogleSearchResultsChecker.CheckResultsArePresent(resutsPage.SearchResults.Count, 0);    

            foreach (IWebElement e in resutsPage.SearchResults)
            {
                GoogleSearchResultsChecker.CheckSearchResults(e.Text, qstr);

                if (!string.IsNullOrEmpty(site))
                {
                    GoogleSearchResultsChecker.CheckSearchResultsLinks(e.FindElement(By.TagName("a")).GetAttribute("href"), site);
                }
            }

        }


        [Test]
        public void GoogleSerachResultsCountTest([Values("Cheese", "Milk")] string qstr, [Range(0,10)] int i)
        {
            driver.Url = "https://www.google.com/search?q=" + qstr + "&num=" + i.ToString();

            var resutsPage = new GoogleSearchResultsPage();
            PageFactory.InitElements(driver, resutsPage);

            GoogleSearchResultsChecker.CheckNumberOfSearchResults(i, resutsPage.SearchResults.Count);
        }

        [OneTimeTearDown]
        public void CloseChrome()
        {
            driver.Dispose();
        }
    }

   


}

