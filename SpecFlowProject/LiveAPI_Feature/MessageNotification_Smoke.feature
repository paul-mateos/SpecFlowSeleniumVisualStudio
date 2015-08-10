Feature: MessageNotification Rainy day scenarios
 # - Examples: API key
   # | key  |  Description          |
   # | key  |  valid API key        |
   # | Invalidkey |  invalid API key| 

  #- Examples: Users
  #- | User Name   | Password | UserId | Description                           |
  #- | viewer      | viewer   | 123    | valid user with doc viewer permission |
  #- | viewer1     | viewer1  | 124    | valid user with doc viewer permission |
  #- | invalidUser |          |        | user doesn't exist                    |

  #-  Examples: Documents
  #-  | docuementId | Description |
  #-  |  111         | has 3 versions: 1.0, 2.0, 3.0 ; 
  #-                 version 1.0 has 1 page and 1 section, 1 achor
  #-                  version 2.0 has 2 pages and 2 sections with 1 section and 1 achor on each page, each page has different content 
  #-				   version 3.0 has 3 pages and 3 sections with 1 section  and 1 achor on each page, each page has different content |
  #-  |  222         | invalid document ID|
 	
	
Background:
    Given I login as a valid user with login is viewer and password is viewer

@MessageNotification.ErrorCode
Scenario Outline: OpenDocument API: Invalid Values
	When a OpenDocument is issued with <ApiKey> <FindUserBy> <User> <DocumentID> <Version> <SectionID> <AnchorName> <DateTime> <Description> <Actions> <PageContentToVerify>
	Then I should get an <ErrorCode> in API response

  Examples: Invalid ApiKey
  | ApiKey        | FindUserBy | User   | DocumentID | Version | SectionID | AnchorName | DateTime | Description | Actions | PageContentToVerify | ErrorCode |
  | Invalidkey    |            | viewer | 111        | 1.0     |           |            |          |             |         |                     |   401     |
  
   Examples: Invalid User
  | ApiKey | FindUserBy | User   | DocumentID | Version | SectionID | AnchorName | DateTime | Description | Actions | PageContentToVerify | ErrorCode |
  | key    | id         | viewer |  111        | 1.0     |           |            |          |             |         |                     |   400     |
 
   Examples: Invalid DocID
  | ApiKey | FindUserBy | User   | DocumentID | Version | SectionID | AnchorName | DateTime | Description | Actions | PageContentToVerify | ErrorCode |
  | key    |            | viewer |  222   | 1.0     |           |            |          |             |         |                     |   400     |
 

@MessageNotification.ErrorCode
Scenario Outline: DoSearchAPI: Invalid Values
	When a DoSearch is issued with  <ApiKey> <FindUserBy> <User> <Query> <Filters> <DateTime> <Description> <ShowFirstResult> <Actions> <DocsShouldShow>
	Then I should get an <ErrorCode> in API response

  Examples: Invalid ApiKey
    | ApiKey     | FindUserBy | User   | Query                    | Filters | DateTime | Description | ShowFirstResult | Actions | NumOfDocsShouldShow | ErrorCode |
    | invalidkey |            | viewer | ActionOnDoSearch2Results |         |          | search      | false           |         |                     |    401    |
  
  Examples: Invalid User
   | ApiKey     | FindUserBy | User   | Query                    | Filters | DateTime | Description | ShowFirstResult | Actions | NumOfDocsShouldShow | ErrorCode |
   | key        |   id       | viewer | ActionOnDoSearch2Results |         |          | search      | false           |         |                     |    400    |
 
@MessageNotification.ErrorCode
Scenario Outline: DoCshSearch API - Invalid value
	When a DoCshSearch is issued with  <ApiKey> <FindUserBy> <User> <Query> <Filters> <DateTime> <Description> <ShowFirstResult> <Actions> <DocsShouldShow>
	Then I should get an <ErrorCode> in API response

  Examples: Invalid ApiKey
    | ApiKey     | FindUserBy | User   | Query                    | Filters | DateTime | Description | ShowFirstResult | Actions | NumOfDocsShouldShow | ErrorCode |
    | invalidkey |            | viewer | ActionOnDoSearch2Results |         |          | search      | false           |         |                     |    401    |
  
   Examples: Invalid User
   | ApiKey     | FindUserBy | User   | Query                    | Filters | DateTime | Description | ShowFirstResult | Actions | NumOfDocsShouldShow | ErrorCode |
   | key        |   id       | viewer | ActionOnDoSearch2Results |         |          | search      | false           |         |                     |    400    |
 

@ignore
@MessageNotification
Scenario: MessageNotification: Notification is cached
Given I am not logged in
And I received Notifications
When I log in 9 days later
Then I should still get these notifications

@ignore
@MessageNotification
Scenario: This list is deleted in Redis Session after 10 days 
Given I am not logged in
And I received Notifications
When I log in 10 days later
Then I should not get notifications
