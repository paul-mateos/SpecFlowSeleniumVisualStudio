﻿Feature: ImageManagement_ImageProperties
	In order to change the image properties
	As a valid user
	I want to confirm that this can be done

Background: SuportPoint is open
Given SupportPoint is opened
And I login as a valid user with login is paul and password is p
Then I Open SP Manager

@2.2.1.1_ImageManagement_MoveToFolder
Scenario: Move Image To Folder
	Given I am at Document Management page
	And I Navigate to the Images Page
	And  I am at Image Management page
	And I search for image by ID for 2190
	And the search should return the image record
	When I Click on the Move Button
	And I select the Images Image Popup Folder
	And I Click on the Move Button
	Then the search should return the image record

@2.2.1.2_ImageMnanagement_RemoveFromFolder
Scenario: Remove Image From Folder
	Given I am at Document Management page
	And I Navigate to the Images Page
	And  I am at Image Management page
	And I search for image by ID for 3027
	And the search should return the image record
	When I Click on the Remove Button
	Then I Confirm the Removal
	And I select the Orphans Image Folder
	And the search should return the image record

@2.2.1.3_ImageManagement_CancelChanges
Scenario: Calcel Image Detail Changes
	Given I am at Document Management page
	And I Navigate to the Images Page
	And  I am at Image Management page
	And I search for image by Name for 336a28215c215237ff39636e06e035cb.gif
	And the search should return the image record
	When I enter the Image Name New Name
	Then I click on the Cancel Button
	And the search should return the image record

@2.2.1.4_ImageManagement_SaveChanges
Scenario: Save Image Detail Changes
	Given I am at Document Management page
	And I Navigate to the Images Page
	And  I am at Image Management page
	And I search for image by Name for 336a28215c215237ff39636e06e035cb.gif
	And the search should return the image record
	When I enter the Image Name New Image Name
	Then I click on the Save Button
	And I confirm the Image Name
	And I enter the Image Name 336a28215c215237ff39636e06e035cb.gif
	And I click on the Save Button