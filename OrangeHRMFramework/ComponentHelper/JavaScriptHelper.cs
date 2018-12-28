using OpenQA.Selenium;
using OrangeHRMFramework.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMFramework.ComponentHelper
{
    public class JavaScriptHelper
    {
        public static void JSClick(By Locator)
        {
            IWebElement element = ObjectRepository.Driver.FindElement(Locator);
            IJavaScriptExecutor js = (IJavaScriptExecutor)ObjectRepository.Driver;
            js.ExecuteScript("arguments[0].click(); ", element);
        }
    }
}
