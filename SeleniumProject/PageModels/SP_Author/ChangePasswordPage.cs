using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Commons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumProject.PageModels.SP_Author
{
    public class ChangePasswordPage : BasePage
    {
        By Title = By.XPath("//div/span[(@id='kWindow0_wnd_title' and text() = 'Change password')]");
        By OldPassword = By.XPath("//input[@name='oldPassword']");
        By Password = By.XPath("//input[@name='password']");
        By ConfirmedPassword = By.XPath("//input[@name='confirmedPassword']");
        By SaveBtn = By.XPath("//div[@id='kWindow0']//button[@title='Save']");




        public ChangePasswordPage(IWebDriver driver)
            : base(driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitsec));
            wait.Until(ExpectedConditions.ElementExists(Title));
        }

        public void ConfirmChangePassword()
        {
            IWebElement rolePage = UICommon.GetElement(Title, d);
            if (!rolePage.Displayed)
            {
                throw new Exception("Change password failed to open");
            }
            Assert.IsTrue(rolePage.Displayed);
        }

        public void SetOldPassword(string password)
        {
            UICommon.SetValue(OldPassword, password, d);
        }

        public void SetPassword(string password)
        {
            UICommon.SetValue(Password, password, d);
        }

        public void SetConfirmPassword(string confirmpassword)
        {
            UICommon.SetValue(ConfirmedPassword, confirmpassword, d);
        }

        public void ClickSaveButton()
        {
            UICommon.ClickButton(SaveBtn,d);
            UICommon.confirmToastSuccessMessage("Password saved.", d);
        }



        
    }
}

