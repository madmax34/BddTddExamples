Feature: ComputerGoesFirst
	In order to play second
	I have to configurate the game not as first player
	And the computer will make the first move

@mytag
Scenario: Computer goes first
	Given I am the second player in a 3 columns and rows grid	
	When the game starts
	Then the computer automatically makes it first move to 0 element