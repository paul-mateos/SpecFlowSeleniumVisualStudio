Feature: DocumentManagement_CreateFolder
	In order to create a Folder
	Login in as Author
	I want to create a Folder

Background: SuportPoint is open
Given I have logged in to SP as a new "advanced_authors"
#And I create test data for Document Folders (API)
Then I Open SP Manager

@4.1.1.1_DocumentManagement_CreateNewFolder
Scenario: Create new Folder for Blank
	Given I am at Document Management page
	And I select the Home DocumentFolder
	And I press Details & Actions
	And I select New from Details & Actions
	And I have selected Folder
    When I have entered Type Blank Name sel_blankFolderName Description sel_blankFolderDescription 
	And I click on the Save Button
	Then I Click on the Remove Button
	And I Confirm the Removal

@4.1.1.2_DocumentManagement_CreateNewFolder
Scenario: Create new Folder for Copy
	Given I am at Document Management page
	And I select the Home,AutomationFolder DocumentFolder
	And I press Details & Actions
	And I select New from Details & Actions
	And I have selected Folder
    When I have entered Type Copy Name sel_CopyFolderName Description sel_CopyFolderDescription 
	And I click on the Browse Button
	And I select the Home,Templates Document Selector Folder
	And I select the record Processes using column Name from the Document Selector table
	And I click on the Add folder Button
	And I click on the Save Button
	Then I Confirm the Refresh
	And I select the Home,AutomationFolder DocumentFolder
	And I select the record sel_CopyFolderName using column Name from the Document table
	And I press Details & Actions
	And I select Properties from Details & Actions
	And I select General properties from Details & Actions
	And I Click on the Remove Button
	And I Confirm the Removal
	
@4.1.1.3_DocumentManagement_CreateNewFolder
Scenario: Create new Folder for Localisation
	Given I am at Document Management page
	And I select the Home,AutomationFolder DocumentFolder
	And I press Details & Actions
	And I select New from Details & Actions
	And I have selected Folder
    When I have entered Type Localisation Name sel_LocalisationFolderName Description sel_LocalisationFolderDescription 
	And I click on the Browse Button
	And I select the Home,Templates Document Selector Folder
	And I select the record Processes using column Name from the Document Selector table
	And I click on the Add folder Button
	And I click on the Save Button
	Then I Confirm the Refresh
	And I select the Home,AutomationFolder DocumentFolder
	And I select the record sel_LocalisationFolderName using column Name from the Document table
	And I press Details & Actions
	And I select Properties from Details & Actions
	And I select General properties from Details & Actions
	And I Click on the Remove Button
	And I Confirm the Removal

@4.1.1.4_DocumentManagement_CreateNewFolder
Scenario: Create new Folder for Reference
	Given I am at Document Management page
	And I select the Home,AutomationFolder DocumentFolder
	And I press Details & Actions
	When I select New from Details & Actions
	And I have selected Folder
	And I have entered Reference Type
    And I click on the Browse Button
	And I select the Home,Templates Document Selector Folder
	And I select the record Processes using column Name from the Document Selector table
	And I click on the Add folder Button
	Then I click on the Save Button
	And I Click on the Remove Button
	And I Confirm the Removal