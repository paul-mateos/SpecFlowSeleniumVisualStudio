Feature: InsertMenu_ImageMap
	I would like to insert an impage map into a document
#This feature requires the creation of an image uploaded to the Images folder	

Background:
	Given I have logged in to SP as a new "advanced_authors"
	And I Open SP Manager to Document Management : SupportPoint
	And I am at Document Management page
	#And I select the Home DocumentFolder
	#When I press Details & Actions
	#And I select New from Details & Actions
	#And I have selected Document
	#Then I have entered Type Reusable content Name docImageMapTest Description documentforimagemap
	#And I click on the Save Button
	And I have created a new document with Type Reusable content Name docImageMapTest Description documentforimagemap


@SP_Editor
@InsertMenu
@ImageMap
@Regression
Scenario: 4.4_InsertMenu_ImageMap
	Given I am at Document Management page
	And I edit the current document
	And I switch to Edit Browser
	And Document docImageMapTest is open for Editing
	When I click on the ImageMap Button
	And the Image Selector is opened
	#This immage needs to be dynamic
	And I search for image by Name for Flag in Image Selector
	And the search should return the image record in Image Selector
	And I click on the Insert Button
	And the Image Mapping is opened
	And I click on the Image Mapping Save Button
	Then Document docImageMapTest is open for Editing 
	And I click on the Editor Save Button
	And the Editor Save is opened
	And I click on the Editor Save Save Button
	#need to verify image has been added
	And I Click on Editor More Menu
	And I select Close from Editor More Menu
	And I switch to Document Management Browser
	And I am at Document Management page
	And I Click on the Remove Button
	And I Confirm the Removal
	

