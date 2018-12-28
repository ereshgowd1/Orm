using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMFramework.ComponentHelper
{
    public class ButtonHelper
    {
        public static void BtnClick(By Locator)
        {
            IWebElement btn = GenericHelper.GetWebElement(Locator);
            btn.Click();
        }
    }
}
