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
        By deleteMessagePopup = By.XPath("//div[(@id='kWindow0')]/div[contains(text(),'Delete')]");
        By refreshMessagePopup = By.XPath("//div[(@id='kWindow0')]/div[contains(text(),'refresh')]");
        By okButton = By.XPath("//button[@title='OK']");
        By confirmRemoveButton = By.XPath("//div[@id='kWindow0']//button[@title='Remove']");
        By confirmDeleteButton = By.XPath("//div[@id='kWindow0']//button[@title='Delete']");
        By confirmRefreshButton = By.XPath("//div[@id='kWindow0']//button[@title='Refresh now']");


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
            elem.FindElement(confirmRemoveButton).Click();
            Thread.Sleep(3000);
        }

        public void ConfirmDeleteMessage()
        {
            IWebElement elem = UICommon.GetElement(deleteMessagePopup, d);
            elem.FindElement(confirmDeleteButton).Click();
            Thread.Sleep(3000);
        }
        public void ConfirmRefreshMessage()
        {
            IWebElement elem = UICommon.GetElement(refreshMessagePopup, d);
            //elem.FindElement(okButton).Click();
            elem.FindElement(confirmRefreshButton).Click();
            Thread.Sleep(6000);
        }

        
    }
}
