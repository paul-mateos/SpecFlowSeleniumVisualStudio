Feature: SPLive_Search
	In order search a dcoument in the viewer 
	As an author
	I want to use Supportpoint Live/Search API

#Configure API Key Enable in Admin Portal
#Setup Support with right Environment
Background: 
Given I create a new "authors" user
And I have an apiKey
And I have logged into SupportPoint

@SPLive_Search
Scenario: SPUI-10229_SPLIVE_Show Document
    Given I want to "POST" a request
    And My webservice is "WebService.svc/rest/v1/Live/Search"
	And I have a request body of 
	"""
	"AuthToken":{
	"""
	And I have a request body of 
	"""
		"AuthKey":"",
	"""
	And I have a request body of 
	"""
		"AuthType":1,
		"Instance":"localhost"
	},
	"FindUserBy":0,
	"Query":"test",
	"ShowFirstResult":true,
	"""
	And I have a request body of 
	"""
	"User":"uName"
	"""
	  When waitBeforeRequest
	 When I send request
	 Then waitForResponse
	 And My result is response
	 And Delete user