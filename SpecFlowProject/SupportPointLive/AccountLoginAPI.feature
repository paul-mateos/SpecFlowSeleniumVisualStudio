Feature: AccountLoginAPI
	In order to get Session ID
	As an administrator
	I want to be login and get Session ID

Scenario: AccountLogin 
            Given I want to "POST" a request
            And My webservice is "WebService.svc/rest_all/Accounts/Login"
			And I have path variables 
			|Key | |value|

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

