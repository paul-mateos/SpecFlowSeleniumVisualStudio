Feature: RoleManagement_CreateNew
	In order to create a new role
	As a role creator
	I want to create a role that does not exist

Background: Logon to SP and navigate to Role Manager
Given I have logged in to SP as a new "rolecreators"
And I Open SP Manager
When I Navigate to the Roles Page
Then I am at Role Management page

@Regression
@RoleManagement_Properties
Scenario: 1.1,2.1.(1,4)_Create New Role
	Given I click on Actions
	And I select New Role from Actions
	When I enter the random role Name AutomationRole
	#Workflow name wil be prefixed with a random number
	Then I click on the Save Button
	And I confirm the role Name
	And I Click on the Delete role Button
	And I Confirm the Delete

@Regression
@RoleManagement_Properties
Scenario: 2.1.3_Edit Existing Role
	Given I click on Actions
	And I select New Role from Actions
	And I enter the random role Name AutomationRole
	#Workflow name wil be prefixed with a random number
	And I click on the Save Button
	And I confirm the role Name
	And I enter the role Description Test Description
	And I confirm the role Description
	And I click on the Cancel Button
	And I Click on the Delete role Button
	And I Confirm the Delete
	