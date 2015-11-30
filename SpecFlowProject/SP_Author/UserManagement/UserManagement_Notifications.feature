Feature: UserManagement_Notifications

Background: 
Given I have logged in to SP as a new "rolecreators"
And I Open SP Manager to Document Management : SupportPoint
Then I Navigate to the Users Page

@Regression
@UserManagement_Readers
Scenario: 3.6(1,2)_AddnotificationToUser
	Given I search for user currentuser in User Management
	And I select the record currentuser using column Username from the User table
	When I press Details & Actions
	And I select Notifications from Details & Actions
	And I Click on the Add notification to User Button
	And the Document Selector is opened
	And I select the record Welcome using column Name from the Document Selector table
	And I click on the Add document Button
	And I Click on the Add notification to User popup Button
	Then I click on the Save Button
	And I select the record Welcome using column Name from the User has notifications table
	And I Click on the Remove notifications from User Button
	And I click on the Save Button
	And I press Details & Actions
	And I select Properties from Details & Actions
	And I Click on the Delete user Button
	And I Confirm the Delete