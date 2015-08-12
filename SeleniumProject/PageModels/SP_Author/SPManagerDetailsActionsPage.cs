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
    class SPManagerDetailsActionsPage : BasePage
    {
        By SaveBtn = By.XPath("//button[@title='Save']");
        By DetailsandActions = By.XPath("//form[@name='usrForm']//div[1]/ul/li/a");
        By Properties = By.XPath("//form[@name='usrForm']//div[1]/ul/li/div/a[1]");
        By Rolemembership = By.XPath("//form[@name='usrForm']//div[1]/ul/li/div/a[2]");
        By TrainingObjectives = By.LinkText("Training objectives");
        By Readers = By.LinkText("Readers");
        By Writers = By.LinkText("Writers");
        By Notifications = By.LinkText("Notifications");
        By CustomProperties = By.LinkText("Custom properties");


        WebDriverWait wait;
        public SPManagerDetailsActionsPage(IWebDriver driver)
            : base(driver)
        {
         /*   wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Properties.Settings.Default.WaitTime));

            wait.Until(ExpectedConditions.ElementExists(SaveBtn)); */
        }

        public void clickSave()
        {
            UICommon.ClickButton(SaveBtn, d);
        }

        public void clickDetailsandActions()
        {
            UICommon.ClickLink(DetailsandActions, d);

        }

        public void clickRolemembership()
        {
            UICommon.ClickLink(Rolemembership, d);
        }
    }
}
