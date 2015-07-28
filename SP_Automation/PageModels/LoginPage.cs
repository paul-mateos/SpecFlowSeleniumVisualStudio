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
            UICommon.ClickButton(By.XPath("//button[@type='submit']"), d);

        }


        public void ConfirmWarningMessage(string warningMessage)
        {
            d.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            IList<IWebElement> messages = d.FindElements(By.Id("qtip-Warning-content"));
            if (messages.Count != 0)
            {
                IWebElement elem = UICommon.GetElement(By.Id("qtip-Warning-content"), d);
                if(elem.Text == warningMessage)
                {
                    UICommon.ClickButton(By.Id("okTitle"), d);
                }
               
            }
        }



        internal void GetObjValue()
        {
            throw new NotImplementedException();
        }
    }
}
