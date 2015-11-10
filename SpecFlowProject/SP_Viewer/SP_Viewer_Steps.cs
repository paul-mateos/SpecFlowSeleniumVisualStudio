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


        [Given(@"I Open SP Manager to (.*)")]
        [When(@"I Open SP Manager to (.*)")]
        [Then(@"I Open SP Manager to (.*)")]
        public void ThenIOpenSPManager(string managementPage)
        {
            SupportPoint.Nav.ToSupportPointManager(managementPage);
            SupportPoint.waitForPageLoading();
        }

    }
}
