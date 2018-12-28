using System;
using System.Configuration;
using System.IO;
using System.Threading;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OrangeHRMFramework.ComponentHelper;
using OrangeHRMFramework.PageObjects;
using OrangeHRMFramework.Settings;

namespace OrangeHRMFramework
{
    [TestClass]
    public class OrangeHRMTests
    {
        public  static ExtentReports extent;
        public  ExtentTest test;

        public TestContext _testContext;
        public TestContext TestContext
        {
            get { return _testContext; }
            set { _testContext = value;  }
        }

        [TestInitialize]
        public void TestInitialize()
        {           
                var htmlReporter = new ExtentHtmlReporter("extentReport.html");
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
                extent.AddSystemInfo("Operating System", "Windows 10");
                extent.AddSystemInfo("Host Name", "GOWDARED11");
                extent.AddSystemInfo("Browser", "Google Chrome");

        }

        [TestCleanup]
        public void CleanUp()
        {
            test.Log(Status.Pass, "TestPassed");
            test.Pass("screen").AddScreenCaptureFromPath("Screen.jpeg");
            Thread.Sleep(4000);
            JavaScriptHelper.JSClick(By.XPath("//a[text()='Logout']"));
            
        }
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"C:\Users\gowdared\Desktop\data1.xml", "Raw", DataAccessMethod.Sequential)]
        public void OpenPage()
        {
            test = extent.CreateTest("OpenPage");
            NavigationHelper.NavigateUrl(ObjectRepository.Config.GetWebsite());
            Assert.AreEqual("OrangeHRM", PageHelper.PageTitle());
            TextBoxHelper.SendKeys(TestContext.DataRow["Username"].ToString(), By.XPath("//input[@name='txtUsername']"));
            TextBoxHelper.SendKeys(TestContext.DataRow["Password"].ToString(), By.XPath("//input[@name='txtPassword']"));
            ButtonHelper.BtnClick(By.XPath("//input[@name='Submit']"));
            string WelCom = ObjectRepository.Driver.FindElement(By.XPath("//*[@id='welcome']")).Text;
            Assert.AreEqual("Welcome Admin", WelCom);
        }
        [TestMethod]
        public void OpenPageUsingPOM()
        {
            test = extent.CreateTest("OpenPageUsingPOM");
            ILog Logger = Log4NetHelper.GetLooger(typeof(OrangeHRMTests));
            Logger.Error("Adding User1");
            NavigationHelper.NavigateUrl(ObjectRepository.Config.GetWebsite());
            LoginPage pg = new LoginPage(ObjectRepository.Driver);
            pg.Login();
            AdminPage ad = pg.NavigateToAdmin();
            ad.ClickOnAddBtn();
            AddUserPage aup = ad.NavigateToAddUser();
            ScreenShotHelper.TakeScreenShot("Test.jpeg");
            aup.AddUser();
                       
            // ExtentReportHelper.StartReport("OpenPageUsingPOM");
            // Screenshot screenshot = ((ITakesScreenshot)ObjectRepository.Driver).GetScreenshot();
            //screenshot.SaveAsFile("eresh", ScreenshotImageFormat.Jpeg

            //ScreenShotHelper.TakeScreenShot("Test.jpeg");
           
        }
        [ClassCleanup]
        public static void classCleanup()
        {
            extent.Flush();
        }
    }
}
