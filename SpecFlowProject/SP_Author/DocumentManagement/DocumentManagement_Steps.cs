using SP_Automation.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject
{
    [Binding]
    public class DocumentManagement
    {
        
        [Given(@"I am at Document Management page")]
        public void GivenIAmAtDocumentManagementPage()
        {
            SupportPoint.IsCurrentBrowser("Document Management : SupportPoint");

        }
    }
}
