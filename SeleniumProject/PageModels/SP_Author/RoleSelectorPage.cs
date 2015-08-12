using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SP_Automation.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_Automation.PageModels
{
    class RoleSelectorPage : BasePage
    {
        By Find = By.XPath("//div[@id='kWindow0']//table/tbody/tr/td[2]/input");

        WebDriverWait wait;
        public RoleSelectorPage(IWebDriver driver)
            : base(driver)
        {
            /*   wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Properties.Settings.Default.WaitTime));

               wait.Until(ExpectedConditions.ElementExists(SaveBtn)); */
        }

        public void searchRole(string rolename)
        {
            UICommon.SetValue(Find, rolename, d);
        }
    }
}
