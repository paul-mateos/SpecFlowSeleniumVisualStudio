@documentManagementSearchFeature
Feature: DocumentManagement_Search
	In order to search for document
	As an author with valid role access
	I want to be able to search for documents by different search types

Background: SuportPoint is open
Given I have logged in to SP as a new "authors"
Then I Open SP Manager

@DocumentManagement_SearchBy
@Regression
Scenario Outline: 2_Search By
	Given I am at Document Management page
	When I search by <FindBy> for <searchText>
	Then the search should return the record by FindBy
Examples: 
| FindBy      | searchText          |
| ID          | 3                |

