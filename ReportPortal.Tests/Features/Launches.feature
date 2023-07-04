@Smoke
@UI

Feature: Launches Tests


@High @RP-15
Scenario Outline: 01 Correct test run data id displayed for Launch
	Given I login as a '<User>' user to ReportPortal
	When I select 'Launches' navigation menu option
	Then Launch with '<Launch Name>' name has data:
		| Total   | Passed   | Failed   | Skipped   | Product Bug   | Auto Bug   | System Issue   | To Investigate   |
		| <Total> | <Passed> | <Failed> | <Skipped> | <Product Bug> | <Auto Bug> | <System Issue> | <To Investigate> |

Examples: 
	| User    | Launch Name       | Total | Passed | Failed | Skipped | Product Bug | Auto Bug | System Issue | To Investigate |
	| Admin   | Demo Api Tests#9  | 25    | 20     | 5      |         | 4           | 1        |              | 2              |
	| Admin   | Demo Api Tests#7  | 15    | 5      | 9      | 1       | 1           | 5        | 4            | 8              |
	| Default | Demo Api Tests#10 | 30    | 30     |        |         |             |          |              |                |
	| Default | Demo Api Tests#6  | 10    | 1      | 9      |         |             | 1        | 8            | 5              |
	| Default | Demo Api Tests#8  | 20    | 10     | 8      | 2       | 4           | 4        |              | 10             |

@High @RP-16
Scenario Outline: 02 Correct information message is displayed for Launch
	Given I login as a '<User>' user to ReportPortal
	When I select 'Launches' navigation menu option
	Then Launch with '<Launch Name>' name has data:
		| Description           |
		| Demonstration launch. |

Examples: 
	| User    | Launch Name       |
	| Admin   | Demo Api Tests#10 |
	| Admin   | Demo Api Tests#8  |
	| Admin   | Demo Api Tests#6  |
	| Default | Demo Api Tests#9  |
	| Default | Demo Api Tests#7  |