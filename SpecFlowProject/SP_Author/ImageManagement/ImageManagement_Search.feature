Feature: ImageManagement_Search
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


Background: SuportPoint is open
Given I have logged in to SP as a new "authors"
#need to create test image
And I Open SP Manager to Document Management : SupportPoint

@ImageManagement_SearchBy
	Scenario: 1.1_Search By ID
	Given I am at Document Management page
	And I Navigate to the Images Page
	When  I am at Image Management page
	And I search for image by ID for 2925 text
	Then the search should return the image record

@ImageManagement_SearchBy
	Scenario: 1.2_Search By Name
	Given I am at Document Management page
	And I Navigate to the Images Page
	When  I am at Image Management page
	And I search for image by Name for Test text
	Then the search should return the image record

@ImageManagement_SearchBy
	Scenario: 1.3_Search By CustomProperty
	Given I am at Document Management page
	And I Navigate to the Images Page
	When  I am at Image Management page
	And I search for image by Custom property for automation text
	Then the search should return the image record

