Feature: UserManager_Readers
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Background: 
Given I have logged in to SP as a new "rolecreators"
When I Open SP Manager
Then I Navigate to the Users Page

@Regression
@UserManagement_DetailsAndActions
Scenario: 3.4.1_Readers_AddRoles
	Given I search for user currentuser in User Management
	And I select the record currentuser using column Username from the User table
	And I select the record currentuser using column Username from the User table
	When I press Details & Actions
	And I select Readers from Details & Actions
	And I Click on the Add role(s) to readers Button
	And the Role Selector is opened
	And I select the record authors using column Role from the Role Selector table
	And I Click on the Add roles Button
	Then I click on the Save Button
	And I select the record authors using column Role from the Roles that read table
	And I Click on the Remove role from readers Button
	Then I click on the Save Button

