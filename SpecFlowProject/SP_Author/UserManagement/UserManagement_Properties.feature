Feature: UserManagement_Properties
	In order to manage user properties
	As a role creator
	I want to manage the properties of a user

Background: 
Given I have logged in to SP as a new "rolecreators"
And I Open SP Manager to Document Management : SupportPoint
Then I Navigate to the Users Page

@Regression
@UserManagement_Properties
Scenario: 3.1(2,4)_UserProperties_ChangePassword
	Given I am at User Management page
	And I search for user currentuser in User Management
	And I select the record currentuser using column Username from the User table
	And I press Details & Actions
	And I select Properties from Details & Actions
	When I click on the Change Password Button
	And the User Change Password is opened
	And I enter old password 1
	And I enter new password newpassword
	And I enter confirm password newpassword
	Then I click on the Save button
	And I Click on the Delete user Button
	And I Confirm the Delete

@Regression
@UserManagement_Properties
Scenario: 3.1(3)_UserProperties_Cancel
	Given I am at User Management page
	And I search for user currentuser in User Management
	And I select the record currentuser using column Username from the User table
	And I press Details & Actions
	And I select Properties from Details & Actions
	When I enter the first name testCancelName
	And I click on the Cancel Button
	Then The first name does not equal testCancelName
	And I Click on the Delete user Button
	And I Confirm the Delete
	

