using OpenQA.Selenium;
using OrangeHRMFramework.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMFramework.ComponentHelper
{
    public class TextBoxHelper
    {
        public static void SendKeys(string value, By Locator )
        {
            IWebElement element =  GenericHelper.GetWebElement(Locator);
            element.SendKeys(value);
        }
    }
}
