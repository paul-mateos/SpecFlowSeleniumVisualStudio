using System;
using System.Diagnostics;
using TechTalk.SpecFlow;

namespace SpecFlowProject.SP_Author.DocumentManagement
{
    [Binding]
    public class BeforeAndAfterDocumentManagement
    {
        [BeforeFeature("documentManagementSearchFeature")]
        public static void BeforeDocumentManagement()
        {
            Console.WriteLine("** [BeforeFeature]");
            // create a user using API by providing random username
        }

        [AfterFeature("documentManagementSearchFeature")]
        public static void AfterDocumentManagement()
        {
            Console.WriteLine("** [AfterFeature]");
        }
    }
}
