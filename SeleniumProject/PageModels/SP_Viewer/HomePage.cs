﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.PageModels.SP_Viewer
{
    class HomePage : BasePage
    {
        //IWebDriver d;
        public HomePage(IWebDriver driver)
            : base(driver)
        {
            d = driver;
            //Wait for title to be displayed 
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Properties.Settings.Default.WaitTime));
            wait.Until((D) => { return d.Title.Contains("Home : SupportPoint"); }); 
        }

        public void ClickLoginButton()
        {
            UICommon.ClickButton(By.Id("login_btn"), d);

        }


        internal void ClickLogOutButton()
        {
            UICommon.ClickButton(By.Id("logout_btn"), d);
        }

        internal void ClickFolderNavButton()
        { 
            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(Properties.Settings.Default.WaitTime));
           // wait.Until(drv => drv.FindElement(By.XPath("//div[@class='loadmask']")));
            wait.Until(drv => drv.FindElement(By.Id("Folder")));
            UICommon.ClickButton(By.Id("Folder"), d);
        }

        internal bool GetWelcomeTitleDisplayProperty()
        {
            IWebElement elem = UICommon.GetElement(By.XPath("//div[@class='active tab-pane']/p/span/img[contains(@alt,'SupportPoint Image')]"),d);
            return elem.Displayed;
        }

    }
}
