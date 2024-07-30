Feature: TicTacToe
  In order to play a game of TicTacToe
  As players
  We want to ensure the game mechanics work correctly

@gameplay
Scenario: Player makes a valid move
  Given a new TicTacToe game
  When player X makes a move at row 0 and column 0
  Then the cell at row 0 and column 0 should be "X"

@gameplay
Scenario: Player makes an invalid move
  Given a new TicTacToe game
  When player X makes a move at row 0 and column 0
  When player O makes a move at row 0 and column 0
  Then the move should be invalid

@gameplay
Scenario: Player X wins the game
  Given a new TicTacToe game
  When player X makes a move at row 0 and column 0
  And player O makes a move at row 1 and column 0
  And player X makes a move at row 0 and column 1
  And player O makes a move at row 1 and column 1
  And player X makes a move at row 0 and column 2
  When the game is checked for a win
  Then player X should be the winner

@gameplay
Scenario: The game is a draw
  Given a new TicTacToe game
  When player X makes a move at row 0 and column 0
  And player O makes a move at row 0 and column 1
  And player X makes a move at row 0 and column 2
  And player O makes a move at row 1 and column 0
  And player X makes a move at row 1 and column 1
  And player O makes a move at row 1 and column 2
  And player X makes a move at row 2 and column 0
  And player O makes a move at row 2 and column 1
  And player X makes a move at row 2 and column 2
  When the game is checked for a draw
  Then the game should be a draw
