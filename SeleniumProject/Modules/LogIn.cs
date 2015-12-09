using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumProject.Commons;
using SeleniumProject.Environments;
using SeleniumProject.PageModels;
using SeleniumProject.PageModels.SP_Author;
using SeleniumProject.PageModels.SP_Viewer;
using SeleniumProject.Tests;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumProject.Modules
{
    public class LogIn : BaseWebDriverModule
    {
        public static BrowserType browser;
        public LogIn(IWebDriver d) : base(d) 
        {
            System.Configuration.Configuration config =
                      ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None) as Configuration;

            browser = (BrowserType) Enum.Parse(typeof(BrowserType), ConfigurationManager.AppSettings.Get("Browser"));

        
        }

        public void Login(String name, String password)
        {
            //if (Properties.Settings.Default.Browser.ToString() == "NodeWebkit")
            //{
                LoginPage loginPage = new LoginPage(driver);
                loginPage.ClickLoginAs();
                loginPage.SetUserName(name);
                loginPage.SetPassword(password);
                string currentWindow = driver.CurrentWindowHandle;
                loginPage.ClickLogOnButton();
                String warningMessage = "You are already logged in.\r\nAny unsaved data will be lost.\r\nDo you wish to continue?\r\nContinue\r\nCancel";
                loginPage.ConfirmWarningMessage(warningMessage);
                warningMessage = "The license limit has been exceeded. Do you want to continue?";
                loginPage.ConfirmLicenseMessage(warningMessage);
                if (browser.ToString() == "NodeWebkit")
                {
                    SupportPoint.waitForAjaxLoading(); 
                    loginPage.SwitchToNewPageWithTitle("Home");
                    HomePage homePage = new HomePage(driver);
                    SupportPoint.LogIn.waitForInfoMessageClose();
                }
                else
                {
                    SupportPoint.waitForAjaxLoading();
                    loginPage.SwitchToNewBrowserWithTitle("Home", currentWindow);
                    HomePage homePage = new HomePage(driver);
                    SupportPoint.LogIn.waitForInfoMessageClose();
                }
        }

        public void LogOut()
        {
            NavBarPage nav = new NavBarPage(driver);
            nav.ClickUserLogOff();

            LogoutPage p = new LogoutPage(driver);
            p.LogOut();
        }

        public void CloseSPManager()
        {
            SupportPoint.SPManagerNav.ClickActions();
            SupportPoint.SPManagerActionsPage.SelectFromActionsList("Close");
            Thread.Sleep(1000);
        }
        public void LogOutAndCloseApp()
        {
           
            NavBarPage nav = new NavBarPage(driver);
            nav.ClickUserLogOff();
            Thread.Sleep(1000);
            LogoutPage p = new LogoutPage(driver);
            p.LogOutAndCloseApp();
        }

        public void waitForInfoMessageClose()
        {
            try
            {
                UICommon.confirmToastInfoMessage("Welcome", driver);
            }
            catch { }
        }
    }
}
