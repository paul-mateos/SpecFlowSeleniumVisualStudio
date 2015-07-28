using Microsoft.VisualStudio.TestTools.UnitTesting;
using SP_Automation.Commons;
using SP_Automation.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace SP_Automation.Tests
{
    [TestClass]
    public class LoginTest : BaseTest
    {
        public LoginTest()
        {

        }

        public void initBrowser()
        {
            //Log on to site as user.
            InitialPage initialPage = new InitialPage(driver);
            string BaseWindow = driver.CurrentWindowHandle; 
            UICommon.SwitchToNewBrowserWithTitle(driver, BaseWindow, "Login");
   
        }

        public void SuccessfulLogin(String name, String password)
        {
            LoginPage loginPage = new LoginPage(driver);

            
            loginPage.SetUserName(name);
            loginPage.SetPassword(password);
            loginPage.ClickLogOnButton();
            //loginPage.GetObjValue();
            HomePage homePage = new HomePage(driver);
            Assert.IsTrue(homePage.GetWelcomeTitleDisplayProperty());
        }



        [TestCategory("Regression")]
        [TestMethod]
        public void SuccessfulLogin()
        {
            SuccessfulLogin("Paul", "p");
            //loginPage.GetObjValue();
          //  HomePage homePage = new HomePage(driver);
     

        }

        public void LogOut()
        {
            NavBarPage nav = new NavBarPage(driver);
            nav.ClickUserLogOff();
        }

    }
}
