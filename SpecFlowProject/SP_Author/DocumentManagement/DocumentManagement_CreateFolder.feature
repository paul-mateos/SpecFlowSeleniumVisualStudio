Feature: DocumentManagement_CreateFolder
	In order to create a Folder
	Login in as Author
	I want to create a Folder

Background: SuportPoint is open
Given SupportPoint is opened
And I login as a valid user with login is sel_author and password is password 
Then I Open SP Manager
#Given I have imported the users/roles file
#Then the User/Role data is created

@mytag
Scenario Outline: Create new Folder
	Given I am at Document Management page
	When I select the Home Folder
	When I press Details & Actions
	And I select new 
	And I have selected Folder
    And I have entered <Type> <Name> <Description> 
	And I press Save
	Examples:
| Type         | Name                | Description |
| Localisation | sel_blankFolderName | sel_blankFolderDescription |


#there are 3 more folder types: Copy, Localisation, Reference, these folder types will be created for specific test 
