Feature: UserManager_Readers


Background: 
Given I have logged in to SP as a new "rolecreators"
And I Open SP Manager to Document Management : SupportPoint
Then I Navigate to the Users Page

@Regression
@UserManagement_Readers
Scenario: 3.4(1,2)_AddRolesToReaders
	Given I search for user currentuser in User Management
	And I select the record currentuser using column Username from the User table
	When I press Details & Actions
	And I select Readers from Details & Actions
	And I Click on the Add role(s) to readers Button
	And the Role Selector is opened
	And I select the record authors using column Role from the Role Selector table
	And I Click on the Add roles Button
	Then I click on the Save Button
	And I select the record authors using column Role from the Roles that read table
	And I Click on the Remove roles from readers Button
	And I click on the Save Button
	And I press Details & Actions
	And I select Properties from Details & Actions
	And I Click on the Delete user Button
	And I Confirm the Delete
	


@Regression
@UserManagement_Readers
Scenario: 3.4(3,4)_AddUsersToReaders
	Given I search for user currentuser in User Management
	And I select the record currentuser using column Username from the User table
	When I press Details & Actions
	And I select Readers from Details & Actions
	And I Click on the Add users to readers Button
	And the User Selector is opened
	And I search for user administrator in User Selector
	And I select the record administrator using column Username from the User Selector table
	And I Click on the Add user Button
	Then I click on the Save Button
	And I select the record administrator using column Username from the Users that read table
	And I Click on the Remove users from readers Button
	Then I click on the Save Button
	And I press Details & Actions
	And I select Properties from Details & Actions
	And I Click on the Delete user Button
	And I Confirm the Delete
