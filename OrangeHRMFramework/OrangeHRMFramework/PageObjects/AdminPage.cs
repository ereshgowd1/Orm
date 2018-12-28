using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OrangeHRMFramework.BaseClass;
using OrangeHRMFramework.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMFramework.PageObjects
{
    public class AdminPage : PageBase
    {
        private IWebDriver driver;

        #region Fields

        [FindsBy(How = How.XPath, Using = "//input[@id='btnAdd']")]
        private IWebElement Addbtn;

        [FindsBy(How = How.XPath, Using = "//h1[text()='Add User']")]
        private IWebElement AddUserText;
        #endregion

        public AdminPage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        #region Action

        public void ClickOnAddBtn()
        {
            Addbtn.Click();
        }
        #endregion
        #region Navigation
        public AddUserPage NavigateToAddUser()
        {
            String Actual = AddUserText.Text;
            Assert.AreEqual("Add User",Actual);
            return new AddUserPage(driver);
        }
        #endregion
    }
}
