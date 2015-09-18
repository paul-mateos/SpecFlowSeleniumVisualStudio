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



    }
}
