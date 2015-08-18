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


		

Scenario: Call Example API with key for Bad Request
Given Api call with url "http://developer.echonest.com/api/v4/artist/similar?"
And api with "api_key" as "BAD_API_KEY", "name" as "radiohead", "format" as "json", "bucket" as "id:CAXFDYO12E2688C130", "limit" as "true"
When  full URL request executed
Then recieved response with Invalid User


Scenario: Call Example FourSquare API
Given Api call with url "https://api.foursquare.com/v2/venues/search?"
#And valid api with "api_key" as "FILDTEOIK2HBORODV", "name" as "lady+gaga", "format" as "json"
And valid area iputs "near" as "Melbourne", "oauth_token" as "5FUM2S1XROBIVNHKGHRHHG1DO0ZZ2WYACXQMEA5XL2WIF2NN&v=20150813"
When full URL request executed
Then recieved response with Valid User

