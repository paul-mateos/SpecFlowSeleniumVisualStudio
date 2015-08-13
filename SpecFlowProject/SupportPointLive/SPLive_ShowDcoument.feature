Feature: SPLive_ShowDcoument
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


	
@mytag
	Scenario: Call Show Document
		Given a API definition "http://qa-spui-b/WebService.svc/rest/v1/Live/Doc"
		And request type "application/json", Method "POST" and Description "Show a document to a user"
		And request body
		 """
		{
			"Actions":"String content",
			"AnchorName":"String content",
			"DocumentID":111,
			"FindUserBy":0,
			"PopupMessage":"String content",
			"PromptMessage":"String content",
			"SessionID":2147483647,
			"User":"Viewer",
			"Version":2
		}
		 """		
		When the request is executed
		Then response status is "ok"


		

Scenario: Call Example API with key
Given Api call with url "http://developer.echonest.com/api/v4/artist/similar?"
And api with "api_key" as "BAD_API_KEY", "name" as "radiohead", "format" as "json", "bucket" as "id:CAXFDYO12E2688C130", "limit" as "true"
When  full URL request executed
Then recieved response with Invalid User