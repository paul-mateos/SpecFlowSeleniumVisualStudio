using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumProject.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.SupportPointCommon
{
    [Binding]
    public sealed class SupportPointCommon_Steps
    {
       

        [Given(@"I switch to (.*) Browser")]
        [When(@"I switch to (.*) Browser")]
        [Then(@"I switch to (.*) Browser")]
        public void GivenISwitchToBrowser(string browserName)
        {
           
            SupportPoint.SwitchToBrowser(browserName, SupportPoint.GetCurrentBrowserHandle());
        }

       


    }
}
