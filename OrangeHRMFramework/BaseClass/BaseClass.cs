using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OrangeHRMFramework.ComponentHelper;
using OrangeHRMFramework.Configurations;
using OrangeHRMFramework.CustomException;
using OrangeHRMFramework.Interfaces;
using OrangeHRMFramework.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrangeHRMFramework.BaseClass
{
    [TestClass]
    public class BaseClass
    {
        private static IWebDriver GetChromeDriver()
        {
            IWebDriver driver = new ChromeDriver();
                return driver;
        }
        private static IWebDriver GetFirefoxDriver()
        {
            IWebDriver driver = new FirefoxDriver();
                return driver;
        }
        private static IWebDriver GetIEDriver()
        {
            IWebDriver driver = new InternetExplorerDriver();
            return driver;
        }
        [AssemblyInitialize]
        public static void initwebDriver(TestContext tc)
        {
            ObjectRepository.Config = new AppConfigReader();
            switch (ObjectRepository.Config.GetBrowser())
            {
                case BrowserType.Chrome:
                    ObjectRepository.Driver = GetChromeDriver();
                    break;
                case BrowserType.Firefox:
                    ObjectRepository.Driver = GetFirefoxDriver();
                    break;
                case BrowserType.IExplorer:
                    ObjectRepository.Driver = GetIEDriver();
                    break;
                default:
                    throw new NoSuchDriverFound("Specified driver not found" + ObjectRepository.Config.GetBrowser().ToString());
            }
            ObjectRepository.Driver.Manage().Window.Maximize();
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);     
        }
        /// <summary>
        /// TearDown the application
        /// 1. Logout user
        /// 2. close the application
        /// 3. Close all pages of the application.
        /// </summary>
        [AssemblyCleanup]
        public static void TearDown()
        {
            Thread.Sleep(4000);
            JavaScriptHelper.JSClick(By.XPath("//a[text()='Logout']"));
            Thread.Sleep(10000);
            ObjectRepository.Driver.Close();
            ObjectRepository.Driver.Quit();
        }
    }
}
