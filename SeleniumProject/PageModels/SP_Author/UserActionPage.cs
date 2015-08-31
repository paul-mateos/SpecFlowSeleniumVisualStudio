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
    public class UserActionPage : BasePage
    {
        
        By newUser = By.LinkText("New user");
        By ImportUsers = By.LinkText("Import users");
        By ExportUsers = By.LinkText("Export Users");
        By ChangeLanguage = By.LinkText("Change interface language");

        By BackgroundTask = By.LinkText("Background tasks");
        By Close = By.LinkText("Close");


        WebDriverWait wait;
        public UserActionPage(IWebDriver driver)
            : base(driver)
        {
           wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Properties.Settings.Default.WaitTime));
             
          
        }

        public void ClickNewUser()
        {
            wait.Until(ExpectedConditions.ElementExists(newUser));
            UICommon.ClickButton(newUser, d);

        }

        public void clickToClose()
        {
            UICommon.ClickButton(Close,d);
        }

       
    }
}
