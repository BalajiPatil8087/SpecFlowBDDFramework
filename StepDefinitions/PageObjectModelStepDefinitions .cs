using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using SpecFlowProject1.Pages;
using System.IO;

namespace SpecFlowProject1.StepDefinitions
{

    [Binding]
    public sealed class PageObjectModelStepDefinitions
    {
        private IWebDriver driver;

        SearchPage searchPage;

        ResultPage resultPage;

        ChannelPage channelPage;

        // Rename the report file
        public PageObjectModelStepDefinitions(IWebDriver driver)
        { 
            this.driver = driver;
        }

        [Given(@"Enter the youtube URL")]
        public void GivenEnterTheYoutubeURL()
        {
            driver.Url = "https://www.youtube.com/";
            Thread.Sleep(3000);
        }

        [When(@"Serach for the testers talk in youtube")]
        public void WhenSerachForTheTestersTalkInYoutube()
        {
             searchPage = new SearchPage(driver);

            resultPage= searchPage.searchText("testers talk");

            Thread.Sleep(3000);

        }

        [When(@"Navigatevto channel")]
        public void WhenNavigatevtoChannel()
        {
            channelPage = resultPage.ClickOnChannel();

            Thread.Sleep(3000);
        }

        [Then(@"Verify title of the page")]
        public void ThenVerifyTitleOfThePage()
        {
            Assert.AreEqual("Testers Talk - YouTube",channelPage.GetTitle());
        }





    }
}