Feature: UserManager_RoleMembership


Background: 
Given I have logged in to SP as a new "rolecreators"
And I Open SP Manager to Document Management : SupportPoint
Then I Navigate to the Users Page

@Regression
@UserManagement_Readers
Scenario: 3.2(1,2)_AddUserFromRoles
	Given I search for user currentuser in User Management
	And I select the record currentuser using column Username from the User table
	When I press Details & Actions
	And I select Role membership from Details & Actions
	And I Click on the Add user to Roles Button
	And the Role Selector is opened
	And I select the record authors using column Role from the Role Selector table
	And I Click on the Add roles Button
	Then I click on the Save Button
	And I select the record authors using column Role from the User in roles table
	And I Click on the Remove user from roles Button
	And I click on the Save Button
	And I press Details & Actions
	And I select Properties from Details & Actions
	And I Click on the Delete user Button
	And I Confirm the Delete
	
