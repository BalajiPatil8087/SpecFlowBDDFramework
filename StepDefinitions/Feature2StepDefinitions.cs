using OpenQA.Selenium;

[Binding]
public sealed class Feature2StepDefinitions
{
    private IWebDriver driver;

    // Rename the report file
    public Feature2StepDefinitions(IWebDriver driver)
    {
        this.driver = driver;
    }

    [Then(@"Search for the Testers TalkOne")]
    public void ThenSearchForTheTestersTalkOne()
    {
        
        driver.FindElement(By.XPath("//input[@name='search_query']")).SendKeys("Tester Talk");
        driver.FindElement(By.XPath("//input[@name='search_query']")).SendKeys(Keys.Enter);
        Thread.Sleep(5000);

    }


    [Then (@"click on the  Testers Talk video")]
    public void ThenClickOnTheTestersTalkVideo()
    {
      
        driver.FindElement(By.XPath("//div[@id='text-container']//*[text()='Testers Talk']")).Click();
        Thread.Sleep(5000);
    }




}