Feature: DocumentManagement_SelectMultipleFolders
In order to select multiple Folders
	As an author
	I want to be able to select a multiple Folders

	Background: SupportPoint is open
	Given SupportPoint is opened
	And I login as a valid user with login is paul and password is p
	Then I Open SP Manager
	
@DocumentManagement_SelectMultipleFolders
Scenario Outline: Select multiple Folders
	Given I am at Document Management page
	When I select the Home,Keith DocumentFolder
	Then the correct folder is selected
	When I press Multiple Selection
	Then Your selections screen is displayed
	When I select the {folderString} DocumentFolder
	And I select the recornd by <columnName> with <value>
	#Then the your selections should list the records

	Examples: 
	| columnName | value   |
	| Name       | Report3 |
	| ID         | F1      |

