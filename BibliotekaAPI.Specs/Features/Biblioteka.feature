Feature: Biblioteka
In order to easily get a library
As a costumer of your library
I want to get that library

@GET
Scenario: get
	Given That I have a library
	When I send a GET request with the given library id
	Then I should recieve that library  with the status code 200
	
	@POST
    Scenario: post
	Given the following library:
	| Id | Naziv | BrojRadnika | RadniDani | MjesecnaClanarina |
	| 5  | Gfgfg | 8           | 2         | 7                 | 
	When I send a post request with the given library as content
	Then I should recieve status code 201
		And I should recieve the given library with a random id in the response

    @DELETE
	Scenario: delete
	Given that I delete a library
	When I send a delete request with the given library id
	Then the library should be deleted with the status code 200