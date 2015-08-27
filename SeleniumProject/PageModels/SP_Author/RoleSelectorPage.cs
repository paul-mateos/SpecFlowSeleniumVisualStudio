using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SP_Automation.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_Automation.PageModels.SP_Author
{
    public class RoleSelectorPage : BasePage
    {
        By Title = By.Id("kWindow0_wnd_title");
        By Find = By.XPath("//div[@id='kWindow0']//table/tbody/tr/td[2]/input");
        

        public RoleSelectorPage(IWebDriver driver)
            : base(driver)
        {
            WebDriverWait wait;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Properties.Settings.Default.WaitTime));
            wait.Until(ExpectedConditions.ElementExists(Title));
        }

        public void ConfirmRoleSelector()
        {
            IWebElement rolePage = UICommon.GetElement(Title, d);
            if (!rolePage.Displayed)
            {
                throw new Exception("Role Selector failed to open");
            }
            Assert.IsTrue(rolePage.Displayed);
        }
        public void searchRole(string rolename)
        {
            UICommon.SetValue(Find, rolename, d);
        }
    }
}
