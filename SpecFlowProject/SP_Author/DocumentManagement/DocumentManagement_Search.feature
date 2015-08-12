Feature: DocumentManagement_Search
	In order to search for document
	As an author with valid role access
	I want to be able to search for documents by different search types

Background: SuportPoint is open
Given SupportPoint is opened
And I login as a valid user with login is paul and password is p
Then I Open Author

@2.1_SearchByName
Scenario: Search By Name
	Given I am at Document Management page
	When I search by Name for Automation Document
	Then the search should retun the record by name

@2.1_SearchByID
Scenario: Search By ID
	Given I am at Document Management page
	When I search by Name for Welcome
	Then the search should retun the record by name



