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
	Given I select Search Setup using the column Name from the Admin table
	And I enter the following search weighing: 4, 3, 5, 2, 1 
	And I select the Display checkboxes
	And I click on the Save Button
	
