using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Commons;
using System;

namespace SeleniumProject.PageModels
{
    class UserRolemembershipPage : BasePage
    {
        By AddUsertoRoleBtn = By.XPath("//button[@title='Add user to role(s)']");

        WebDriverWait wait;
        public UserRolemembershipPage(IWebDriver driver)
            : base(driver)
        {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Properties.Settings.Default.WaitTime));

                wait.Until(ExpectedConditions.ElementExists(AddUsertoRoleBtn)); 
        }

        public void clickAddUsertoRole()
        {
            UICommon.ClickButton(AddUsertoRoleBtn, d);
        }
    }
}
