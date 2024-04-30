using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using SpecFlowProject1.Utility;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Hooks
{
    [Binding]
    public sealed class Hooks : ExtentReport
    {
        public static string featureName;
        public static IWebDriver driver;
        private readonly IObjectContainer _container;
        public Hooks(IObjectContainer container)
        {
            _container = container;
        }
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Running before test run..");
            ExtentReportInit();
            
        }
        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("Running after test run...");
            ExtentReportTearDown();
            filename(featureName);

        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("Running before feature...");
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
            featureName = featureContext.FeatureInfo.Title;
        }
        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("Running after feature...");
        }
        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {
            Console.WriteLine("Running inside tagged hooks in specflow");
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario(ScenarioContext scenarioContext)
        {
             driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            _container.RegisterInstanceAs<IWebDriver>(driver);
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _container.Resolve<IWebDriver>();
            if (driver != null)
            {
                driver.Quit();
            }
        }
       
            [AfterStep]
        public static void AfterStep(ScenarioContext scenarioContext)
        {
            Console.WriteLine("Running after step...");
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

            // when sceanario pass

            if (scenarioContext.TestError == null)
            {
               
                if (stepType == "Given")
                {
                    
                    _scenario.CreateNode<Given>(stepName).Pass("Pass", MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver)).Build());
                }
                else if (stepType == "When")
                {
                    
                    _scenario.CreateNode<When>(stepName).Pass("Pass", MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver)).Build()); 

                }
                else if (stepType == "Then")
                {
                    
                    _scenario.CreateNode<Then>(stepName).Pass("Pass", MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver)).Build()); 

                }
            }

            // when sceanario fail

            if (scenarioContext.TestError != null)
            {
               

                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message , MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver)).Build());
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver)).Build());
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver)).Build());
                }
            }
        }
    }
}
