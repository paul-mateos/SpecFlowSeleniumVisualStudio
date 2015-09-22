﻿using SeleniumProject.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.SP_Author.WorkflowManagement
{
    [Binding]
    public class WorkflowManagement_Steps: Steps
    {

        
        [Given(@"I confirm the workflow Name")]
        [When(@"I confirm the workflow Name")]
        [Then(@"I confirm the workflow Name")]
        public void ThenIConfirmTheWorkflowName()
        {
            string workflowName = FeatureContext.Current.Get<string>("WorkflowName");
            SupportPoint.WorkflowManagementPage.ConfirmWorkflowName(workflowName);
        }

        [Given(@"I enter the workflow Name (.*)")]
        [When(@"I enter the workflow Name (.*)")]
        [Then(@"I enter the workflow Name (.*)")]
        public void IEnterTheWorkflowName(string workflowName)
        {
            string newName = SupportPoint.WorkflowManagementPage.SetWorkflowName(workflowName);
            
            //Add feature content if it exists
            if (FeatureContext.Current.ContainsKey("WorkflowName"))
            {
                FeatureContext.Current.Set(newName, "WorkflowName");
            }
            else
            {
                FeatureContext.Current.Add("WorkflowName", newName);
            }
        }

        [Given(@"I enter the random workflow Name (.*)")]
        [When(@"I enter the random workflow Name (.*)")]
        [Then(@"I enter the random workflow Name (.*)")]
        public void IEnterTheRandomWorkflowName(string workflowName)
        {
            string newName = SupportPoint.WorkflowManagementPage.SetRandomWorkflowName(workflowName);

            //Add feature content if it exists
            if (FeatureContext.Current.ContainsKey("WorkflowName"))
            {
                FeatureContext.Current.Set(newName, "WorkflowName");
            }
            else
            {
                FeatureContext.Current.Add("WorkflowName", newName);
            }
        }

        [Given(@"I search for workflow by name for (.*)")]
        [When(@"I search for workflow by name for (.*)")]
        [Then(@"I search for workflow by name for (.*)")]
        public void ISearchForWorkflowByNameByForSearchText(String searchText)
        {
            FeatureContext.Current.Add("SearchBy", searchText);
            SupportPoint.WorkflowManagementPage.SetSearchText(searchText);
            SupportPoint.WorkflowManagementPage.ClickSubmitSearchButton();

        }

        [Given(@"the search should return the record")]
        [When(@"the search should return the record")]
        [Then(@"the search should return the record")]
        public void ThenTheSearchShouldReturnTheRecord()
        {
            string SearchText = FeatureContext.Current.Get<string>("SearchBy");
            SupportPoint.WorkflowManagementPage.ConfirmFoundRecord("Name", SearchText);

        }

        [Given(@"the search should click on the record")]
        [When(@"the search should click on the record")]
        [Then(@"the search should click on the record")]
        public void ThenTheSearchShouldClickOnTheRecord()
        {
            string SearchText = FeatureContext.Current.Get<string>("SearchBy");
            SupportPoint.WorkflowManagementPage.ClickFoundRecord("Name", SearchText);

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

    }
}
