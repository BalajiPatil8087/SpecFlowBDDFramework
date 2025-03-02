using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.IO;

namespace SpecFlowProject1.StepDefinitions
{

    [Binding]
    public sealed class Feature1StepDefinitions
    {
        private IWebDriver driver;
       
        // Rename the report file
        public Feature1StepDefinitions(IWebDriver driver)
        { 
            this.driver = driver;
        }

        [Given(@"Open the browser")]
        public void GivenOpenTheBrowser()
        {
           // driver = new EdgeDriver();
           // driver.Manage().Window.Maximize();
           
        }

        [When(@"Enter the URL")]
        public void WhenEnterTheURL()
        {
            driver.Url = "https://www.youtube.com/";
            Thread.Sleep(5000);
        }

        [Then(@"Search for the Testers Talk")]
        public void ThenSearchForTheTestersTalk()
        {
            driver.FindElement(By.XPath("//input[@name='search_query']")).SendKeys(" saste nashe");
            driver.FindElement(By.XPath("//input[@name='search_query']")).SendKeys(Keys.Enter);
            Thread.Sleep(5000);
            // driver.Quit();
            
        }
         

            

    }
}