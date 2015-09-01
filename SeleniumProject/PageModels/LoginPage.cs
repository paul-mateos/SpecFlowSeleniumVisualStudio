﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SP_Automation.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_Automation.PageModels
{
    class LoginPage : BasePage
    {
        IWebDriver d;
        public LoginPage(IWebDriver driver)
            : base(driver)
        {
            this.d = driver; 
            //Wait for title to be displayed 
            System.Diagnostics.Debug.WriteLine("wait4title");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Properties.Settings.Default.WaitTime));
            wait.Until((d) => {
                System.Diagnostics.Debug.WriteLine("testTitle:" + d.Title);
                return d.Title.Contains("Login : SupportPoint"); });
            System.Diagnostics.Debug.WriteLine("done");
        }

        //Search Criteria
        By loginButton = By.XPath(" //button[(@type='submit' and @name='login')]");

        public void SetUserName(string username)
        {
            UICommon.SetValue(By.Id("UserName"), username, d);
        }

        public void SetPassword(string password)
        {
            UICommon.SetValue(By.Id("Password"), password, d);
        }

        public void ClickLogOnButton()
        {
            UICommon.ClickButton(loginButton, d);

        }


        public void ConfirmWarningMessage(string warningMessage)
        {
            d.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            IList<IWebElement> messages = d.FindElements(By.Id("qtip-Warning-content"));
            if (messages.Count != 0)
            {
                IWebElement elem = UICommon.GetElement(By.Id("qtip-Warning-content"), d);
                if(elem.Text.Equals(warningMessage))
                {
                    UICommon.ClickButton(By.Id("okTitle"), d);
                }
               
            }
        }

        
        internal void GetObjValue()
        {
            throw new NotImplementedException();
        }

        internal void ClickLoginAs()
        {
            d.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            IReadOnlyCollection<IWebElement> showLoginAs = d.FindElements(By.Id("showLoginAs"));
            if (showLoginAs.Count != 0)
            {
                showLoginAs.ElementAt(0).Click();
            }

        }

        internal void SwitchToNewBrowserWithTitle(string p)
        {
            UICommon.SwitchToNewBrowserWithTitle(d, "Home");
        }
    }
}
