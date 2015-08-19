Feature: CreateUpdateUserAPI
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

	Scenario: CreateUpdateUser 
            Given I want to "POST" a request
            And My webservice is "Webservice.svc/rest_all/Users/CreateUpdate"
			And I have path variables 
			|Key | |value|

            And I have a request body of 
			""""
			"SessionID":"SID",
			"""
			And I have a request body of 
			""""
			"Instance":"localhost",
			"IsDisabled":true,
			"IsSsoUser":true,
			"RoleID":45,
			"User":{
				"Email":"hello@panviva.com",
				"FirstName":"Burke",
				"LastName":"Camberwell",
				"Password":"1",
				"UserID":"0",
				"UserName":"aaaaa"
				}
			"""

            When I send request
            Then My result is response



			 # Scenario Template: GET
             # Given I want to "POST" a request
             # And My host is "qa-spui-b"
			#  And My webservice is "Webservice.svc/rest_all/Users/CreateUpdate"
             # And My Content-Type is "application/json"
			#	And I have path veriables 
			#	|Key | |value|

			#   And I have a request body of "{"":,"";,}"
            #  When I send request
            #  Then My result is response 