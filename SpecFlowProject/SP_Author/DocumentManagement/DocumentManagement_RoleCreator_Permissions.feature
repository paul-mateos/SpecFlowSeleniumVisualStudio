Feature: DocumentManagement_RoleCreator_Permissions
	
Background: SuportPoint is open
Given I have logged in to SP as a new "rolecreators"
Then I Open SP Manager

#Data setup has already been done in qa-b.pv.local where these tests will be run


@15.10_DocumentPermissions
Scenario: RoleCreator_FolderWithoutRolePermissions - Folder Icons
	Given I am at Document Management page
	And I select the Home,Hussein DocAdmin Tests,WithoutPermissions DocumentFolder
	And I press Details & Actions
	And I select New from Details & Actions
	And I have entered Type Blank Name TestFolderWOP Description Folder Without Permissions
	And I click on the Save Button
	And I select the Home,Hussein DocAdmin Tests,WithoutPermissions,TestFolderWOP DocumentFolder
	And I press Details & Actions
	And I select Permisions from Details & Actions
	And I view Writers permission settings
	And I make Roles in writers permission: permission table empty
	And I confirm folder icon for Home,WithoutPermissions,TestFolderWOP is set to No read/write access
	And I view Permissions admin permission settings
	And I make Roles in permissions administrators: permission table empty
	When I Click on the Add role to readers Button
	And the Role Selector is opened
	And I select the record rolecreators using column Role from the Role Selector table
	And I Click on the Add roles Button
	And I click on the Save Button
	Then I confirm folder icon for Home,Hussein DocAdmin Tests,WithoutPermissions,TestFolderWOP is set to No write access
	And I switch to Home Browser
	#Check folder can be viewed with super viewer setting turned on
	#Check folder can be NOT viewed with super viewer setting turned OFF
	And I switch to Document Management Browser
	And I select the Home,Hussein DocAdmin Tests,WithoutPermissions DocumentFolder
	And I view readers permission settings
	And I make Roles in readers permission: permission table empty
	And I view Writers permission settings
	And I Click on the Add role to writers Button
	And I click on the Save Button
	And I confirm folder icon for Home,Hussein DocAdmin Tests,WithoutPermissions,TestFolderWOP is set to Released
	And I press Details & Actions
	And I select Properties from Details & Actions
	And I select General properties from Details & Actions
	And I Click on the Remove Button
	And I Confirm the Removal


@15.10_DocumentPermissions
Scenario: RoleCreator_FolderWithoutUserPermissions - Folder Icons
	Given I am at Document Management page
	And I select the Home,Hussein DocAdmin Tests,WithoutPermissions DocumentFolder
	And I press Details & Actions
	And I select New from Details & Actions
	And I have entered Type Blank Name TestFolderWOP Description Folder Without Permissions
	And I click on the Save Button
	And I select the Home,Hussein DocAdmin Tests,WithoutPermissions,TestFolderWOP DocumentFolder
	And I press Details & Actions
	And I select Permisions from Details & Actions
	And I view Writers permission settings
	And I make Roles in writers permission: permission table empty
	And I confirm folder icon for Home,WithoutPermissions,TestFolderWOP is set to No read/write access
	And I view Permissions admin permission settings
	And I make Roles in permissions administrators: permission table empty
	#confirm that you cant create a new folder/document within this one
	And I press Details & Actions
	And I select Permisions from Details & Actions
	When I Click on the Add user to readers Button
	And the User Selector is opened
	And I search for user currentuser in User Selector
	And I select the record currentuser using column Username from the User Selector table
	And I Click on the Add user selector Button
	And I click on the Save Button
	Then I confirm folder icon for Home,WithoutPermissions,TestFolderWOP is set to No write access
	And I switch to Home Browser
	#Check folder can be viewed with super viewer setting turned on
	#Check folder can be NOT viewed with super viewer setting turned OFF
	And I switch to Document Management Browser
	And I select the Home,WithoutPermissions DocumentFolder
	And I view readers permission settings
	And I make Users in readers permission: permission table empty
	And I view Writers permission settings
	And I Click on the Add user to writers Button
	And the User Selector is opened
	And I search for user currentuser in User Selector
	And I select the record currentuser using column Username from the User Selector table
	And I Click on the Add user selector Button
	And I click on the Save Button
	And I confirm folder icon for Home,WithoutPermissions,TestFolderWOP is set to Released
	And I press Details & Actions
	And I select Properties from Details & Actions
	And I select General properties from Details & Actions
	And I Click on the Remove Button
	And I Confirm the Removal



	
	
