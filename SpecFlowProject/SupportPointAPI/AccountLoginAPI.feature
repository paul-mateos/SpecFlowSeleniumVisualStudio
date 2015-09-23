Feature: AccountLoginAPI
	In order to get Session ID
	As an administrator
	I want to be login and get Session ID

@API_Tests
Scenario: AccountLogin 
            Given I want to "POST" a request
            And My webservice is "WebService.svc/rest_all/Accounts/Login"
			# Empty fields for username and password to use Environment Credentials
			And I have SessioID with username as "" and password as ""
			#set Empty values to create values in the background
			And I have path variables 
			|Key | |value|
			 # Create Empty request body when there is no request body
            And I have a request body of 
			"""
				"ApplicationID":0,
				"ForcedLogin":true,
				"Instance":"localhost",
				"Password":"Burke6368",
				"UserName":"panviva"
			"""
            When I send request
            Then My result is response

