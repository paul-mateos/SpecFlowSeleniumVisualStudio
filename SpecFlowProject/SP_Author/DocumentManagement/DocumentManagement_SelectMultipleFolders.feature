Feature: DocumentManagement_SelectMultipleFolders
In order to select multiple Folders
	As an author
	I want to be able to select a multiple Folders

	Background: SupportPoint is open
	#Needs to set up test data so that there are foldres and files that can be selected and renamed
	Given I have logged in to SP as a new "authors"
	And I Open SP Manager to Document Management : SupportPoint
	
@DocumentManagement_SelectMultipleFolders
Scenario: 5_Select multiple Folders
	Given I am at Document Management page
	When I select the Home,Keith DocumentFolder
	Then the correct folder is selected
	When I press Multiple Selection
	And I select COOL MUFFINS using the column Name from the table
	And I select Welcome 1 using the column Name from the table
	Then I select the COOL MUFFINS Grid Record
	And I select the Welcome 1 Grid Record
	And I click on the Apply selection Button
	And I enter the Document Name New MultiSelect Document
	And I click on the Save Button
	And I Confirm the Refresh
	And I am at Document Management page
	And I select New MultiSelect Document using the column Name from the table




