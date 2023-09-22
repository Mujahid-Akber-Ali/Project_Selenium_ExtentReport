using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter.Configuration;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Project_Selenium_Extent
{
    public class ExtentReport
    {
        public static IWebDriver driver;
        public static ExtentReports extentReports;
        public static ExtentTest exParentTest;
        public static ExtentTest exChildTest;
        public static string dirpath;

        public static void LogReport(string testcase)
        {
            extentReports = new ExtentReports();

            dirpath = @"..\..\TestExecutionReports\" + '_' + testcase;

            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(dirpath);

            htmlReporter.Config.Theme = Theme.Standard;

            extentReports.AttachReporter(htmlReporter);
        }

        public void inti()
        {
            driver = new EdgeDriver();

        }
        public void TakeScreenshot(Status status, string stepDetail)
        {

            string path = @"C:\Users\DELL\source\repos\UIM_Testing\UIM_Testing\bin\TestExecution ScreemShots\" + "TestExecLog_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            Screenshot image_username = ((ITakesScreenshot)driver).GetScreenshot();
            image_username.SaveAsFile(path + ".png", ScreenshotImageFormat.Png);
            ExtentReport.exChildTest.Log(status, stepDetail, MediaEntityBuilder
                .CreateScreenCaptureFromPath(path + ".png").Build());


        }

        public void Write(By by, string data, string detail)
        {
            try
            {
                driver.FindElement(by).SendKeys(data);
                TakeScreenshot(Status.Pass, detail);
            }
            catch (Exception ex)
            {
                TakeScreenshot(Status.Fail, "Entry Failed" + ex);
            }
        }

        public void Click(By by, string detail)
        {
            try
            {
                driver.FindElement(by).Click();
                TakeScreenshot(Status.Pass, detail);
            }
            catch (Exception ex)
            {
                TakeScreenshot(Status.Fail, "Click Failed" + ex);
            }
        }
    }
}
