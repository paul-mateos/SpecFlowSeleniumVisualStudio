using SeleniumProject.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.SP_Author
{
    [Binding]
    public sealed class SP_Author_Steps
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        [Given(@"I Navigate to the (.*) Page")]
        [When(@"I Navigate to the (.*) Page")]
        [Then(@"I Navigate to the (.*) Page")]
        public void GivenINavigateToTheManagementPage(string managePage)
        {
            switch(managePage)
            {
                case "Images":
                    SupportPoint.SPManagerNav.ClickImages();
                    SupportPoint.SwitchToPage("Image Management : SupportPoint");
                    break;
                case "Users":
                    SupportPoint.SPManagerNav.ClickUsers();
                    SupportPoint.SwitchToPage("User Management : SupportPoint");
                    break;
                case "Roles":
                    SupportPoint.SPManagerNav.ClickRoles();
                    SupportPoint.SwitchToPage("Role Management : SupportPoint");
                    break;
                case "Workflow":
                    SupportPoint.SPManagerNav.ClickWorkflow();
                    SupportPoint.SwitchToPage("Workflow Management : SupportPoint");
                    break;
                case "Admin":
                    SupportPoint.SPManagerNav.ClickAdmin();
                    SupportPoint.SwitchToPage("Administration : SupportPoint");
                    break;
                default:
                    throw new Exception("Invalid Page");
                  
            }
                
        }

        [Given(@"I am at (.*) page")]
        [When(@"I am at (.*) page")]
        [Then(@"I am at (.*) page")]
        public void GivenIAmAtTheManagementPage(string managementPage)
        {
            SupportPoint.IsCurrentBrowser(managementPage + " : SupportPoint");

        }

        [Given(@"I click on the Save Button")]
        [When(@"I click on the Save Button")]
        [Then(@"I click on the Save Button")]
        public void ThenIClickOnTheSaveButton()
        {
            SupportPoint.SPManagerDetailsActionsPage.clickSave();
        }

        [Given(@"I click on the Browse Button")]
        [When(@"I click on the Browse Button")]
        [Then(@"I click on the Browse Button")]
        public void ThenIClickOnTheBrowseButton()
        {
            SupportPoint.SPAuthorPage.ClickBrowseButton();
        }

        [Given(@"I Click on the Remove Button")]
        [When(@"I Click on the Remove Button")]
        [Then(@"I Click on the Remove Button")]
        public void WhenIClickOnTheRemoveButton()
        {
            //SupportPoint.ImageManagementPage.ClickRemoveButton();
            SupportPoint.SPAuthorPage.ClickRemoveButton();
        }

        [Given(@"I Click on the Add user Button")]
        [When(@"I Click on the Add user Button")]
        [Then(@"I Click on the Add user Button")]
        public void WhenIClickOnTheAddUserButton()
        {
            SupportPoint.SPAuthorPage.ClickAddUserButton();
        }

        [Given(@"I Click on the Add role Button")]
        [When(@"I Click on the Add role Button")]
        [Then(@"I Click on the Add role Button")]
        public void WhenIClickOnTheAddRoleButton()
        {
            SupportPoint.SPAuthorPage.ClickAddRoleButton();
        }

        [Given(@"I Click on the Delete Button")]
        [When(@"I Click on the Delete Button")]
        [Then(@"I Click on the Delete Button")]
        public void WhenIClickOnTheDeleteButton()
        {
            SupportPoint.SPManagerDetailsActionsPage.clickDelete();
        }

        [Given(@"I Confirm the Removal")]
        [When(@"I Confirm the Removal")]
        [Then(@"I Confirm the Removal")]
        public void ThenIConfirmTheRemoval()
        {
            SupportPoint.SPAuthorPage.ConfirmRemovalMessage();
        }

        [Given(@"I Confirm the Delete")]
        [When(@"I Confirm the Delete")]
        [Then(@"I Confirm the Delete")]
        public void ThenIConfirmTheDelete()
        {
            SupportPoint.SPAuthorPage.ConfirmDeleteMessage();
        }

        [Given(@"I Confirm the Refresh")]
        [When(@"I Confirm the Refresh")]
        [Then(@"I Confirm the Refresh")]
        public void ThenIConfirmTheRefresh()
        {
            SupportPoint.SPAuthorPage.ConfirmRefreshMessage();
        }

        [Given(@"I press Details & Actions")]
        [When(@"I press Details & Actions")]
        [Then(@"I press Details & Actions")]
        public void WhenIPressDetailsActions()
        {
            SupportPoint.SPManagerDetailsActionsPage.clickDetailsandActions();
        }

        [Given(@"I select (.*) from Details & Actions")]
        [When(@"I select (.*) from Details & Actions")]
        [Then(@"I select (.*) from Details & Actions")]
        public void WhenISelectFromDetailsAndActions(string detailsAction)
        {
            SupportPoint.SPManagerDetailsActionsPage.SelectFromDnAList(detailsAction);
        }

        [Given(@"I click on Actions")]
        [When(@"I click on Actions")]
        [Then(@"I click on Actions")]
        public void WhenIClickOnActions()
        {
            SupportPoint.SPManagerNav.ClickActions();
        }

        [Given(@"I select (.*) from Actions")]
        [When(@"I select (.*) from Actions")]
        [Then(@"I select (.*) from Actions")]
        public void WhenISelectFromActions(string action)
        {
            SupportPoint.SPManagerActionsPage.SelectFromActionsList(action);
        }

        [Given(@"I select (.*) using the column (.*) from the table")]
        [When(@"I select (.*) using the column (.*) from the table")]
        [Then(@"I select (.*) using the column (.*) from the table")]
        public void GivenISelectSearchSetupUsingTheColumnNameFromTheTable(string searchValue, string colName)
        {
            SupportPoint.AdminPage.ClickRecord(colName, searchValue);
        }

        [Given(@"the Role Selector is opened")]
        [When(@"the Role Selector is opened")]
        [Then(@"the Role Selector is opened")]
        public void TheRoleSelectorIsOpened()
        {
            SupportPoint.RoleSelectorPage.ConfirmRoleSelector();
        }

        [Given(@"the User Selector is opened")]
        [When(@"the User Selector is opened")]
        [Then(@"the User Selector is opened")]
        public void TheUserSelectorIsOpened()
        {
            SupportPoint.UserSelectorPage.ConfirmUserSelector();
        }

        [Given(@"I search for user by (.*) for (.*)")]
        [When(@"I search for user by (.*) for (.*)")]
        [Then(@"I search for user by (.*) for (.*)")]
        public void WhenISearchForUserByFindByForSearchText(String findBy,
            String searchText)
        {
            FeatureContext.Current.Add("SearchBy", searchText);
            SupportPoint.UserSelectorPage.SetSearchText(searchText);
            SupportPoint.UserSelectorPage.ClickSearchButton();

        }

        [Given(@"I select the record (.*) using column (.*) from the User Selector table")]
        [When(@"I select the record (.*) using column (.*) from the User Selector table")]
        [Then(@"I select the record (.*) using column (.*) from the User Selector table")]
        public void IselecttherecordfromtheUserSelectortable(string searchValue, string colName)
        {
            SupportPoint.UserSelectorPage.ClickSelectorRecord(colName, searchValue);

        }

        [Given(@"I Click on the Add user selector Button")]
        [When(@"I Click on the Add user selector Button")]
        [Then(@"I Click on the Add user selector Button")]
        public void WhenIClickOnTheAddUserSelectorButton()
        {
            SupportPoint.UserSelectorPage.ClickAddUserButton();
        }

        [Given(@"I search for role for (.*)")]
        [When(@"I search for role for (.*)")]
        [Then(@"I search for role for (.*)")]
        public void WhenISearchForRoleByFindByForSearchText(String searchText)
        {
            if (FeatureContext.Current.ContainsKey("SearchBy"))
            {
                FeatureContext.Current.Set(searchText, "SearchBy");
            }else
            {
                FeatureContext.Current.Add("SearchBy", searchText);
            }
            SupportPoint.RoleSelectorPage.searchRole(searchText);
        }

        [Given(@"I select the record (.*) using column (.*) from the Role Selector table")]
        [When(@"I select the record (.*) using column (.*) from the Role Selector table")]
        [Then(@"I select the record (.*) using column (.*) from the Role Selector table")]
        public void IselecttherecordfromtheRoleSelectortable(string searchValue, string colName)
        {
            SupportPoint.RoleSelectorPage.ClickSelectorRecord(colName, searchValue);

        }

        [Given(@"I Click on the Add role selector Button")]
        [When(@"I Click on the Add role selector Button")]
        [Then(@"I Click on the Add role selector Button")]
        public void WhenIClickOnTheAddRoleSelectorButton()
        {
            SupportPoint.RoleSelectorPage.ClickAddRoleButton();
        }
    }
}
