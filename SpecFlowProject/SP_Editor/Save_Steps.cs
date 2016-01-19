using SeleniumProject.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.SP_Editor
{
    [Binding]
    public sealed class Save_Steps: Steps
    {

        [Given(@"the Editor Save is opened")]
        [When(@"the Editor Save is opened")]
        [Then(@"the Editor Save is opened")]
        public void SaveIsOpened()
        {
            SupportPoint.SavePage.ConfirmSavePage();
            //SupportPoint.waitForPageLoading();
            
        }



        [Given(@"I click on the Editor Save Save Button")]
        [When(@"I click on the Editor Save Save Button")]
        [Then(@"I click on the Editor Save Save Button")]
        public void IClickOnTheEditorSaveSaveButton()
        {
            SupportPoint.SavePage.ClickSaveButton();
        }


    }
}
