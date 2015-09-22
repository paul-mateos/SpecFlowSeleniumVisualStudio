Feature: Administration_SearchSetup
	In order to change the search priorities
	As a valid user
	I want to confirm that this can be done

Background: SuportPoint is open
Given I have logged in to SP as a new "configurators"
Then I Open SP Manager

@2.2.1.1_Administration_ConfigureSearchSettings
Scenario: Move Image To Folder
	Given I am at Document Management page
	And I Navigate to the Admin Page
	And I am at Administration page
	Given I select Search Setup using the column Name from the table
	And I enter the following search weighing: 1, 2, 3, 4, 5 
	And I select the Display checkboxes
	#When I Click on the Move Button
	#And I select the Images Image Popup Folder
	#And I Click on the Move Button
	#Then the search should return the image record
