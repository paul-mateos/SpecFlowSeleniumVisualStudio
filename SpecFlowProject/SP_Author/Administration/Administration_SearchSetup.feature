Feature: Administration_SearchSetup
	In order to change the search priorities
	As a valid user
	I want to confirm that this can be done

Background: SuportPoint is open
Given I have logged in to SP as a new "configurators"
Then I Open SP Manager

@2.2.1.1_ImageManagement_MoveToFolder
Scenario: Move Image To Folder
	Given I am at Document Management page
	And I Navigate to the Admin Page
	And  I am at Administration page
	#And I search for image by ID for 2190
	#And the search should return the image record
	#When I Click on the Move Button
	#And I select the Images Image Popup Folder
	#And I Click on the Move Button
	#Then the search should return the image record
