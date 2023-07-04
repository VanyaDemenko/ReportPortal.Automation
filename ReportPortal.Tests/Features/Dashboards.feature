@UI

Feature: Dashboards Tests


@Low @RP-12
Scenario Outline: 01 User can resize widgets on the Dashboard page
	Given I login as a '<User>' user to ReportPortal
	When I select 'Dashboards' navigation menu option
	And I select the dashboard with 'DEMO DASHBOARD' name on the Dashboards page
	Then I can resize the widget with 'LAUNCH STATISTICS AREA' name using '-113' width and '-73' height on the Dashboard Item page
	And I can resize the widget with 'LAUNCH STATISTICS AREA' name using '113' width and '73' height on the Dashboard Item page

Examples: 
	| User    |
	| Admin   |
	| Default |

@Low @RP-13
Scenario Outline: 02 User can drag and drop widgets on the Dashboard page
	Given I login as a '<User>' user to ReportPortal
	When I select 'Dashboards' navigation menu option
	And I select the dashboard with 'DEMO DASHBOARD' name on the Dashboards page
	Then I can drag and drop the widget with 'LAUNCH STATISTICS AREA' name using '680' position X and '0' position Y on the Dashboard Item page
	And I can drag and drop the widget with 'LAUNCH STATISTICS AREA' name using '-680' position X and '0' position Y on the Dashboard Item page

Examples: 
	| User    |
	| Admin   |
	| Default |

@VeryLow @RP-14
Scenario Outline: 03 User can scroll to component on the Dashboard page
	Given I login as a '<User>' user to ReportPortal
	When I select 'Dashboards' navigation menu option
	And I select the dashboard with 'DEMO DASHBOARD' name on the Dashboards page
	And I scroll to 'Build Number' control at the 'Footer' container on the Dashboard Item page
	Then 'Build Number' control at the 'Footer' container is scrolled into view on the Dashboard Item page

Examples: 
	| User    |
	| Admin   |
	| Default |