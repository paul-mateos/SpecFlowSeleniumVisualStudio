Feature: Folder Navigation
	In order to get a document
	As a valid user
	I want to navigate folders

@folderNav
Scenario: login as advanced user 
	Given I logged in as advanced user
	When I navigate to Folders
	Then I should see folder view

@folderNav
Scenario: login as configurator user
	Given I logged in as configurator user
	When I navigate to Folders
	Then I should see folder view