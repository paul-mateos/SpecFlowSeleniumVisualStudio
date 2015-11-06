Feature: RoleManagement_Readers
	In order to manage role readers
	As a role creator
	I want to manage role readers

Background: Logon to SP and navigate to Role Manager
Given I have logged in to SP as a new "rolecreators"
And I Open SP Manager
When I Navigate to the Roles Page
Then I am at Role Management page

@Regression
@RoleManagement_Readers
Scenario: 2.5(1,2)_AddRoleToReaders
	Given I click on Actions
	And I select New Role from Actions
	And I enter the random role Name AutomationRole
	#Workflow name wil be prefixed with a random number
	And I click on the Save Button
	And I confirm the role Name
	When I press Details & Actions
	And I select Readers from Details & Actions
	And I Click on the Add Role(s) to readers Button
	Then the Role Selector is opened
	And I search for role for authors
	And I select the record authors using column Role from the Role Selector table
	And I Click on the Add roles Button
	And I click on the Save Button
	And I select the record authors using column Role from the Roles that can read table
	And I Click on the Remove roles from readers Button
	And I click on the Save Button
	And I press Details & Actions
	And I select Properties from Details & Actions
	And I Click on the Delete role Button
	And I Confirm the Delete

@Regression
@RoleManagement_Readers
Scenario: 2.5(3,4)_AddUserToReaders
	Given I click on Actions
	And I select New Role from Actions
	And I enter the random role Name AutomationRole
	#Workflow name wil be prefixed with a random number
	And I click on the Save Button
	And I confirm the role Name
	When I press Details & Actions
	And I select Readers from Details & Actions
	And I Click on the Add users to readers Button
	Then the User Selector is opened
	And I search for user administrator in User Selector
	And I select the record administrator using column Username from the User Selector table
	And I Click on the Add user selector Button
	And I click on the Save Button
	And I select the record administrator using column Username from the Users that can read table
	And I Click on the Remove users from readers Button
	And I click on the Save Button
	And I press Details & Actions
	And I select Properties from Details & Actions
	And I Click on the Delete role Button
	And I Confirm the Delete
