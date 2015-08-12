Feature: Add new Rating to a Document
	In order to provide feedbback to a document
	As a Viewer
	I want to add rating to the document

Background: 
    Given a "REST" API definition at "http://swagger.io/"
	#//form[@name='usrForm']//div/ul/li/a
@AddNewRating
Scenario: Add new Document Rating
		Given endpoint "/UserRating" and method "post"
		And request query param "docid" equals 1592 , "version" equals 10, "sid" equals "sessionID" 
		And request type "application/json"
		When the request is executed
		Then response status is "ok"

