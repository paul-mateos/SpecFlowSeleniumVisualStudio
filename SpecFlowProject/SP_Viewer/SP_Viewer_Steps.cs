using SeleniumProject.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.SP_Viewer
{
    [Binding]
    public sealed class SP_Viewer_Steps
    {

        [Given(@"I am at Viewer Home")]
        [When(@"I am at Viewer Home")]
        [Then(@"I am at Viewer Home")]
        public void IAmAtTheViewerHomePage()
        {
            SupportPoint.IsCurrentBrowser("Home");
            
        }

        [Given(@"I Open SP Manager to (.*)")]
        [When(@"I Open SP Manager to (.*)")]
        [Then(@"I Open SP Manager to (.*)")]
        public void ThenIOpenSPManager(string managementPage)
        {
            SupportPoint.Nav.ToSupportPointManager(managementPage);
            SupportPoint.waitForPageLoading();
        }

        [Given(@"I click on the Viewer folder Button")]
        [When(@"I click on the Viewer folder Button")]
        [Then(@"I click on the Viewer folder Button")]
        public void IClickOnTheViewerFolderButton()
        {
            SupportPoint.HomePage.ClickFolderNavButton();
        }


    }
}
