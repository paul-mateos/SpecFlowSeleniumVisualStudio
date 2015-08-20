Feature: DocumentManagement_CreateDoument
	In order to create a document
	As an author with valid role access
	I want to create documents of different types

Background: SuportPoint is open
Given SupportPoint is opened
And I login as a valid user with login is sel_author and password is password 
Then I Open SP Manager
#Given I have imported the users/roles file
#Then the User/Role data is created

@mytag
Scenario Outline: Create new Documents
	Given I am at Document Management page
#	When I select the Home Folder
#	When I select the sel_blankFolderName Folder
	When I press Details & Actions
	And I select new
	And I have selected Document
	And I have entered <Type> <Name> <Description>
#	And I press Save
	Examples:
| Type         | Name                         | Description                   |
| Blank		   |    selDocument_TopTab1/3     |     selDescription_TopTab1/3  |
#| From Template |docTemplateName | sel_docTemplateDescription |
#| Copy          |docCopyName     | sel_docCopyDescription     |
#| Blank         | docBlank_TopTab1/3    | sel_docBlankDescription_TopTab1/3    | 
#| Blank         | docBlank_TopTab1/3    | sel_docBlankDescription_TopTab1/3    | 
#| Blank         | docBlank_TopTab1/3    | sel_docBlankDescription_TopTab1/3    |	 


 