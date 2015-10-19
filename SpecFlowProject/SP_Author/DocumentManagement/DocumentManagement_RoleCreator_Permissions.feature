Feature: DocumentManagement_RoleCreator_Permissions
	
Background: SuportPoint is open
Given I have logged in to SP as a new "rolecreators"
Then I Open SP Manager

#Data setup has already been done in qa-b.pv.local where these tests will be run


@15.10_DocumentPermissions
Scenario: RoleCreator_WithoutPermissions
	Given I am at Document Management page
	And I select the Home,WithoutPermissions DocumentFolder
	And I press Details & Actions
	And I select New from Details & Actions
	And I have entered Type Blank Name TestFolderWOP Description Folder Without Permissions
	And I click on the Save Button
	And I select the Home,WithoutPermissions,TestFolderWOP DocumentFolder
	And I press Details & Actions
	And I select Permisions from Details & Actions
	And I view Wrtiers permission settings
	And I make Roles in writers permission: permission table empty
	And I confirm folder icon for Home,WithoutPermissions,TestFolderWOP is set to No read/write access
	And I view Permissions admin permission settings
	And I make Roles in permissions administrators: permission table empty
	And I confirm folder icon for Home,WithoutPermissions,TestFolderWOP is set to No write access
	
