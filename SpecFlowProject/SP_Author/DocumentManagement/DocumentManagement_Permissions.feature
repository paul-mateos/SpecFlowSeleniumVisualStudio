﻿Feature: DocumentManagement_Permissions
	In order to change the document permissions
	Login as a user in the rolecreator role
	Select document and update the permissions

Background: SuportPoint is open
Given I have logged in to SP as a new "rolecreators"
Then I Open SP Manager
#Need to set up test data with folder and documentname
#Need to delete the test data after scenario is executed

@mytag
Scenario: Rolecreators can't Edit a document
Given I am at Document Management page
When I select the Home DocumentFolder
And I select Welcome using the column Name from the table
And I select New from Details & Actions
And I select Permissions from Details & Actions
Then I verify the Edit button isn't Visible


@mytag
Scenario Outline: Rolecreators can't update document permissions
Given I select the Add role to readers button
Then the Role Selector is opened
And I can search for <searchText>
Then the search should return the <searchText> 
And I can select the <searchText>
Then the role is added to the document role readers table

Examples:
| searchText |
| authors    |
