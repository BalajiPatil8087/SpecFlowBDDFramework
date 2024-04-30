using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using MongoDB.Bson;
using OpenQA.Selenium;
using RazorEngine.Compilation.ImpromptuInterface.InvokeExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Utility
{
    public class ExtentReport

    {
        static int screenshotCount;

        public static ExtentReports _extentReports;

        public static ExtentTest _feature;

        public static ExtentTest _scenario;

        public static String dir = AppDomain.CurrentDomain.BaseDirectory;

        public static String testResultPath = dir.Replace("bin\\Debug\\net6.0", "TestResults");

        public static void ExtentReportInit()

        {

            var htmlReporter = new ExtentHtmlReporter(testResultPath + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".html");
            
            htmlReporter.Config.ReportName = "Automation Status Report";
            htmlReporter.Config.DocumentTitle = "Automation Status Report";

            htmlReporter.Config.Theme = Theme.Standard;
            htmlReporter.Start();

            _extentReports = new ExtentReports();

            _extentReports.AttachReporter(htmlReporter);

            _extentReports.AddSystemInfo("Application", "Youtube");

            _extentReports.AddSystemInfo("Browser", "Edge");

            _extentReports.AddSystemInfo("OS", "Windows");

        }

        public static void ExtentReportTearDown()

        {
            _extentReports.Flush();

        }
        public static string addScreenshot(IWebDriver driver)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string screenshotLocation = Path.Combine(testResultPath+ "\\Screenshot", DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".png");
            screenshot.SaveAsFile(screenshotLocation);
            return screenshotLocation;
        }
        public static void filename(string name)
        {
            string oldNameFullPath = "C:\\Users\\patilbs\\Desktop\\SpecFlowBDDFramework\\SpecFlowProject1\\TestResults\\index.html";
            File.Copy(oldNameFullPath, oldNameFullPath.Replace("index", name));

        }


    }

}
