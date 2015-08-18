Feature: UserManagement_ImportUsers
	In order to Import a User File
	Login in as Administrator
	I want to be to Import a User file

Background: SuportPoint is open
Given SupportPoint is opened
And I login as a valid user with login is panviva and password is Burke6368
Then I Open SP Manager


@mytag
Scenario Outline: Import User File
	Given I am at User Management page
	When I press Action
	When I press Import user, which contains <Username> and <Role>
	And I press Choose File
	And I select the File
	When I press Save
	Then the result should be new users added

	Examples: 
| Username       | Role             |
| sel_adv_author | advanced_authors |
| sel_author     | authors          |
| sel_rolecreator| rolecreators     |