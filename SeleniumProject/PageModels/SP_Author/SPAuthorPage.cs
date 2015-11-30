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
        By addRolesToRoleButton = By.XPath("//button[@title='Add role(s) to role']");
        By addUsersToRoleButton = By.XPath("//button[@title='Add user(s) to role']");
        By addUserToRolesButton = By.XPath("//button[@title='Add user to role(s)']");
        By addRoleToReadersButton = By.XPath("//button[@title='Add role to readers']");
        By addUserToReadersButton = By.XPath("//button[@title='Add user to readers']");
        By addRoleToWritersButton = By.XPath("//button[@title='Add role to writers']");
        By addUserToWritersButton = By.XPath("//button[@title='Add user to writers']");

        By addRolesToReadersButton = By.XPath("//button[@title='Add Role(s) to readers']");
        By addrolesToReadersButton = By.XPath("//button[@title='Add role(s) to readers']");
        By addUsersToReadersButton = By.XPath("//button[@title='Add user(s) to readers']");
        By addRolesToWritersButton = By.XPath("//button[@title='Add role(s) to writers']");
        By addUsersToWritersButton = By.XPath("//button[@title='Add user(s) to writers']");
        By addnotificationToRoleButton = By.XPath("//button[@title='Add notification to role']");
        By addnotificationToRolePopupButton = By.XPath("//div[@id='kWindow0']/.//button[text()='Add notification to role']");
        

        By removeRoleFromRolesButton = By.XPath("//button[@title='Remove role from role(s)']");
        By removeRolesFromRoleButton = By.XPath("//button[@title='Remove role(s) from role']");
        By removeUsersFromRoleButton = By.XPath("//button[@title='Remove user(s) from role']");
        By removeUsersFromReadersButton = By.XPath("//button[@title='Remove user(s) from readers']");
        By removeUsersFromWritersButton = By.XPath("//button[@title='Remove user(s) from writers']");
        By removeRolesFromReadersButton = By.XPath("//button[@title='Remove role(s) from readers']");
        By removeRolesFromWritersButton = By.XPath("//button[@title='Remove role(s) from writers']");
        By removeNotificationsFromRoleButton = By.XPath("//button[@title='Remove notifications from role']");
        
        By removeUserFromRolesButton = By.XPath("//button[@title='Remove user from role(s)']");

        By removalMessagePopup = By.XPath("//div[(@id='kWindow0')]/div[contains(text(),'Remov')]");
        By deleteMessagePopup = By.XPath("//div[(@id='kWindow0')]/div[contains(text(),'Delete')]");
        By refreshMessagePopup = By.XPath("//div[(@id='kWindow0')]/div[contains(text(),'refresh')]");
        By okButton = By.XPath("//button[@title='OK']");
        By confirmRemoveButton = By.XPath("//div[@id='kWindow0']//button[@title='Remove']");
        By confirmDeleteButton = By.XPath("//div[@id='kWindow0']//button[@title='Delete']");
        By confirmRefreshButton = By.XPath("//div[@id='kWindow0']//button[@title='Refresh now']");

        By roleTable = By.XPath("//table[@role='grid']");
        By rolesinthisroleTable = By.XPath("//shr-role-grid-drct[@header-title='Roles in this role']/.//table");
        By usersinthisroleTable = By.XPath("//shr-user-grid-drct[@header-title='Users in this role']/.//table");
        //By rolesthatcanreadTable = By.XPath("//shr-role-grid-drct[@header-title='Roles that can read the details of this role:']/.//table");
        By rolesthatcanTable = By.XPath("//shr-role-grid-drct[@source='data.edit.roles']/.//table");
        By usersthatcanTable = By.XPath("//shr-user-grid-drct[@source='data.edit.users']/.//table");
        //By usersthatcanreadTable = By.XPath("//shr-user-grid-drct[@header-title='Users that can read the details of this role:']/.//table");
        By rolehasnotificationTable = By.XPath("//shr-notification-grid-drct[@header-title='This role has the following notification(s):']/.//table");
        

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

        public void ClickAddRolesToRoleButton()
        {
            UICommon.ClickButton(addRolesToRoleButton, d);
        }

        public void ClickAddUsersToRoleButton()
        {
            UICommon.ClickButton(addUsersToRoleButton, d);
        }

        public void ClickAddUserToRolesButton()
        {
            UICommon.ClickButton(addUserToRolesButton, d);
        }

        
        public void ClickAddRoleToReadersButton()
        {
            UICommon.ClickButton(addRoleToReadersButton, d);
        }

        public void ClickAddrolesToReadersButton()
        {
            UICommon.ClickButton(addrolesToReadersButton, d);
        }

        public void ClickAddRolesToReadersButton()
        {
            UICommon.ClickButton(addRolesToReadersButton, d);
        }

        public void ClickAddUsersToReadersButton()
        {
            UICommon.ClickButton(addUsersToReadersButton, d);
        }

        public void ClickAddUsersToWritersButton()
        {
            UICommon.ClickButton(addUsersToWritersButton, d);
        }

        public void ClickAddUserToReadersButton()
        {
            UICommon.ClickButton(addUserToReadersButton, d);
        }

        public void ClickAddRoleToWritersButton()
        {
            UICommon.ClickButton(addRoleToWritersButton, d);
        }

        public void ClickAddRolesToWritersButton()
        {
            UICommon.ClickButton(addRolesToWritersButton, d);
        }

        public void ClickAddNotificationToRoleButton()
        {
            UICommon.ClickButton(addnotificationToRoleButton, d);
        }

        public void ClickAddNotificationToRolePopupButton()
        {
            UICommon.ClickButton(addnotificationToRolePopupButton, d);
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

        public void ClickRemoveRolesFromRoleButton()
        {
            UICommon.ClickButton(removeRolesFromRoleButton, d);
            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            wait.Until(driver => !d.FindElement(removeRolesFromRoleButton).Enabled);
            Thread.Sleep(1000);
        }

        public void ClickRemoveUsersFromRoleButton()
        {
            UICommon.ClickButton(removeUsersFromRoleButton, d);
            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            wait.Until(driver => !d.FindElement(removeUsersFromRoleButton).Enabled);
            Thread.Sleep(1000);
        }


        public void ClickRemoveUsersFromReadersButton()
        {
            UICommon.ClickButton(removeUsersFromReadersButton, d);
            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            wait.Until(driver => !d.FindElement(removeUsersFromReadersButton).Enabled);
            Thread.Sleep(1000);
        }

        public void ClickRemoveUsersFromWritersButton()
        {
            UICommon.ClickButton(removeUsersFromWritersButton, d);
            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            wait.Until(driver => !d.FindElement(removeUsersFromWritersButton).Enabled);
            Thread.Sleep(1000);
        }

        public void ClickRemoveRolesFromReadersButton()
        {
            UICommon.ClickButton(removeRolesFromReadersButton, d);
            //WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            //wait.Until(driver => !d.FindElement(removeRolesFromReadersButton).Enabled);
            Thread.Sleep(1000);

        }

        public void ClickRemoveRolesFromWritersButton()
        {
            UICommon.ClickButton(removeRolesFromWritersButton, d);
            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            wait.Until(driver => !d.FindElement(removeRolesFromWritersButton).Enabled);
            Thread.Sleep(1000);

        }

        public void ClickRemoveNotificationsFromRoleButton()
        {
            UICommon.ClickButton(removeNotificationsFromRoleButton, d);
            //WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            //wait.Until(driver => !d.FindElement(removeNotificationsFromRoleButton).Enabled);
            Thread.Sleep(1000);

        }

        public void ClickRemoveUserFromRolesButton()
        {
            UICommon.ClickButton(removeUserFromRolesButton, d);
            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            wait.Until(driver => !d.FindElement(removeUserFromRolesButton).Enabled);
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



        public void ClickNotificationPeriod(string notificationPeriod)
        {
            UICommon.SelectCheckbox(By.XPath("//div[@id='kWindow0']/.//input[@id='" + notificationPeriod.ToLower() + "']"), d);
        }

        public void ClickRecord(string lookUpColumn, string searchText, string tableName)
        {
            IWebElement searchTable;
            switch (tableName)
            {
                case "RoleTable":
                    searchTable = UICommon.GetSearchResultTable(roleTable, d);
                    break;
                case "RolesinthisroleTable":
                    searchTable = UICommon.GetSearchResultTable(rolesinthisroleTable, d);
                    break;
                case "UsersinthisroleTable":
                    searchTable = UICommon.GetSearchResultTable(usersinthisroleTable, d);
                    break;
                case "RolesthatcanTable":
                    searchTable = UICommon.GetSearchResultTable(rolesthatcanTable, d);
                    break;
                case "UsersthatcanTable":
                    searchTable = UICommon.GetSearchResultTable(usersthatcanTable, d);
                    break;
                case "RoleHasNotificationTable":
                    searchTable = UICommon.GetSearchResultTable(rolehasnotificationTable, d);
                    break;
                default:
                    throw new Exception("Invalid Role table");

            }

            Table table = new Table(searchTable);
            table.ClickCellValue(lookUpColumn, searchText, lookUpColumn, d);
        }

       

      
    }
}
