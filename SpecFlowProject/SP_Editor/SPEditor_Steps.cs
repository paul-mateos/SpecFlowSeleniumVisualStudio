using SeleniumProject.Tests;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.SP_Editor
{
    [Binding]
    public class SPEditor_Steps
    {
        [Given(@"Document (.*) is open for Editing")]
        [When(@"Document (.*) is open for Editing")]
        [Then(@"Document (.*) is open for Editing")]
        public void WhenDocumentDocImageMapTestIsOpenForEditing(string docName)
        {
            SupportPoint.SPEditorPage.ConfirmEditDocumentTitle(docName);
        }

        [Given(@"I click on the ImageMap Button")]
        [When(@"I click on the ImageMap Button")]
        [Then(@"I click on the ImageMap Button")]
        public void WhenIClickOnTheImageMapButton()
        {
            SupportPoint.SPEditorPage.ClickImageMapButton();
        }

        [Given(@"I Click on Editor More Menu")]
        [When(@"I Click on Editor More Menu")]
        [Then(@"I Click on Editor More Menu")]
        public void IClickOnEditorMoremenu()
        {
            SupportPoint.SPEditorPage.ClickMoreMenu();
            
        }

        [Given(@"I select (.*) from Editor More Menu")]
        [When(@"I select (.*) from Editor More Menu")]
        [Then(@"I select (.*) from Editor More Menu")]
        public void ISelectFromEditorMoreMenu(string action)
        {
            SupportPoint.SPEditorPage.SelectFromMoreMenuList(action);
            if (action == "Close")
            {
                SupportPoint.SwitchToBrowser("Home");
            }
        }

        [Given(@"I click on the Editor Save Button")]
        [When(@"I click on the Editor Save Button")]
        [Then(@"I click on the Editor Save Button")]
        public void IClickOnTheEditoraveButton()
        {
            SupportPoint.SPEditorPage.clickSave();
            //SupportPoint.waitForPageLoading();
        }
    }
}
