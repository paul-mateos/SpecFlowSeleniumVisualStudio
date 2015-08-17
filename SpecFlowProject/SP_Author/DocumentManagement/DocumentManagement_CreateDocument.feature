Feature: DocumentManagement_CreateDoument
	In order to create a document
	As an author with valid role access
	I want to create documents of different types

Background: SuportPoint is open
Given SupportPoint is opened
And I login as a valid user with login is author and password is a
Then I Open SP Manager
Given I have imported the users/roles file
Then the User/Role data is set up

@mytag
Scenario: Add two numbers
	Given I am at Document Management page
	When I select the sel_blankFolderName Folder
	Then SP navigates to the sel_blankFolderName & the folder is expanded
	When I press Details & Actions
	And I select new 
	And I have entered Document, Type, Name, Source, Description into the Folder, Type, Name, Source, Description
	And I press Save
	Then the result should be new folders added

	Examples: 
| Type          | Name                | Source                     | Description                |
| From Template | sel_docTemplateName | Procedure - 3 tab          | sel_docTemplateDescription |
| Copy          | sel_docCopyName     | sel_docTemplateDescription | sel_docCopyDescription     |
| Blank         | sel_docBlank_TopTab1/3    | Top tabs_1/3 screen       | sel_docBlankDescription_TopTab1/3    | 
| Blank         | sel_docBlank_TopTab1/3    | Top tabs_1/3 screen       | sel_docBlankDescription_TopTab1/3    | 
| Blank         | sel_docBlank_TopTab1/3    | Top tabs_1/3 screen       | sel_docBlankDescription_TopTab1/3    |	 


 