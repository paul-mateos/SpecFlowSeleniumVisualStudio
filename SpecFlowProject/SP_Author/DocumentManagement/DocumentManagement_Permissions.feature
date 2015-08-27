Feature: DocumentManagement_Permissions
	In order to change the document permissions
	Login as a user in the rolecreator role
	Select document and update the permissions

Background: SuportPoint is open
Given SupportPoint is opened
When I login as a valid user with login is sel_rolecreator and password is password
Then I Open SP Manager


@mytag
Scenario: Rolecreators can't Edit a document
Given I am at Document Management page
# When I select the Home,sel_blankFolderName Folder
#  And I select the sel_blankDocumentName Document
And I navigate to the permissions page
Then I verify the Edit button isn't Visible


@mytag
Scenario: Rolecreators can't update document permissions
Given I select the Add role to readers button
Then the Role Selector is opened
And I can select a role
Then the rold is added to the read document table
