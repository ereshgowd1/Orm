using OpenQA.Selenium;
using OrangeHRMFramework.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMFramework.ComponentHelper
{
    public class ScreenShotHelper
    {
        public static void TakeScreenShot(string filename = "Screen")
        {
            Screenshot sc = ((ITakesScreenshot)ObjectRepository.Driver).GetScreenshot();
            if (filename.Equals("Screen"))
            {
                string name = filename + DateTime.UtcNow.ToString("yyyy-MM-dd-hh-ss") + ".jpeg";
                sc.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);
                return;
            }
            sc.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);
        }
    }
}
