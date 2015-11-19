using SeleniumProject.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.SP_Author.UserManagement
{
    [Binding]
    public sealed class ChangePassword_Steps
    {

        [Given(@"the User Change Password is opened")]
        [When(@"the User Change Password is opened")]
        [Then(@"the User Change Password is opened")]
        public void TheChangePasswordIsOpened()
        {
            SupportPoint.ChangePasswordPage.ConfirmChangePassword();
            SupportPoint.waitForPageLoading();
        }

        [Given(@"I enter old password (.*)")]
        [When(@"I enter old password (.*)")]
        [Then(@"I enter old password (.*)")]
        public void WhenIEnterOldPassword(string password)
        {
            SupportPoint.ChangePasswordPage.SetOldPassword(password);
        }

        [Given(@"I enter new password (.*)")]
        [When(@"I enter new password (.*)")]
        [Then(@"I enter new password (.*)")]
        public void WhenIEnterNewPassword(string password)
        {
            SupportPoint.ChangePasswordPage.SetPassword(password);
        }

        [Given(@"I enter confirm password (.*)")]
        [When(@"I enter confirm password (.*)")]
        [Then(@"I enter confirm password (.*)")]
        public void WhenIEnterConfirmPassword(string password)
        {
            SupportPoint.ChangePasswordPage.SetConfirmPassword(password);
        }

        [Given(@"I click on the Save button")]
        [When(@"I click on the Save button")]
        [Then(@"I click on the Save button")]
        public void IClickOnTheSaveButton()
        {
            SupportPoint.ChangePasswordPage.ClickSaveButton();
            SupportPoint.waitForPageLoading();
        }


    }
}
