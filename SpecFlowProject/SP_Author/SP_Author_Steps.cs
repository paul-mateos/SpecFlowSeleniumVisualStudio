using SP_Automation.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.SP_Author
{
    [Binding]
    public sealed class SP_Author_Steps
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        [Given(@"I Navigate to the (.*) Page")]
        public void GivenINavigateToTheImagePage(string managePage)
        {
            switch(managePage)
            {
                case "Images":
                     SupportPoint.SPManagerNav.ClickImages();
                    break;
                case "Users":
                     SupportPoint.SPManagerNav.ClickUsers();
                     break;
                case "Roles":
                        SupportPoint.SPManagerNav.ClickRoles();
                        break;
                default:
                        throw new Exception("Invalid Page");
                        break;
            }
                
        }

        [Given(@"I am at (.*) page")]
        [When(@"I am at (.*) page")]
        public void GivenIAmAtTheManagementPage(string managementPage)
        {
            SupportPoint.IsCurrentBrowser(managementPage + " : SupportPoint");

        }

    }
}
