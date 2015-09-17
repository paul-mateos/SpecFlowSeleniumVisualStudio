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
   public class SPManagerNavBarPage : BasePage
    {
        //Search Criteria
        By Documents = By.LinkText("Documents");
        By Images = By.LinkText("Images");
        By Users = By.LinkText("Users");
        By Roles = By.LinkText("Roles");
        By WorkFlow = By.LinkText("WorkFlow");
        By Reports = By.LinkText("Reports");
        By Admin = By.LinkText("Admin");
        By Actions = By.ClassName("dropdown-toggle");
       
       
        public SPManagerNavBarPage(IWebDriver driver)
            : base(driver)
        {
        /*   wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Properties.Settings.Default.WaitTime));
             
           wait.Until(ExpectedConditions.ElementExists(Users)); */
        }

        public void ClickActions()
        {
            UICommon.ClickLink(Actions, d);

        }

        public void ClickUsers()
        {
            d.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            UICommon.ClickLink(Users, d);

        }

        public void ClickImages()
        {
            d.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            UICommon.ClickLink(Images, d);

        }

        public void ClickRoles()
        {
            d.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            UICommon.ClickLink(Roles, d);

        }

        public void ClickAdmin()
        {
            d.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            UICommon.ClickLink(Admin, d);

        }

    }
}
