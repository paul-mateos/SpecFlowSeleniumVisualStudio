Feature: DocumentManagement_CreateDoument
	In order to create a document
	As an author with valid role access
	I want to create documents of different types

	#This test case need to have a template created with a specific name


Background: SuportPoint is open
Given I have logged in to SP as a new "authors"
#And I create test data for Document Type Template
Then I Open SP Manager

@4.1.2.1_DocumentManagement_CreateNewDocument
Scenario: Create new Documents From Template
	Given I am at Document Management page
	And I select the Home DocumentFolder
	When I press Details & Actions
	And I select new
	And I have selected Document
	And I have entered Type From template Name docTemplateName Description sel_docTemplateDescription
	And I click on the Browse Button
	And I select the record Overview using column Name from the Document Selector table
	And I click on the Add document Button
	And I click on the Save Button
	And I Click on the Remove Button
	And I Confirm the Removal

@4.1.2.2_DocumentManagement_CreateNewDocument
Scenario: Create new Documents From Copy
	Given I am at Document Management page
	And I select the Home DocumentFolder
	When I press Details & Actions
	And I select new
	And I have selected Document
	And I have entered Type Copy Name docCopyName Description sel_docCopyDescription
	And I click on the Save Button

@4.1.2.3_DocumentManagement_CreateNewDocument
Scenario: Create new Documents From Blank
	Given I am at Document Management page
	And I select the Home DocumentFolder
	When I press Details & Actions
	And I select new
	And I have selected Document
	And I have entered Type Blank Name docBlankName Description sel_docBlankDescription
	And I click on the Save Button

#Examples:
#| Type         | Name                         | Description                   |
#| From template |docTemplateName | sel_docTemplateDescription |
#| Copy          |docCopyName     | sel_docCopyDescription     |
#| Blank		   |    selDocument_TopTab1/3     |     selDescription_TopTab1/3  |
	 


 