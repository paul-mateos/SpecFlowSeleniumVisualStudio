Feature: DocumentManagement_Search
	In order to search for document
	As an author with valid role access
	I want to be able to search for documents by different search types

Background: SuportPoint is open
Given SupportPoint is opened
And I login as a valid user with login is paul and password is p
Then I Open Author

@2_DocumentManagement_SearchBy
Scenario Outline: Search By Name
	Given I am at Document Management page
	When I search by <FindBy> for <searchText>
	Then the search should retun the record by FindBy

Examples: 
| FindBy      | searchText          |
| ID          | 3494                |
| Name        | Welcome             |
| Description | VX TOSCA Automation |