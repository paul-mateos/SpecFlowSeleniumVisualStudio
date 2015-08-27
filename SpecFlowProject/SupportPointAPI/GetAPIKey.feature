Feature: GetAPIKey
	In order to get API Key
	As an administrator
	I want to call /APIKey with GET Method 

Scenario: Get APIKey 
    Given I want to "GET" a request
    And My webservice is "WebService.svc/rest_all/ApiKey"
			# Empty fields for username and password to use Environment Credentials
			And I have SessioID with username as "" and password as ""
			#set Empty values to create values in the background
			And I have path variables 
			| Key |  | value |
			| sid |  | ""    |
			 # Create Empty request body when there is no request body
            And I have a request body of 
			"""
			"""

            When I send request
            Then My result is response
			And Get API Key