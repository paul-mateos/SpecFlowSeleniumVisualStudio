Feature: ImageManagement_Search
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


Background: SuportPoint is open
Given SupportPoint is opened
And I login as a valid user with login is paul and password is p
Then I Open SP Manager

@_ImageManagement_SearchBy
Scenario: Search By Name
	Given I am at Document Management page
	And I Navigate to the Image Page
