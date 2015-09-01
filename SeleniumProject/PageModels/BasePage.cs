using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_Automation.PageModels
{
    public abstract class BasePage
    {
       static protected IWebDriver d;
       static protected int waitsec = Properties.Settings.Default.WaitTime;
        public BasePage(IWebDriver driver)
        {
            d = driver;
            d.SwitchTo().DefaultContent();
            d.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
        }


    }
}
