Feature: RoleManagement_RoleMembership
	In order to manage role memberships
	As a role creator
	I want to manage role memberships

Background: Logon to SP and navigate to Role Manager
Given I have logged in to SP as a new "rolecreators"
And I Open SP Manager to Document Management : SupportPoint
When I Navigate to the Roles Page
Then I am at Role Management page

@Regression
@RoleManagement_RoleMembership
Scenario: 2.2(1,2)_Manage Role Membership
	Given I click on Actions
	And I select New Role from Actions
	And I enter the random role Name AutomationRole
	#Workflow name wil be prefixed with a random number
	And I click on the Save Button
	And I confirm the role Name
	When I press Details & Actions
	And I select Role membership from Details & Actions
	And I Click on the Add role to Roles Button
	Then the Role Selector is opened
	And I search for role for authors
	And I select the record authors using column Role from the Role Selector table
	And I Click on the Add roles Button
	And I click on the Save Button
	And I select the record authors using column Role from the Role table
	And I Click on the Remove role from Roles Button
	And I click on the Save Button
	And I press Details & Actions
	And I select Properties from Details & Actions
	And I Click on the Delete role Button
	And I Confirm the Delete

	