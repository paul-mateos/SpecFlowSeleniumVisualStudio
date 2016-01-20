using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.PageModels.SP_Viewer
{
    class NavBarPage : BasePage
    {
        
        By homeMenu = By.Id("Home");
        By folderMenu = By.Id("Folder");
        By backMenu = By.Id("icon_backbtn");
        By forwardMenu = By.Id("icon_nextbtn");
       // By contextHelpMenu = By.Id("icon_nextbtn");
        By moreMenu = By.Id("more_menu");

        //More menu
        //By User = By.LinkText("User");
        By User_LogOff = By.LinkText("Log off");

        //Notification Menu
        By notification = By.LinkText("Notification list");
        By notificationCentre = By.LinkText("Notifications");

        //SP Manager
        By SPManagerBtn = By.Id("AuthorLauncher");

        WebDriverWait wait;

        public NavBarPage(IWebDriver driver)
            : base(driver)
        {
           wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitsec));
             
           wait.Until(ExpectedConditions.ElementExists(homeMenu)); 
        }

        public void ClickHomeButton()
        {
            UICommon.ClickButton(homeMenu, d);

        }


        public void ClickMoreButton()
        {
            UICommon.ClickButton(moreMenu, d);
        }

        public void ClickFolderButton()
        {

            UICommon.ClickButton(folderMenu, d);
        }

      
        public void ClickNotification()
        {
            try
            {
                if (!d.FindElement(notificationCentre).Displayed)
                {
                    UICommon.ClickButton(moreMenu, d);
                }
            }
            catch (NoSuchElementException)
            {
                UICommon.ClickButton(moreMenu, d);
            }

            try
            {
                if (!d.FindElement(notification).Displayed)
                {
                    UICommon.ClickButton(notificationCentre, d);
                }
            }
            catch (NoSuchElementException)
            {
                UICommon.ClickButton(notificationCentre, d);
            }

            UICommon.ClickButton(notification, d);

        }

        public void ClickUserLogOff()
        {
           
            UICommon.ClickButton(moreMenu, d);
            UICommon.ClickLink(By.LinkText("User"), d);// (User, d);
            UICommon.ClickLink(By.LinkText("Log off"), d); //User_LogOff, d);

        }

        public void ClickSPManagerButton()
        {

            UICommon.ClickButton(SPManagerBtn, d);
        }
       
    }
}
