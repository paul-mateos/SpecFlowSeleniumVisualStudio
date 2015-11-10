using SeleniumProject.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.SP_Author
{
    [Binding]
    public sealed class UserSelector_Steps: Steps
    {

        [Given(@"the User Selector is opened")]
        [When(@"the User Selector is opened")]
        [Then(@"the User Selector is opened")]
        public void TheUserSelectorIsOpened()
        {
            SupportPoint.UserSelectorPage.ConfirmUserSelector();
            SupportPoint.waitForPageLoading();
        }

        [Given(@"I search for user (.*) in User Selector")]
        [When(@"I search for user (.*) in User Selector")]
        [Then(@"I search for user (.*) in User Selector")]
        public void WhenISearchForUserUserSelector(String searchText)
        {
            //ScenarioContext.Current.Add("SearchBy", searchText);
            if (searchText == "currentuser")
            {
                var user = FeatureContext.Current.Get<string>("UserName");
                SupportPoint.UserSelectorPage.SetSearchText(user);
                SupportPoint.UserSelectorPage.ClickSearchButton();
            }
            else
            {
                SupportPoint.UserSelectorPage.SetSearchText(searchText);
                SupportPoint.UserSelectorPage.ClickSearchButton();
            }
        }

        [Given(@"I select the record (.*) using column (.*) from the User Selector table")]
        [When(@"I select the record (.*) using column (.*) from the User Selector table")]
        [Then(@"I select the record (.*) using column (.*) from the User Selector table")]
        public void IselecttherecordfromtheUserSelectortable(string searchValue, string colName)
        {
            if(searchValue =="currentuser")
            {
                var user = FeatureContext.Current.Get<string>("UserName");
                SupportPoint.UserSelectorPage.ClickSelectorRecord(colName, user);
            }else{
                SupportPoint.UserSelectorPage.ClickSelectorRecord(colName, searchValue);
            }
           

        }

        [Given(@"I Click on the Add user selector Button")]
        [When(@"I Click on the Add user selector Button")]
        [Then(@"I Click on the Add user selector Button")]
        public void WhenIClickOnTheAddUserSelectorButton()
        {
            SupportPoint.UserSelectorPage.ClickAddUserButton();
        }

     
    }
}
