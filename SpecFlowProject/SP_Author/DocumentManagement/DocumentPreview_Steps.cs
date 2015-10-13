using SeleniumProject.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.SP_Author.DocumentManagement
{
    [Binding]
    public sealed class DocumentPreview_Steps
    {

        [Given(@"I close the Preview document")]
        [When(@"I close the Preview document")]
        [Then(@"I close the Preview document")]
        public void ThenICloseThePreviewDocument()
        {
            SupportPoint.DocumentPreviewPage.closeOpenPreviewBrowser();
        }

        
    }
}
