﻿Feature: DocumentManagement_CreateDoument
	In order to create a document
	As an author with valid role access
	I want to create documents of different types

	#This test case need to have a template created with a specific name
	#Need to fix the removal button bug so that this script will work


Background: SuportPoint is open
#Given I create the Automation template Folder
Given I have logged in to SP as a new "advanced_authors"
#And I create test data for Document Type Template
And I Open SP Manager to Document Management : SupportPoint

@Regression
@DocumentManagement_CreateNewDocument
Scenario: 4.1.2.1_Create new Documents From Template
	Given I am at Document Management page
	And I select the Home,AutomationFolder DocumentFolder
	When I press Details & Actions
	And I select New from Details & Actions
	And I have selected Document
	Then I have entered Type From template Name docTemplateName Description sel_docTemplateDescription
	And I click on the Browse Button	
	And I select the Home,Templates Document Selector Folder
	And I select the record Overview using column Name from the Document Selector table
	And I click on the Add document Button
	And I click on the Save Button
	And I Click on the Remove Button
	And I Confirm the Removal

@Regression
@DocumentManagement_CreateNewDocument
Scenario: 4.1.2.2_Create new Documents From Copy
	Given I am at Document Management page
	And I select the Home DocumentFolder
	When I press Details & Actions
	And I select New from Details & Actions
	And I have selected Document
	Then I have entered Type Copy Name docCopyName Description sel_docCopyDescription
	And I click on the Browse Button
	And I select the record Welcome using column Name from the Document Selector table
	And I click on the Add document Button
	And I click on the Save Button
	And I Click on the Remove Button
	And I Confirm the Removal

@Regression
@DocumentManagement_CreateNewDocument
Scenario: 4.1.2.3_Create new Documents From Blank
	Given I am at Document Management page
	And I select the Home DocumentFolder
	When I press Details & Actions
	And I select New from Details & Actions
	And I have selected Document
	Then I have entered Type Blank Name docBlankName Description sel_docBlankDescription
	And I click on the Save Button
	And I Click on the Remove Button
	And I Confirm the Removal

@DocumentManagement_CreateNewReuseContentDocument
Scenario: 4.1.2.4_Create new Documents From Reusable Content
	Given I am at Document Management page
	And I select the Home DocumentFolder
	When I press Details & Actions
	And I select New from Details & Actions
	And I have selected Document
	Then I have entered Type Reusable content Name docReusableContentName Description sel_docReusableContentDescription
	And I click on the Save Button
	And I Click on the Remove Button
	And I Confirm the Removal

@Regression
@DocumentManagement_CreateNewDocument
Scenario: 4.1.2.5_Create new Documents From Reference
	Given I am at Document Management page
	And I select the Home DocumentFolder
	When I press Details & Actions
	And I select New from Details & Actions
	And I have selected Document
	Then I have entered Reference Type
	And I click on the Browse Button
	And I select the Home,Templates Document Selector Folder
	And I select the record Overview using column Name from the Document Selector table
	And I click on the Add document Button
	And I click on the Save Button
	And I Click on the Remove Button
	And I Confirm the Removal	 

@Regression
@DocumentManagement_CreateNewDocument
Scenario: 4.1.2.6_Create new Documents From Localisation
	Given I am at Document Management page
	And I select the Home DocumentFolder
	When I press Details & Actions
	And I select New from Details & Actions
	And I have selected Document
	Then I have entered Type Localisation Name docLocalisationName Description sel_docLocalisationDescription
	And I click on the Browse Button
	And I select the Home,Templates Document Selector Folder
	And I select the record Overview using column Name from the Document Selector table
	And I click on the Add document Button
	And I click on the Save Button
	And I Click on the Remove Button
	And I Confirm the Removal	 


 