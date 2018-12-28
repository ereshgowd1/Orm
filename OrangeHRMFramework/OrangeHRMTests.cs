using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OrangeHRMFramework.ComponentHelper;
using OrangeHRMFramework.Settings;

namespace OrangeHRMFramework
{
    [TestClass]
    public class OrangeHRMTests
    {
        public TestContext _testContext;
        public TestContext TestContext
        {
            get { return _testContext; }
            set { _testContext = value;  }
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"C:\Users\gowdared\Desktop\data1.xml", "Raw", DataAccessMethod.Sequential)]
        public void OpenPage()
        {
            NavigationHelper.NavigateUrl(ObjectRepository.Config.GetWebsite());
            //string PageTitile = ObjectRepository.Driver.Title;
            Assert.AreEqual("OrangeHRM", PageHelper.PageTitle());
            TextBoxHelper.SendKeys(TestContext.DataRow["Username"].ToString(), By.XPath("//input[@name='txtUsername']"));
            TextBoxHelper.SendKeys(TestContext.DataRow["Password"].ToString(), By.XPath("//input[@name='txtPassword']"));
            ButtonHelper.BtnClick(By.XPath("//input[@name='Submit']"));
            string WelCom = ObjectRepository.Driver.FindElement(By.XPath("//*[@id='welcome']")).Text;
            Assert.AreEqual("Welcome Admin", WelCom);


        }
    }
}
