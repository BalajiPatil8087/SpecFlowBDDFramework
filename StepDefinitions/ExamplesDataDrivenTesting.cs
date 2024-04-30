using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.IO;

namespace SpecFlowProject1.StepDefinitions
{

    [Binding]
    public sealed class ExamplesDataDrivenTesting
    {
        private IWebDriver driver;
       
        // Rename the report file
        public ExamplesDataDrivenTesting(IWebDriver driver)
        { 
            this.driver = driver;
        }

        [Then(@"Search for (.*)")]
        public void ThenSearchForSpecflowByTesterTalk(string searchkey)
        {

            driver.FindElement(By.XPath("//input[@name='search_query']")).SendKeys(searchkey);
            driver.FindElement(By.XPath("//input[@name='search_query']")).SendKeys(Keys.Enter);
            Thread.Sleep(5000);
        }
    }
}