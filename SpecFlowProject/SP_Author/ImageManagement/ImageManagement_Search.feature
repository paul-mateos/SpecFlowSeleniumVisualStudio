﻿Feature: ImageManagement_Search
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


Background: SuportPoint is open
Given SupportPoint is opened
And I login as a valid user with login is paul and password is p
Then I Open SP Manager

@1.2_ImageManagement_SearchBy
Scenario: Search By Name
	Given I am at Document Management page
	And I Navigate to the Images Page
	When  I am at Image Management page
	And I search for image by Name for Test
	Then the search should return the image record
