@UI

Feature: Authorization Tests


@Critical @RP-11
Scenario Outline: 01 User can login and logout from ReportPortal
	Given I login as a '<User>' user to ReportPortal
	Then 'Add New Dashboard' control is 'Displayed' on the Dashboards page

	When I logout from ReportPortal
	Then 'Login Section' control is 'Displayed' on the Login page

Examples: 
	| User    |
	| Admin   |
	| Default |