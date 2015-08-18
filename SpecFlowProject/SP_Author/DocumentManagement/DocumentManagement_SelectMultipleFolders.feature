Feature: DocumentManagement_SelectMultipleFolders
In order to select multiple Folders
	As an author
	I want to be able to select a multiple Folders

	Background: SupportPoint is open
	Given SupportPoint is opened
	And I login as a valid user with login is paul and password is p
	Then I Open SP Manager
	
@DocumentManagement_SelectMultipleFolders
Scenario: Select multiple Folders
	Given I am at Document Management page
	When I select the Home,Keith Folder
	Then the correct folder is selected
	When I press Multiple Selection
