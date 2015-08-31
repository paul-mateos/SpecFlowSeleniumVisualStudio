Feature: ImageManagement_Search
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


Background: SuportPoint is open
Given I have logged in to SP as a new "authors"
Then I Open SP Manager

@1_ImageManagement_SearchBy
@1.1_ImageManagement_SearchBy_ID
	Scenario: Search By ID
	Given I am at Document Management page
	And I Navigate to the Images Page
	When  I am at Image Management page
	And I search for image by ID for 2925
	Then the search should return the image record

@1_ImageManagement_SearchBy
@1.2_ImageManagement_SearchBy_Name
	Scenario: Search By Name
	Given I am at Document Management page
	And I Navigate to the Images Page
	When  I am at Image Management page
	And I search for image by Name for Test
	Then the search should return the image record

@1_ImageManagement_SearchBy
@1.3_ImageManagement_SearchBy_CustomProperty
	Scenario: Search By CustomProperty
	Given I am at Document Management page
	And I Navigate to the Images Page
	When  I am at Image Management page
	And I search for image by Custom property for automation
	Then the search should return the image record

