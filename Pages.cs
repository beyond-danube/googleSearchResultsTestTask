using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.ObjectModel;


namespace CertentTestTask
{
    public class GoogleSearchPage
    {

        [FindsBy(How = How.Name, Using = "q")]
        public IWebElement Q { get; set; }

        public void GooleSearch(string searchArg)
        {
            Q.SendKeys(searchArg);
            Q.Submit();
        }
    }

    public class GoogleSearchResultsPage
    {

        [FindsBy(How = How.Id, Using = "search")]
        public IWebElement ResultsPanel { get; set; }

        public ReadOnlyCollection<IWebElement> SearchResults { get => ResultsPanel.FindElements(By.ClassName("rc")); }

    }

}
