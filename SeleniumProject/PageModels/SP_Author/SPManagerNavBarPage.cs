using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.PageModels.SP_Author
{
   public class SPManagerNavBarPage : BasePage
    {
        //Search Criteria
        By Documents = By.LinkText("Documents");
        By Images = By.LinkText("Images");
        By Users = By.LinkText("Users");
        By Roles = By.LinkText("Roles");
        By WorkFlow = By.LinkText("Workflow");
        By Reports = By.LinkText("Reports");
        By Admin = By.LinkText("Admin");
        By Actions = By.XPath("//div[@id='navbar-main']/ul[@title='Action']/li");
       
       
        public SPManagerNavBarPage(IWebDriver driver)
            : base(driver)
        {
             
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
 
       public void ClickWorkflow()
        {
            d.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            UICommon.ClickLink(WorkFlow, d);

        }
 
        public void ClickAdmin()
        {
            d.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            UICommon.ClickLink(Admin, d);

        }

    }
}
