using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OrangeHRMFramework.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMFramework.ComponentHelper
{
    public class AutoSuggestiveHelper
    {
        public static void AutoSuggestive(By Locator,string text)
        {
            IWebElement element = ObjectRepository.Driver.FindElement(Locator);
            element.SendKeys(text);
            // var wait = ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(ObjectRepository.Driver);
           IList<IWebElement> ele = wait.Until(GetAllElement(By.XPath("//div[@class='ac_results']/ul/li")));
            foreach(var ele1 in ele)
            {
                if ( ele1.Text.Equals("Thomas Fleming"))
                {
                    ele1.Click();
                }
                
            }
        }

        private static Func<IWebDriver, IList<IWebElement>> GetAllElement(By Locator)
        {
            return ((x) =>
            {
                return x.FindElements(Locator);
            });
        }
    }
}
