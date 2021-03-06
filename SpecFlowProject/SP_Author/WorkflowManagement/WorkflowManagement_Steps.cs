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
            SupportPoint.waitForPageLoading(); 
            string workflowName = ScenarioContext.Current.Get<string>("WorkflowName");
            SupportPoint.SPManagerDetailsActionsPage.ConfirmName(workflowName);
        }

        [Given(@"I enter the workflow Name (.*)")]
        [When(@"I enter the workflow Name (.*)")]
        [Then(@"I enter the workflow Name (.*)")]
        public void IEnterTheWorkflowName(string workflowName)
        {
            string newName = SupportPoint.SPManagerDetailsActionsPage.SetName(workflowName);
            
            //Add feature content if it exists
            if (ScenarioContext.Current.ContainsKey("WorkflowName"))
            {
                ScenarioContext.Current.Set(newName, "WorkflowName");
            }
            else
            {
                ScenarioContext.Current.Add("WorkflowName", newName);
            }
        }

        [Given(@"I enter the random workflow Name (.*)")]
        [When(@"I enter the random workflow Name (.*)")]
        [Then(@"I enter the random workflow Name (.*)")]
        public void IEnterTheRandomWorkflowName(string workflowName)
        {
            string newName = SupportPoint.SPManagerDetailsActionsPage.SetRandomName(workflowName);

            //Add feature content if it exists
            if (ScenarioContext.Current.ContainsKey("WorkflowName"))
            {
                ScenarioContext.Current.Set(newName, "WorkflowName");
            }
            else
            {
                ScenarioContext.Current.Add("WorkflowName", newName);
            }
        }

        [Given(@"I search for workflow by name for (.*)")]
        [When(@"I search for workflow by name for (.*)")]
        [Then(@"I search for workflow by name for (.*)")]
        public void ISearchForWorkflowByNameByForSearchText(String searchText)
        {
            ScenarioContext.Current.Add("SearchBy", searchText);
            SupportPoint.WorkflowManagementPage.SetSearchText(searchText);
            SupportPoint.WorkflowManagementPage.ClickSubmitSearchButton();
            SupportPoint.waitForPageLoading();

        }

        [Given(@"the search should return the record")]
        [When(@"the search should return the record")]
        [Then(@"the search should return the record")]
        public void ThenTheSearchShouldReturnTheRecord()
        {
            string SearchText = ScenarioContext.Current.Get<string>("SearchBy");
            SupportPoint.WorkflowManagementPage.ConfirmFoundRecord("Name", SearchText);

        }

        [Given(@"the search should click on the record")]
        [When(@"the search should click on the record")]
        [Then(@"the search should click on the record")]
        public void ThenTheSearchShouldClickOnTheRecord()
        {
            string SearchText = ScenarioContext.Current.Get<string>("SearchBy");
            SupportPoint.WorkflowManagementPage.ClickFoundRecord("Name", SearchText);

        }

       

       

    }
}
