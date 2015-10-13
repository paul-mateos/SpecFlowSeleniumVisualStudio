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
Scenario Outline: 2_SearchDocument By
	Given I am at Document Management page
	And I search by <FindBy> for <searchText>
	When the search should return the record by FindBy
	And I select the record <searchText> using column <FindBy> from the Document table
	Then I click on the Preview document Button for document <searchText>
	And I confirm the document <searchText> is Open
	And I close the Preview document
Examples: 
| FindBy      | searchText          |
| ID          | 3448                |
| ID          | 21                |

