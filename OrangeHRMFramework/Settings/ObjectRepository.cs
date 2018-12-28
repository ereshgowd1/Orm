using OpenQA.Selenium;
using OrangeHRMFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMFramework.Settings
{
   public class ObjectRepository
    {
        public static IConfig Config { set; get;  }
        public static IWebDriver Driver { set; get; }
    }
}
