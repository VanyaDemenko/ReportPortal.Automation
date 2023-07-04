@Smoke
@API

Feature: Launches Api Tests


@Critical @RP-1
Scenario Outline: 01 User can get a list of existing launches for the project
	When I try to get a list of launches from '<ProjectName>' project using '<User>' user
	Then I should get a response with '200' status code
	And I should get a valid list of launches

Examples: 
	| User    | ProjectName         |
	| Admin   | SUPERADMIN_PERSONAL |
	| Default | DEFAULT_PERSONAL    |

@High @RP-3
Scenario Outline: 02 User can't get a list of launches for the not existing project
	When I try to get a list of launches from 'NOT_EXISTING_PROJECT' project using '<User>' user
	Then I should get a response with '403' status code
	And I should get an error response with data:
		| ErrorCode | Message                                                                               |
		| 4003      | You do not have enough permissions. Please check the list of your available projects. |

Examples: 
	| User    |
	| Admin   |
	| Default |

@Critical @RP-4
Scenario Outline: 03 User can create, stop and delete a launch for the project
	When I try to create a launch for '<ProjectName>' project using '<User>' user:
		| Description | Name        | StartTime               |
		| Test        | Test Launch | 2023-05-17T09:00:00.000 |
	Then I should get a response with '201' status code

	When I remember id of newly added launch for '<ProjectName>' project as 'LaunchId' variable using '<User>' user
	Then I verify that list of launches contains launch with 'LaunchId' id for '<ProjectName>' project using '<User>' user
	And I verify that the launch with 'LaunchId' id for '<ProjectName>' project contains data using '<User>' user:
		| Description | Name        | Status      |
		| Test        | Test Launch | IN_PROGRESS |
		
	When I stop the launch with 'LaunchId' id for '<ProjectName>' project using '<User>' user:
		| endTime                 |
		| 2023-05-17T09:01:00.000 |
	Then I should get a response with '200' status code
	And I verify that the launch with 'LaunchId' id for '<ProjectName>' project contains data using '<User>' user:
		| Description  | Name        | Status  |
		| Test stopped | Test Launch | STOPPED |

	When I delete the launch with 'LaunchId' id for '<ProjectName>' project using '<User>' user
	Then I should get a response with '200' status code
	And I verify that list of launches doesn't contain launch with 'LaunchId' id for '<ProjectName>' project using '<User>' user

Examples: 
	| User    | ProjectName         |
	| Admin   | SUPERADMIN_PERSONAL |
	| Default | DEFAULT_PERSONAL    |

@Critical @RP-5
Scenario Outline: 04 User can't create a launch with a wrong data for the project
	When I try to create a launch for '<ProjectName>' project using '<User>' user:
		| Description | Name        | StartTime |
		| Test        | Test Launch |           |
	Then I should get a response with '400' status code
	And I should get an error response with data:
		| ErrorCode | Message                                                    |
		| 4001      | Incorrect Request. [Field 'startTime' should not be null.] |

Examples: 
	| User    | ProjectName         |
	| Admin   | SUPERADMIN_PERSONAL |
	| Default | DEFAULT_PERSONAL    |

@Critical @RP-6
Scenario Outline: 05 User can't create a launch for not existing project
	When I try to create a launch for 'NOT_EXISTING_PROJECT' project using '<User>' user:
		| Description | Name        | StartTime               |
		| Test        | Test Launch | 2023-05-17T09:00:00.000 |
	Then I should get a response with '403' status code
	And I should get an error response with data:
		| ErrorCode | Message   |
		| 4003      | <Message> |

Examples: 
	| User    | Message                                                                               |
	| Admin   | You do not have enough permissions. Please check the list of your available projects. |
	| Default | You do not have enough permissions.                                                   |

@Critical @RP-7
Scenario Outline: 06 User can't delete the launch from not existing project
	When I delete the launch with '1' id for 'NOT_EXISTING_PROJECT' project using '<User>' user
	Then I should get a response with '403' status code
	And I should get an error response with data:
		| ErrorCode | Message   |
		| 4003      | <Message> |

Examples: 
	| User    | Message                                                                               |
	| Admin   | You do not have enough permissions. Please check the list of your available projects. |
	| Default | You do not have enough permissions.                                                   |

@Critical @RP-8
Scenario Outline: 07 User can't stop the launch from not existing project
	When I stop the launch with '1' id for 'NOT_EXISTING_PROJECT' project using '<User>' user:
		| endTime                 |
		| 2023-05-17T09:01:00.000 |
	Then I should get a response with '403' status code
	And I should get an error response with data:
		| ErrorCode | Message   |
		| 4003      | <Message> |

Examples: 
	| User    | Message                                                                               |
	| Admin   | You do not have enough permissions. Please check the list of your available projects. |
	| Default | You do not have enough permissions.                                                   |

@High @RP-9
Scenario Outline: 08 User can't stop the stopped launch for the project
	When I try to create a launch for '<ProjectName>' project using '<User>' user:
		| Description | Name        | StartTime               |
		| Test        | Test Launch | 2023-05-17T09:00:00.000 |
	And I remember id of newly added launch for '<ProjectName>' project as 'LaunchId' variable using '<User>' user
	And I stop the launch with 'LaunchId' id for '<ProjectName>' project using '<User>' user:
		| endTime                 |
		| 2023-05-17T09:01:00.000 |
	And I stop the launch with 'LaunchId' id for '<ProjectName>' project using '<User>' user:
		| endTime                 |
		| 2023-05-17T09:01:00.000 |
	Then I should get a response with '406' status code 
	When I delete the launch with 'LaunchId' id for '<ProjectName>' project using '<User>' user

Examples: 
	| User    | ProjectName         |
	| Admin   | SUPERADMIN_PERSONAL |
	| Default | DEFAULT_PERSONAL    |

@High @RP-10
Scenario Outline: 09 User can't get info for the deleted launch from the project
	When I try to create a launch for '<ProjectName>' project using '<User>' user:
		| Description | Name        | StartTime               |
		| Test        | Test Launch | 2023-05-17T09:00:00.000 |
	When I remember id of newly added launch for '<ProjectName>' project as 'LaunchId' variable using '<User>' user
	When I stop the launch with 'LaunchId' id for '<ProjectName>' project using '<User>' user:
		| endTime                 |
		| 2023-05-17T09:01:00.000 |
	When I delete the launch with 'LaunchId' id for '<ProjectName>' project using '<User>' user
	When I try to get info for launch with 'LaunchId' id for '<ProjectName>' project using '<User>' user
	Then I should get a response with '404' status code

Examples: 
	| User    | ProjectName         |
	| Admin   | SUPERADMIN_PERSONAL |
	| Default | DEFAULT_PERSONAL    |