Feature: PlayerGoesFirst
	In order to play first
	I have to configurate the game as first player
	And make my first move

@mytag
Scenario: Player moves first
	Given I am the first player in a 3 columns and rows grid	
	When I enter the position 5 for my mark position
	Then an X is positioned in the 5 element
	And the computer makes it first move to 0 element

Scenario: Player moves first to different position
	Given I am the first player in a 9 columns and rows grid	
	When I enter the position 3 for my mark position
	Then an X is positioned in the 3 element
	And the computer makes it first move to 0 element 

