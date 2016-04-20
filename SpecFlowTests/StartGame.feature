Feature: StartGame
	In order to play
	As a human player
	I want to enter the number of columns
	And enter my name 
	And select if I whant to play first
	And enter computer name

@mytag
Scenario: Configure Player as first player
	Given I enter 3 as the number of columns	
	And also I enter "Maxi" as my name
	And also I enter "Hal" as the computer name
	And also I select "Sí" as I whant to start first	
	Then the board should be initialized to 9 elements
	And my player name should show "Maxi" on screen
	And the computer name should be "Hal"
	And my name should be decorated with an "X"

Scenario: Configure Computer as first player
	Given I enter 3 as the number of columns	
	And also I enter "Maxi" as my name
	And also I enter "Hal" as the computer name
	And also I select "No" as I don't whant to start first
	Then the board should be initialized to 9 elements
	And my player name should show "Maxi" on screen
	And the computer name should be "Hal"
	And my name should be decorated with an "O"

Scenario: Configure Player name as "Melinda"
Given I enter 3 as the number of columns	
	And also I enter "Melinda" as my name
	And also I enter "Hal" as the computer name
	And also I select "Sí" as I whant to start first	
	Then the board should be initialized to 9 elements
	And my player name should show "Melinda" on screen
	And the computer name should be "Hal"
	And my name should be decorated with an "X"