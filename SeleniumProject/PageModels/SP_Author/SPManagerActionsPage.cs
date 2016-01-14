using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumProject.PageModels
{
    public class SPManagerActionsPage : BasePage
    {
        
        By newUser = By.LinkText("New user");
        By ImportUsers = By.LinkText("Import users");
        By ExportUsers = By.LinkText("Export Users");
        By ChangeLanguage = By.LinkText("Change interface language");
        By BackgroundTask = By.LinkText("Background tasks");
        By Close = By.LinkText("Close");
        By Paul = By.LinkText("paul");
        By NewWorkflow = By.LinkText("New workflow");
        By NewRole = By.LinkText("New Role");
        By ChangeInterfaceLanguage = By.LinkText("Change interface language");

        public SPManagerActionsPage(IWebDriver driver)
            : base(driver)
        {
           
        }
      
        public void SelectFromActionsList(string actions)
        {
            switch (actions)
            {
                case "New workflow":
                    UICommon.ClickLink(NewWorkflow, d);
                    break;
                case "New user":
                    UICommon.ClickLink(newUser, d);
                    break;
                case "Change interface language":
                    UICommon.ClickLink(ChangeInterfaceLanguage, d);
                    break;
                case "Background tasks":
                    UICommon.ClickLink(BackgroundTask, d);
                    break;
                case "New Role":
                    UICommon.ClickLink(NewRole, d);
                    break;
                case "Close":
                    UICommon.ClickLink(Close, d);
                    break;
                default:
                    break;
            }
            Thread.Sleep(1000);
        }
       
    }
}
