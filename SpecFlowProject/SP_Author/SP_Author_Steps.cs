﻿using SP_Automation.Tests;
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
            SupportPoint.SPAuthorPage.ClickSaveButton();
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

        [Given(@"I Confirm the Removal")]
        [When(@"I Confirm the Removal")]
        [Then(@"I Confirm the Removal")]
        public void ThenIConfirmTheRemoval()
        {
            SupportPoint.SPAuthorPage.ConfirmRemovalMessage();
        }
       
    }
}
