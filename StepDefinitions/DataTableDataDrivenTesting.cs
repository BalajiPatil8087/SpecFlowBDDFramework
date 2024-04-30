using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.IO;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow.BindingSkeletons;

namespace SpecFlowProject1.StepDefinitions
{

    [Binding]
    public sealed class DataTableDataDrivenTesting
    {
        private IWebDriver driver;

        // Rename the report file
        public DataTableDataDrivenTesting(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Then(@"Enter Search keyword in youtube")]
        public void ThenEnterSearchKeywordInYoutube(Table table)
        {
            var searchcriteria= table.CreateSet<SearchkeyTestData>();
            foreach(var keyword in searchcriteria)
            {
                driver.FindElement(By.XPath("//input[@name='search_query']")).Clear();
                driver.FindElement(By.XPath("//input[@name='search_query']")).SendKeys(keyword.searchKey);
                driver.FindElement(By.XPath("//input[@name='search_query']")).SendKeys(Keys.Enter);
                Thread.Sleep(5000);
            }
        }

        public class SearchkeyTestData
            {
                public string searchKey { get; set; }   
            }








    }
}