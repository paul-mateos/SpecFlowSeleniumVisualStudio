Feature: RoleManagement_Notifications
	In order to manage role notifications
	As a role creator
	I want to manage role notifications

Background: Logon to SP and navigate to Role Manager
Given I have logged in to SP as a new "rolecreators"
And I Open SP Manager
When I Navigate to the Roles Page
Then I am at Role Management page

@Regression
@RoleManagement_Writers
Scenario: 2.7(1,2)_AddRoleToNotifications
	Given I click on Actions
	And I select New Role from Actions
	And I enter the random role Name AutomationRole
	#Workflow name wil be prefixed with a random number
	And I click on the Save Button
	And I confirm the role Name
	When I press Details & Actions
	And I select Notifications from Details & Actions
	And I Click on the Add notification to role Button
	Then the Document Selector is opened
	And I select the Orphans Document Selector Folder
	And I select the record Overview using column Name from the Document Selector table
	And I click on the Add document Button
	And I select Immediately from the Notification period
	And I Click on the Add notification to role popup Button
	And I click on the Save Button
	And I select the record Overview using column Name from the Role has notifiaction table
	And I Click on the Remove notifications from role Button
	And I click on the Save Button
	And I press Details & Actions
	And I select Properties from Details & Actions
	And I Click on the Delete role Button
	And I Confirm the Delete


