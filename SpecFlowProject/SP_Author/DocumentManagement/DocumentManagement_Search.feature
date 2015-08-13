Feature: DocumentManagement_Search
	In order search for document
	As an author with valid role access
	I want to be able to search for documents by different search types
	#test
Background: SuportPoint is open
Given SupportPoint is opened
And I login as a valid user with login is paul and password is p
Then I Open SP Manager

@2.1_SearchByID
Scenario: Search By Name
	Given I am at Document Management page
	When I search by Name for Automation Document
	Then the search should retun the record by name

