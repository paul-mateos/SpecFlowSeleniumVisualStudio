using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.PageModels
{
    public abstract class BasePage
    {
       static protected IWebDriver d;
       System.Configuration.Configuration config =
          ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None) as Configuration;
       public static int waitsec = Int32.Parse(ConfigurationManager.AppSettings.Get("WaitSec"));
        
        public BasePage(IWebDriver driver)
        {
            d = driver;
            d.SwitchTo().DefaultContent();
            d.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
        }


    }
}
