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
        public void GivenINavigateToTheManagementPage(string managePage)
        {
            switch(managePage)
            {
                case "Images":
                    SupportPoint.SPManagerNav.ClickImages();
                    SupportPoint.SwitchToPage("Image Management : SupportPoint");
                    break;
                case "Users":
                    SupportPoint.SPManagerNav.ClickUsers();
                    SupportPoint.SwitchToPage("User Management : SupportPoint");
                    break;
                case "Roles":
                    SupportPoint.SPManagerNav.ClickRoles();
                    SupportPoint.SwitchToPage("Role Management : SupportPoint");
                    break;
                default:
                    throw new Exception("Invalid Page");
                  
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
