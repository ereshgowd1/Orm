using OrangeHRMFramework.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMFramework.ComponentHelper
{
    public class PageHelper
    {
        public static string PageTitle()
        {
            return ObjectRepository.Driver.Title;
        }
    }
}
