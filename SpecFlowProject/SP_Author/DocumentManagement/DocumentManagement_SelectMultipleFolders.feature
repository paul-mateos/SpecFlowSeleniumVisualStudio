Feature: DocumentManagement_SelectMultipleFolders
In order to select multiple Folders
	As an author
	I want to be able to select a multiple Folders

	Background: SupportPoint is open
	Given I have logged in to SP as a new "authors"
	And I Open SP Manager
	
@5_DocumentManagement_SelectMultipleFolders
Scenario: Select multiple Folders
	Given I am at Document Management page
	When I select the Home,Keith DocumentFolder
	Then the correct folder is selected
	When I press Multiple Selection
	And I select the record COOL MUFFINS using column Name from the Document table
	And I select the record Welcome 1 using column Name from the Document table
	Then I select the record COOL MUFFINS using column Name from the Multiselect table
	And I select the record COOL MUFFINS using column Name from the Multiselect table

	#Then the your selections should list the records



