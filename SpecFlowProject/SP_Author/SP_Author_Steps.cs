using SP_Automation.Tests;
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
            //SupportPoint.SPAuthorPage.ClickSaveButton();
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
    }
}
