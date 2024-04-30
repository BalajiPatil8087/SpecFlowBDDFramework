using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Pages
{
    public class ResultPage
    {
        private IWebDriver driver;
        public ResultPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        By ChannelName = By.LinkText("Testers Talk");
        
        public ChannelPage ClickOnChannel() 
        {
            driver.FindElement(ChannelName).Click();
            return new ChannelPage(driver);
        }
    }
}
