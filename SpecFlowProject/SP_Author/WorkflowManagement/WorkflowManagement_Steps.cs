using SeleniumProject.Tests;
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
            FeatureContext.Current.Add("WorkflowName", newName);
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
    }
}
