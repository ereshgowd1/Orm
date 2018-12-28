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
    public class LoginPage : PageBase
    {
        private IWebDriver driver;
        #region WebElements
        [FindsBy(How = How.XPath, Using = "//*[@name='txtUsername']")]
        private IWebElement Username;
        [FindsBy(How = How.XPath, Using = " //*[@id='txtPassword']")]
        private IWebElement Password;
        [FindsBy(How = How.Name, Using = "Submit")]
        private IWebElement LoginBtn;
        [FindsBy(How = How.XPath, Using = "//*[text()='Admin']")]
        private IWebElement NavigateToAdm;


        #endregion

        public LoginPage(IWebDriver _driver): base(_driver)
        {
            this.driver = _driver;
        }

       // public object NavigateToAdm { get; private set; }

        #region Action
        public void Login()
        {
            Username.SendKeys("Admin");
            Password.SendKeys("admin123");
            LoginBtn.Click();
        }
        #endregion

        #region Navigation
        public AdminPage NavigateToAdmin()
        {
            NavigateToAdm.Click();
            return new AdminPage(driver);
        }
        #endregion
    }
}

