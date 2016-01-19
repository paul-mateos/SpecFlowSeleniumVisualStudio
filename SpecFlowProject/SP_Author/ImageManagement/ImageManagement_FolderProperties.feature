Feature: ImageManagement_FolderProperties
	In order to change the folder properties
	As a valid user
	I want to confirm that this can be done

Background: SuportPoint is open
#Given I have SessioID with username as "" and password as ""
#And I create the Automation Image Folder
#And I created the Test Image in the Automation Folder
Given I have logged in to SP as a new "authors"
And I Open SP Manager to Document Management : SupportPoint

@ImageManagement_Folder
Scenario: 2.1.1.1_Move Folder To Folder
	Given I am at Document Management page
	And I Navigate to the Images Page
	And  I am at Image Management page
	And I search for image by ID for 2190 text
	And the search should return the image record
	When I Click on the Image Move Button
	And I select the Images Image Popup Folder
	And I Click on the Image Move Button
	Then the search should return the image record

@ImageManagement_Folder
Scenario: 2.1.1.2_Remove Folder From Folder
	Given I am at Document Management page
	And I Navigate to the Images Page
	And  I am at Image Management page
	And I search for image by ID for 3027 text
	And the search should return the image record
	When I Click on the Remove Button
	Then I Confirm the Removal
	And I select the Orphans Image Folder
	And the search should return the image record

@ImageManagement_Folder
Scenario: 2.1.1.3_Calcel Folder Detail Changes
	Given I am at Document Management page
	And I Navigate to the Images Page
	And  I am at Image Management page
	And I search for image by Name for 336a28215c215237ff39636e06e035cb.gif text
	And the search should return the image record
	When I enter the Image Name New Name
	Then I click on the Cancel Button
	And the search should return the image record

@ImageManagement_Folder
Scenario: 2.1.1.4_Save Folder Detail Changes
	Given I am at Document Management page
	And I Navigate to the Images Page
	And  I am at Image Management page
	And I search for image by Name for 336a28215c215237ff39636e06e035cb.gif text
	And the search should return the image record
	When I enter the Image Name New Image Name
	Then I click on the Save Button
	And I confirm the Image Name
	And I enter the Image Name 336a28215c215237ff39636e06e035cb.gif
	And I click on the Save Button