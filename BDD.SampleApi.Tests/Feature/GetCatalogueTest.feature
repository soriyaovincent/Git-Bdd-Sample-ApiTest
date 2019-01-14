@SampleApiTests
Feature: Get catalogue details tests
	In order to retrieve catalogue details
	I want to call the categories endpooint

Background: 
	Given I send a call to sample API endpoint with "?catalogue==false" parameter

Scenario: Get Catalogue Name Test
	When I GET the resposne from the sample API endpoint
	Then the catalogue name should be "Carbon credits"

Scenario: Get CanRelist value Test
	When I GET the resposne from the sample API endpoint
	Then the CanRelist should be "true"

Scenario: Get promotion element details test
	When I GET the resposne from the sample API endpoint
	Then I should should see that the promotion element where name is "Gallery" has a description of "2x larger image"