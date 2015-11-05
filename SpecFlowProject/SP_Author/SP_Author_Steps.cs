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

        [Given(@"I Click on the Add role to Roles Button")]
        [When(@"I Click on the Add role to Roles Button")]
        [Then(@"I Click on the Add role to Roles Button")]
        public void WhenIClickOnTheAddRoleToRolesButton()
        {
            SupportPoint.SPAuthorPage.ClickAddRoleToRolesButton();
        }

        [Given(@"I Click on the Add roles to Role Button")]
        [When(@"I Click on the Add roles to Role Button")]
        [Then(@"I Click on the Add roles to Role Button")]
        public void WhenIClickOnTheAddRolesToRoleButton()
        {
            SupportPoint.SPAuthorPage.ClickAddRolesToRoleButton();
        }

        [Given(@"I Click on the Add users to Role Button")]
        [When(@"I Click on the Add users to Role Button")]
        [Then(@"I Click on the Add users to Role Button")]
        public void WhenIClickOnTheAddUsersToRoleButton()
        {
            SupportPoint.SPAuthorPage.ClickAddUsersToRoleButton();
        }

        [Given(@"I Click on the Add users to readers Button")]
        [When(@"I Click on the Add users to readers Button")]
        [Then(@"I Click on the Add users to readers Button")]
        public void WhenIClickOnTheAddUsersToReadersButton()
        {
            SupportPoint.SPAuthorPage.ClickAddUsersToReadersButton();
        }

        [Given(@"I Click on the Add users to writers Button")]
        [When(@"I Click on the Add users to writers Button")]
        [Then(@"I Click on the Add users to writers Button")]
        public void WhenIClickOnTheAddUsersToWritersButton()
        {
            SupportPoint.SPAuthorPage.ClickAddUsersToWritersButton();
        }

        [Given(@"I Click on the Add user to readers Button")]
        [When(@"I Click on the Add user to readers Button")]
        [Then(@"I Click on the Add user to readers Button")]
        public void WhenIClickOnTheAddUserToReadersButton()
        {
            SupportPoint.SPAuthorPage.ClickAddUserToReadersButton();
        }

        [Given(@"I Click on the Remove role from Roles Button")]
        [When(@"I Click on the Remove role from Roles Button")]
        [Then(@"I Click on the Remove role from Roles Button")]
        public void WhenIClickOnTheRemoveRoleToRolesButton()
        {
            SupportPoint.SPAuthorPage.ClickRemoveRoleFromRolesButton();
        }

        [Given(@"I Click on the Remove roles from Role Button")]
        [When(@"I Click on the Remove roles from Role Button")]
        [Then(@"I Click on the Remove roles from Role Button")]
        public void WhenIClickOnTheRemoveRolesToRoleButton()
        {
            SupportPoint.SPAuthorPage.ClickRemoveRolesFromRoleButton();
        }

        [Given(@"I Click on the Remove users from Role Button")]
        [When(@"I Click on the Remove users from Role Button")]
        [Then(@"I Click on the Remove users from Role Button")]
        public void WhenIClickOnTheRemoveUsersToRoleButton()
        {
            SupportPoint.SPAuthorPage.ClickRemoveUsersFromRoleButton();
        }

        [Given(@"I Click on the Remove users from readers Button")]
        [When(@"I Click on the Remove users from readers Button")]
        [Then(@"I Click on the Remove users from readers Button")]
        public void WhenIClickOnTheRemoveUsersToReadersButton()
        {
            SupportPoint.SPAuthorPage.ClickRemoveUsersFromReadersButton();
        }

        [Given(@"I Click on the Remove users from writers Button")]
        [When(@"I Click on the Remove users from writers Button")]
        [Then(@"I Click on the Remove users from writers Button")]
        public void WhenIClickOnTheRemoveUsersToWritersButton()
        {
            SupportPoint.SPAuthorPage.ClickRemoveUsersFromWritersButton();
        }

        [Given(@"I Click on the Remove roles from readers Button")]
        [When(@"I Click on the Remove roles from readers Button")]
        [Then(@"I Click on the Remove roles from readers Button")]
        public void WhenIClickOnTheARemoveRolesToReadersButton()
        {
            SupportPoint.SPAuthorPage.ClickRemoveRolesFromReadersButton();
        }

        [Given(@"I Click on the Remove roles from writers Button")]
        [When(@"I Click on the Remove roles from writers Button")]
        [Then(@"I Click on the Remove roles from writers Button")]
        public void WhenIClickOnTheARemoveRolesToWritersButton()
        {
            SupportPoint.SPAuthorPage.ClickRemoveRolesFromWritersButton();
        }


        [Given(@"I Click on the Delete Button")]
        [When(@"I Click on the Delete Button")]
        [Then(@"I Click on the Delete Button")]
        public void WhenIClickOnTheDeleteButton()
        {
            SupportPoint.SPManagerDetailsActionsPage.clickDelete();
        }

        [Given(@"I Click on the Delete role Button")]
        [When(@"I Click on the Delete role Button")]
        [Then(@"I Click on the Delete role Button")]
        public void WhenIClickOnTheDeleteRoleButton()
        {
            SupportPoint.SPManagerDetailsActionsPage.clickDeleteRole();
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
            SupportPoint.waitForPageLoading();
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




      


        [Given(@"I click on the Cancel Button")]
        [When(@"I click on the Cancel Button")]
        [Then(@"I click on the Cancel Button")]
        public void ThenIClickOnTheCancelButton()
        {
            SupportPoint.SPManagerDetailsActionsPage.clickCancel();
        }

        [Given(@"I Click on the Add role to readers Button")]
        [When(@"I Click on the Add role to readers Button")]
        [Then(@"I Click on the Add role to readers Button")]
        public void WhenIClickOnTheAddRoleToReadersButton()
        {
            SupportPoint.SPAuthorPage.ClickAddRoleToReadersButton();
        }

        [Given(@"I Click on the Add role\(s\) to readers Button")]
        [When(@"I Click on the Add role\(s\) to readers Button")]
        [Then(@"I Click on the Add role\(s\) to readers Button")]
        public void WhenIClickOnTheAddrolesToReadersButton()
        {
            SupportPoint.SPAuthorPage.ClickAddrolesToReadersButton();
        }

        [Given(@"I Click on the Add Role\(s\) to readers Button")]
        [When(@"I Click on the Add Role\(s\) to readers Button")]
        [Then(@"I Click on the Add Role\(s\) to readers Button")]
        public void WhenIClickOnTheAddRolesToReadersButton()
        {
            SupportPoint.SPAuthorPage.ClickAddRolesToReadersButton();
        }

        [Given(@"I Click on the Add role to writers Button")]
        [When(@"I Click on the Add role to writers Button")]
        [Then(@"I Click on the Add role to writers Button")]
        public void WhenIClickOnTheAddRoleToWritersButton()
        {
            SupportPoint.SPAuthorPage.ClickAddRoleToWritersButton();
        }

        [Given(@"I Click on the Add roles to writers Button")]
        [When(@"I Click on the Add roles to writers Button")]
        [Then(@"I Click on the Add roles to writers Button")]
        public void WhenIClickOnTheAddRolesToWritersButton()
        {
            SupportPoint.SPAuthorPage.ClickAddRolesToWritersButton();
        }

       

        [Given(@"I Click on the Add user to writers Button")]
        [When(@"I Click on the Add user to writers Button")]
        [Then(@"I Click on the Add user to writers Button")]
        public void WhenIClickOnTheAddUserToWritersButton()
        {
            SupportPoint.SPAuthorPage.ClickAddUserToWritersButton();
        }

    }
}
