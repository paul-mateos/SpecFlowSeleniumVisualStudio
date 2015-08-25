using SP_Automation.Tests;
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

   
        [Then(@"I Open SP Manager")]
        public void ThenIOpenSPManager()
        {
            SupportPoint.Nav.ToSupportPointManager();
            SupportPoint.SwitchToPage("Document Management : SupportPoint");
            System.Threading.Thread.Sleep(5000);
        }

    }
}
