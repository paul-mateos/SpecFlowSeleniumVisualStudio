Feature: UserManager_Writers
	

Background: 
Given I have logged in to SP as a new "rolecreators"
When I Open SP Manager
Then I Navigate to the Users Page

@Regression
@UserManagement_Readers
Scenario: 3.5(1,2)_AddRolesToWriters
	Given I search for user currentuser in User Management
	And I select the record currentuser using column Username from the User table
	When I press Details & Actions
	And I select Writers from Details & Actions
	And I Click on the Add roles to writers Button
	And the Role Selector is opened
	And I select the record authors using column Role from the Role Selector table
	And I Click on the Add roles Button
	Then I click on the Save Button
	And I select the record authors using column Role from the Roles that can edit table
	And I Click on the Remove roles from writers Button
	And I click on the Save Button
	And I press Details & Actions
	And I select Properties from Details & Actions
	And I Click on the Delete user Button
	And I Confirm the Delete
	


@Regression
@UserManagement_Readers
Scenario: 3.5(3,4)_AddUsersToWriters
	Given I search for user currentuser in User Management
	And I select the record currentuser using column Username from the User table
	When I press Details & Actions
	And I select Writers from Details & Actions
	And I Click on the Add users to writers Button
	And the User Selector is opened
	And I search for user administrator in User Selector
	And I select the record administrator using column Username from the User Selector table
	And I Click on the Add user Button
	Then I click on the Save Button
	And I select the record administrator using column Username from the Users that can edit table
	And I Click on the Remove users from writers Button
	Then I click on the Save Button
	And I press Details & Actions
	And I select Properties from Details & Actions
	And I Click on the Delete user Button
	And I Confirm the Delete
