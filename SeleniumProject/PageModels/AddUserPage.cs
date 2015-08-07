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
    class AddUserPage : BasePage
    {

        By SaveBtn = By.XPath("//button[@title='Save']");
        By UserName = By.Name("userName");
        By FirstName = By.Name("firstName");
        By LastName = By.Name("lastName");
        By Email = By.Name("email");
        By Password = By.Name("password");
        By ConfirmPassword = By.Name("confirmedPassword");


        WebDriverWait wait;
        public AddUserPage(IWebDriver driver)
            : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Properties.Settings.Default.WaitTime));

            wait.Until(ExpectedConditions.ElementExists(UserName));
        }

        public void fillIn(string name, string firstname, string lastname, string email, string password, string verifypassword)
        {
            UICommon.SetValue(UserName, name, d);
            UICommon.SetValue(FirstName, firstname, d);
            UICommon.SetValue(LastName, lastname, d);
            UICommon.SetValue(Email, email, d);
            UICommon.SetValue(Password, password, d);
            UICommon.SetValue(ConfirmPassword, verifypassword, d);

        }

        public void clickSave()
        {
            UICommon.ClickButton(SaveBtn, d);
        }
    }
}
