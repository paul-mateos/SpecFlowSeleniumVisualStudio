@Regression
@Viewer
@Document_Miscellaneous
Feature: ViewerDocument_Miscellaneous
	I want to perform miscellaneous tasks on viewer documents

Background: I have logged on to support point as a valid user
Given I have logged in to SP as a new "advanced_authors"
And I am at Viewer Home 


Scenario: VW_Document_Misc_ViewDocumentLocation
	Given I click on the Viewer folder Button
	And I select the SupportPoint Cloud Help,SupportPoint Help / Navigation Viewer Document Folder/File
	When I Click on Editor More Menu
	And I select Miscellaneous from Editor More Menu
	And I select Copy document location from Editor More Menu
	And I click on the Copy Location Cancel Button


	Scenario: VW_Document_Misc_CopyDocument
	Given I click on the Viewer folder Button
	And I select the SupportPoint Cloud Help,SupportPoint Help / Navigation Viewer Document Folder/File
	When I Click on Editor More Menu
	And I select Miscellaneous from Editor More Menu
	And I select Copy from Editor More Menu
	Then I switch to Copy Browser
	And I click on the Copy Cancel Button