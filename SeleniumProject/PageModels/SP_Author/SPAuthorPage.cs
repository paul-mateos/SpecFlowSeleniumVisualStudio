using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumProject.PageModels.SP_Author
{
   public class SPAuthorPage : BasePage
    {
        //Search Criteria
        
        By saveButton = By.CssSelector("button[data-automation-id='doc-details-actions-save']");
        By RemoveButton = By.CssSelector("button[data-automation-id='doc-details-actions-remove']");
        By browseButton = By.XPath("//button[@title='Browse']");
        By addUserButton = By.XPath("//button[@title='Add user(s)']");
        By addRoleButton = By.XPath("//button[@title='Add role(s)']");
       
       By addRoleToRolesButton = By.XPath("//button[@title='Add role to role(s)']");
        By addRoleToReadersButton = By.XPath("//button[@title='Add role to readers']");
        By addUserToReadersButton = By.XPath("//button[@title='Add user to readers']");
        By addRoleToWritersButton = By.XPath("//button[@title='Add role to writers']");
        By addUserToWritersButton = By.XPath("//button[@title='Add user to writers']");

        By addRolesToReadersButton = By.XPath("//button[@title='Add role(s) to readers']");
        By addUsersToReadersButton = By.XPath("//button[@title='Add user(s) to readers']");
        By addRolesToWritersButton = By.XPath("//button[@title='Add role(s) to writers']");
        By addUsersToWritersButton = By.XPath("//button[@title='Add user(s) to writers']");
       
        By removeRoleFromRolesButton = By.XPath("//button[@title='Remove role from role(s)']");
        By removeRoleFromReadersButton = By.XPath("//button[@title='Remove role(s) from readers']");

         By removalMessagePopup = By.XPath("//div[(@id='kWindow0')]/div[contains(text(),'Remov')]");
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
            UICommon.confirmToastSuccessMessage("Changes saved", d);
            
        }

        public void ClickBrowseButton()
        {
            UICommon.ClickButton(browseButton, d);
        }

        public void ClickRemoveButton()
        {
            UICommon.ClickButton(RemoveButton, d);
        }

        public void ClickAddUserButton()
        {
            UICommon.ClickButton(addUserButton, d);
        }

        public void ClickAddRoleButton()
        {
            UICommon.ClickButton(addRoleButton, d);
        }

        public void ClickAddRoleToRolesButton()
        {
            UICommon.ClickButton(addRoleToRolesButton, d);
        }

        public void ClickAddRoleToReadersButton()
        {
            UICommon.ClickButton(addRoleToReadersButton, d);
        }

        public void ClickAddRolesToReadersButton()
        {
            UICommon.ClickButton(addRolesToReadersButton, d);
        }

        public void ClickAddUserToReadersButton()
        {
            UICommon.ClickButton(addUserToReadersButton, d);
        }

        public void ClickAddRoleToWritersButton()
        {
            UICommon.ClickButton(addRoleToWritersButton, d);
        }

        public void ClickAddUserToWritersButton()
        {
            UICommon.ClickButton(addUserToWritersButton, d);
        }

        public void ClickRemoveRoleFromRolesButton()
        {
            UICommon.ClickButton(removeRoleFromRolesButton, d);

            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            wait.Until(driver => !d.FindElement(removeRoleFromRolesButton).Enabled);
            Thread.Sleep(1000);
 
        }

        public void ClickRemoveRoleFromReadersButton()
        {
            UICommon.ClickButton(removeRoleFromReadersButton, d);

            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            wait.Until(driver => !d.FindElement(removeRoleFromReadersButton).Enabled);
            Thread.Sleep(1000);

        }

        public void ConfirmRemovalMessage()
        {
            IWebElement elem = UICommon.GetElement(removalMessagePopup, d);
            elem.FindElement(confirmRemoveButton).Click();
            UICommon.confirmToastSuccessMessage("Changes saved", d);
        }

        public void ConfirmDeleteMessage()
        {
            IWebElement elem = UICommon.GetElement(deleteMessagePopup, d);
            elem.FindElement(confirmDeleteButton).Click();
            UICommon.confirmToastSuccessMessage("Changes saved", d);
        }
        public void ConfirmRefreshMessage()
        {
            IWebElement elem = UICommon.GetElement(refreshMessagePopup, d);
            elem.FindElement(confirmRefreshButton).Click();

        }


    }
}
