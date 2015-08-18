using SP_Automation.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject
{
    [Binding]
    public sealed class DocumentManagement
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        [Given(@"I am at Document Management page")]
        public void GivenIAmAtDocumentManagementPage()
        {
            SupportPoint.IsCurrentBrowser("Document Management : SupportPoint");

        }
    }
}
