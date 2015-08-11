﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SP_Automation.PageModels;
using SP_Automation.PageModels.SP_Viewer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SP_Automation.Modules
{
    public class LogIn : BaseWebDriverModule
    {
        
        public LogIn(IWebDriver d) : base(d) { }

        public void Login(String name, String password)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.SetUserName(name);
            loginPage.SetPassword(password);
            loginPage.ClickLogOnButton();
            //loginPage.GetObjValue();
            String warningMessage = "You are already logged in.\r\nAny unsaved data will be lost.\r\nDo you wish to continue?\r\nContinue\r\nCancel";
            loginPage.ConfirmWarningMessage(warningMessage);
            HomePage homePage = new HomePage(driver);
            Assert.IsTrue(homePage.GetWelcomeTitleDisplayProperty());
        }

        public void LogOut()
        {
            NavBarPage nav = new NavBarPage(driver);
            nav.ClickUserLogOff();

            LogoutPage p = new LogoutPage(driver);
            p.LogOut();
        }

        public void LogOutAndCloseApp()
        {
            NavBarPage nav = new NavBarPage(driver);
            nav.ClickUserLogOff();
            Thread.Sleep(5000);
            LogoutPage p = new LogoutPage(driver);
            p.LogOutAndCloseApp();
        }
    }
}
