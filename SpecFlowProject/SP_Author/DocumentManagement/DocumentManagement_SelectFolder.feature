﻿@DocumentManagement_SelectFolder
Feature: DocumentManagement_SelectFolder
	In order to select a Folder
	As an author
	I want to be able to select a Folder by Navigating the Folder tree

	Background: SupportPoint is open
	Given SupportPoint is opened
	#And I login as a valid user with login is paul and password is p
	And I have logged into SupportPoint
	Then I Open SP Manager
	
@2_DocumentManagement_SelectFolder
Scenario: Select a Folder
	Given I am at Document Management page
	When I select the Home,TOSCA Static Documents,For Editor,ED1600_Save Folder
	Then the correct folder is selected

	
