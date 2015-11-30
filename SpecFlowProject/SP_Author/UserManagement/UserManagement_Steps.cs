using SeleniumProject.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.SP_Author.UserManagement
{
    [Binding]
    public sealed class UserManagement_Steps
    {
        [Given(@"I search for user (.*) in User Management")]
        [When(@"I search for user (.*) in User Management")]
        [Then(@"I search for user (.*) in User Management")]
        public void WhenISearchForUserInUserManagement(String searchText)
        {
            ScenarioContext.Current.Add("SearchBy", searchText);
            if (searchText == "currentuser")
            {
                var user = FeatureContext.Current.Get<string>("UserName");
                SupportPoint.UserManagementPage.SetSearchText(user);
                SupportPoint.UserManagementPage.ClickSubmitSearchButton();
                SupportPoint.waitForPageLoading();
            }
            else
            {
                SupportPoint.UserManagementPage.SetSearchText(searchText);
                SupportPoint.UserManagementPage.ClickSubmitSearchButton();
                SupportPoint.waitForPageLoading();
            }
        }

        [Given(@"I select the record (.*) using column (.*) from the User table")]
        [When(@"I select the record (.*) using column (.*) from the User table")]
        [Then(@"I select the record (.*) using column (.*) from the User table")]
        public void IselecttherecordfromtheUserTabletable(string searchValue, string colName)
        {
            if (searchValue == "currentuser")
            {
                var user = FeatureContext.Current.Get<string>("UserName");
                SupportPoint.UserManagementPage.ClickUserRecord(colName, user, "UserTable");
            }
            else
            {
                SupportPoint.UserManagementPage.ClickUserRecord(colName, searchValue, "UserTable");
            }

            SupportPoint.waitForPageLoading();

        }


        [Given(@"I select the record (.*) using column (.*) from the Roles that read table")]
        [When(@"I select the record (.*) using column (.*) from the Roles that read table")]
        [Then(@"I select the record (.*) using column (.*) from the Roles that read table")]
        public void IselecttherecordfromtheRolesThatReadtable(string searchValue, string colName)
        {
            SupportPoint.UserManagementPage.ClickUserRecord(colName, searchValue, "RolesthatcanreadTable");

        }

        [Given(@"I select the record (.*) using column (.*) from the Users that read table")]
        [When(@"I select the record (.*) using column (.*) from the Users that read table")]
        [Then(@"I select the record (.*) using column (.*) from the Users that read table")]
        public void IselecttherecordfromtheUsersThatReadtable(string searchValue, string colName)
        {
            SupportPoint.UserManagementPage.ClickUserRecord(colName, searchValue, "UsersthatcanreadTable");

        }

        [Given(@"I select the record (.*) using column (.*) from the User in roles table")]
        [When(@"I select the record (.*) using column (.*) from the User in roles table")]
        [Then(@"I select the record (.*) using column (.*) from the User in roles table")]
        public void IselecttherecordfromtheUserInRolesTable(string searchValue, string colName)
        {
            SupportPoint.UserManagementPage.ClickUserRecord(colName, searchValue, "UserInRolesTable");

        }


        [Given(@"I enter the first name (.*)")]
        [When(@"I enter the first name (.*)")]
        [Then(@"I enter the first name (.*)")]
        public void WhenIEnterTheFirstName(string firstName)
        {
            SupportPoint.UserManagementPage.SetFirstName(firstName);
        }

        [Given(@"The first name does not equal (.*)")]
        [When(@"The first name does not equal (.*)")]
        [Then(@"The first name does not equal (.*)")]
        public void ThenTheFirstNameDoesNotEqual(string firstName)
        {
            SupportPoint.UserManagementPage.FirstNameNotEqualTo(firstName);
        }

        [Given(@"I select the record (.*) using column (.*) from the User has notifications table")]
        [When(@"I select the record (.*) using column (.*) from the User has notifications table")]
        [Then(@"I select the record (.*) using column (.*) from the User has notifications table")]
        public void IselecttherecordfromtheUserHasNotificationtable(string searchValue, string colName)
        {
            SupportPoint.UserManagementPage.ClickUserRecord(colName, searchValue, "UserHasnotifiactionTable");

        }


        [Given(@"I Click on the Add notification to User Button")]
        [When(@"I Click on the Add notification to User Button")]
        [Then(@"I Click on the Add notification to User Button")]
        public void WhenIClickOnTheAddNotificationToUserButton()
        {
            SupportPoint.UserManagementPage.ClickAddNotificationsToUserButton();
        }

        [Given(@"I Click on the Remove notifications from User Button")]
        [When(@"I Click on the Remove notifications from User Button")]
        [Then(@"I Click on the Remove notifications from User Button")]
        public void WhenIClickOnTheremoveNotificationsFromUserButton()
        {
            SupportPoint.UserManagementPage.ClickRemoveNotificationsFromUserButton();
        }

        [Given(@"I Click on the Add notification to User popup Button")]
        [When(@"I Click on the Add notification to User popup Button")]
        [Then(@"I Click on the Add notification to User popup Button")]
        public void WhenIClickOnTheAddNotificationToUserPopupButton()
        {
            SupportPoint.UserManagementPage.ClickAddNotificationsToUserPopupButton();
        }

    }
}
