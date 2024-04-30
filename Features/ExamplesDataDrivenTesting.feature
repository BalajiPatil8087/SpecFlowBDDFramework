Feature: Examples Data Driven Testing

Search for the Testers Talk

@TestersTalk
Scenario Outline: Examples Data Driven Testing
	Given Open the browser
	When  Enter the URL
	Then  Search for <searchkey>
	Examples: 
	| searchkey               |
	| specflow by tester talk |
	| selenium by tester talk |