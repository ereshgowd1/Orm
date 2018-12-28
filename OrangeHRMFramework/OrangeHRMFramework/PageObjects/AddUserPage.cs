using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OrangeHRMFramework.BaseClass;
using OpenQA.Selenium.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrangeHRMFramework.ComponentHelper;
using log4net;

namespace OrangeHRMFramework.PageObjects
{
    public class AddUserPage: PageBase
    {
        private IWebDriver driver;
        #region
        [FindsBy(How = How.XPath, Using = "//*[@name = 'systemUser[userType]']")]
        private IWebElement UserRole;

        [FindsBy(How = How.XPath, Using = "//input[@id='systemUser_employeeName_empName']")]
        private IWebElement EmployeeName;

        [FindsBy(How = How.XPath, Using = "//input[@id='systemUser_userName']")]
        private IWebElement Username;

        [FindsBy(How = How.XPath, Using = "//input[@id='systemUser_password']")]
        private IWebElement Password;

        [FindsBy(How = How.XPath, Using = "//input[@id='systemUser_confirmPassword']")]
        private IWebElement ConfirmPassword;

        [FindsBy(How = How.XPath, Using = "//input[@id='btnSave']")]
        private IWebElement SaveBtn;
        #endregion
        public AddUserPage(IWebDriver _driver):base(_driver)
        {
            this.driver = _driver;
        }
        public void AddUser()
        {

            ILog Logger = Log4NetHelper.GetLooger(typeof(AddUserPage));
            Logger.Info("Adding user");
            JavaScriptHelper.JSDropDownSelect(By.XPath("//*[@name = 'systemUser[userType]']"), "ESS");
            AutoSuggestiveHelper.AutoSuggestive(By.XPath("//input[@id='systemUser_employeeName_empName']"), "T");
            Username.SendKeys("ThomasFle");
            Password.SendKeys("Eresh@12345");
            ConfirmPassword.SendKeys("Eresh@12345");
            SaveBtn.Click();
            Logger.Info("User Added Succesfully");
            
        }
                       
    }
}
