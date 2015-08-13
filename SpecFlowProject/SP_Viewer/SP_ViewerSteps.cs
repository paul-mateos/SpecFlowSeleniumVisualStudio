using SP_Automation.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.SP_Viewer
{
    [Binding]
    public sealed class SP_ViewerSteps
    {

   
        [Then(@"I Open SP Manager")]
        public void ThenIOpenSPManager()
        {
            SupportPoint.Nav.ToSupportPointManager();
            SupportPoint.SwitchToSPManager();
            System.Threading.Thread.Sleep(5000);
        }

    }
}
