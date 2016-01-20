using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Commons;
using SeleniumProject.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.PageModels.SP_Viewer
{
    public class HomePage : BasePage
    {
        //Search By
        By loginButton = By.Id("login_btn");
        By logoutButton = By.Id("logout_btn");
        By folderButton = By.Id("Folder");
        By CancelBtn = By.XPath("//div[@class='qtip-content']//button[text()='Cancel']");

        public HomePage(IWebDriver driver)
            : base(driver)
        {
            //Wait for title to be displayed 
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitsec));
            wait.Until((D) => { return d.Url.Contains("/Viewer/"); }); 
        }

        public void ClickLoginButton()
        {
            UICommon.ClickButton(loginButton, d);

        }


        public void ClickLogOutButton()
        {
            UICommon.ClickButton(logoutButton, d);
        }

        public void ClickFolderNavButton()
        { 
            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            wait.Until(drv => drv.FindElement(folderButton)).Click();

        }

        internal bool GetWelcomeTitleDisplayProperty()
        {
            IWebElement elem = UICommon.GetElement(By.XPath("//div[@class='active tab-pane']/p/span/img[contains(@alt,'SupportPoint Image')]"),d);
            return elem.Displayed;
        }

        public void clickCancel()
        {
            UICommon.ClickButton(CancelBtn, d);
        }
    }
}
