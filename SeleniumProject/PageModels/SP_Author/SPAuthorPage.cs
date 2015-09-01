using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SP_Automation.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SP_Automation.PageModels.SP_Author
{
   public class SPAuthorPage : BasePage
    {
        //Search Criteria
        
        By saveButton = By.CssSelector("button[data-automation-id='doc-details-actions-save']");
        By RemoveButton = By.CssSelector("button[data-automation-id='doc-details-actions-remove']");
        By browseButton = By.XPath("//button[@title='Browse']");
        By removalMessagePopup = By.XPath("//div[(@id='kWindow0')]/div[contains(text(),'Remove')]");
        By okButton = By.XPath("//button[@title='OK']");


        public SPAuthorPage(IWebDriver driver)
            : base(driver)
        {

        }

        public void ClickSaveButton()
        {
            UICommon.ClickButton(saveButton, d);
            Thread.Sleep(5000);
        }

        public void ClickBrowseButton()
        {
            UICommon.ClickButton(browseButton, d);
        }

        public void ClickRemoveButton()
        {
            UICommon.ClickButton(RemoveButton, d);
        }

        public void ConfirmRemovalMessage()
        {
            IWebElement elem = UICommon.GetElement(removalMessagePopup, d);
            elem.FindElement(okButton).Click();
            Thread.Sleep(3000);
        }
    }
}
