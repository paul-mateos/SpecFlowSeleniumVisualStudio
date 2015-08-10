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
   public class SPManagerNavBarPage : BasePage
    {
        //Search Criteria
        By Documents = By.LinkText("Documents");
        By Images = By.LinkText("Images");
        By Users = By.LinkText("Users");
        By Roles = By.LinkText("Roles");
        By WorkFlow = By.LinkText("WorkFlow");
        By Reports = By.LinkText("Reports");
        By Actions = By.ClassName("dropdown-toggle");
       
        WebDriverWait wait;
        public SPManagerNavBarPage(IWebDriver driver)
            : base(driver)
        {
        /*   wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Properties.Settings.Default.WaitTime));
             
           wait.Until(ExpectedConditions.ElementExists(Users)); */
        }

        public void ClickActions()
        {
            UICommon.ClickButton(Actions, d);

        }

        public void ClickUsers()
        {
            d.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            UICommon.ClickButton(Users, d);

        }
 
    }
}
