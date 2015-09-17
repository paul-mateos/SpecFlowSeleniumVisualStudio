Feature: DocumentManagement_FolderProperties
	In order to modify folder properties
	As an author with valid role access
	I want to test different folder property features

Background: SuportPoint is open
#Create test folder
Given I have logged in to SP as a new "authors"
Then I Open SP Manager

@4.1.1.1.1_DocumentManagement_FolderProperties_Move
Scenario: Move Folder to new location
	Given I am at Document Management page
	And I select the Home,Keith DocumentFolder
	And I select the record Eh using column Name from the Document table
	When I Click on the Document Move Button
	And I select the Home Document Selector Folder
	And I Click on the Document Move into Button
	Then I select the Home,Eh DocumentFolder
	And I Click on the Document Move Button
	And I select the Home,Keith Document Selector Folder
	And I Click on the Document Move into Button
	And I select the Home,Keith DocumentFolder
	And I select the record Eh using column Name from the Document table