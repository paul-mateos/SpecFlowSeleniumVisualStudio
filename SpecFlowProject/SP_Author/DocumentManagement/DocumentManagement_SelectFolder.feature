@DocumentManagement_SelectFolder
Feature: DocumentManagement_SelectFolder
	In order to select a Folder
	As an author
	I want to be able to select a Folder by Navigating the Folder tree

	Background: SupportPoint is open
	Given I have logged in to SP as a new "authors"
	Then I Open SP Manager
	
@2_DocumentManagement_SelectFolder
Scenario: Select a Folder
	Given I am at Document Management page
	When I select the Home DocumentFolder
	Then the correct folder is selected

	
