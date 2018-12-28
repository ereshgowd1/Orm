using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMFramework.ComponentHelper
{
    //[TestClass]
    public class ExtentReportHelper
    {
        public static ExtentReports extent;
        public static ExtentTest test;

        //[TestInitialize]
        public static void StartReport(string Testname)
        {
            var htmlReporter = new ExtentHtmlReporter("extentReport.html");
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Operating System", "Windows 10");
            extent.AddSystemInfo("Host Name", "GOWDARED11");
            extent.AddSystemInfo("Browser", "Google Chrome");
            test = extent.CreateTest(Testname);
                             
        }
    }
}
