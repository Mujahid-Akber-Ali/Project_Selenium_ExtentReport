using OpenQA.Selenium;

namespace Project_Selenium_Extent
{
    [TestClass]
    public class UnitTest1 : ExtentReport
    {

        [TestInitialize]
        public void Initialize()
        {

            inti();
            LogReport("Testing");
            driver.Manage().Window.Maximize();

        }

        [TestCleanup]
        public void Cleanup()
        {

            Thread.Sleep(3000);
            extentReports.Flush();
            driver.Close();

        }

        [TestMethod]
        public void TestMethod1()
        {
            exParentTest = extentReports.CreateTest("Project Test");

            exChildTest = exParentTest.CreateNode("Login");

            //Enter Username
            Write(By.Name("username"), "bilal.hussain", "Entering Username");

            //Enter Password
            Write(By.Name("password"), "Utopia01", "Entering Password");

            //Press login button
            Click(By.XPath("/html/body/div/div/div/div/form/button"), "Clicking Submit");
            Thread.Sleep(1000);

        }
    }
}