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
    class LogoutPage : BasePage
    {

        By LogOnAsAnotherUser = By.Id("commonConfirm");
        By LogOutAndClose = By.Id("otherButtonId");

        
        public LogoutPage(IWebDriver driver)
            : base(driver)
        {
            
            //Wait for title to be displayed 
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Properties.Settings.Default.WaitTime));
            wait.Until((d) => {
                return d.FindElement(LogOutAndClose).Displayed;
            });
     
        }

        public void LogOutAndCloseApp()
        {
            UICommon.ClickButton(LogOutAndClose, d);
        }

        public void LogOut()
        {
            UICommon.ClickButton(LogOnAsAnotherUser, d);
        } 

    }
}
