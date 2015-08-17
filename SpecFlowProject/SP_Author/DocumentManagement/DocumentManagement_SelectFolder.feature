Feature: DocumentManagement_SelectFolder
	In order to select a Folder
	As an author
	I want to be able to select a Folder by Navigating the Folder tree

	Background: SupportPoint is open
	Given SupportPoint is opened
	And I login as a valid user with login is paul and password is p
	Then I Open SP Manager
	
@mytag
Scenario: Select a Folder
	Given I am at Document Management page
	When I select the Home,Tosca Static Document, For Copy Folder
	Then the correct folder is selected

	
