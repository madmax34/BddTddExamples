Feature: ControlPlayerPositioning
	In order to avoid positioning my mark in a previous occupied position
	As a user
	I whant the system to warn me that the position is taken

@mytag
Scenario: Select allready taken position
	Given I select position 5
	And position 5 is allready taken
	Then the system should warn me