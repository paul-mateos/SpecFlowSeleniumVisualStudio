Feature: CreateUpdateUserAPI
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

	@Author_CreateUpdaterUser
	Scenario: Author_CreateUpdaterUser 
            Given I want to "POST" a request
            And My webservice is "Webservice.svc/rest_all/Users/CreateUpdate"
			# Empty fields for username and password to use Environment Credentials
			And I have SessioID with username as "" and password as "" 
			And I have path variables 
			|Key | |value|

            And I have a request body of 
			""""
			"SessionID":"",
			"""
			And I have a request body of 
			""""
			"Instance":"localhost",
			"IsDisabled":true,
			"IsSsoUser":true,
			"RoleID":7,
			"User":{
				"Email":"hello@panviva.com",
				"FirstName":"Burke",
				"LastName":"p",
				"Password":"1",
				"UserID":"0",
				"UserName":"burke"
				}
			"""

            When I send request
			#Then New User is Created sucessfully
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