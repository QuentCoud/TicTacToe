using System;

namespace SpecFlowTicTacToe
{
    public class TicTacToe
    {
        private char[,] board;
        private char currentPlayer;
        private int movesCount;

        public TicTacToe()
        {
            board = new char[3, 3];
            currentPlayer = 'X';
            movesCount = 0;
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        public bool MakeMove(int row, int col)
        {
            if (row < 0 || row >= 3 || col < 0 || col >= 3 || board[row, col] != ' ')
            {
                return false;
            }

            board[row, col] = currentPlayer;
            movesCount++;
            return true;
        }

        public bool CheckForWin()
        {
            // Check rows, columns, and diagonals
            for (int i = 0; i < 3; i++)
            {
                if ((board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer) ||
                    (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer))
                {
                    return true;
                }
            }

            if ((board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
                (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer))
            {
                return true;
            }

            return false;
        }

        public bool IsDraw()
        {
            return movesCount == 9 && !CheckForWin();
        }

        public void ChangePlayer()
        {
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }

        public char GetCurrentPlayer()
        {
            return currentPlayer;
        }

        public void PrintBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j]);
                    if (j < 2) Console.Write("|");
                }
                Console.WriteLine();
                if (i < 2) Console.WriteLine("-----");
            }
        }
        
        public char GetBoardValue(int row, int col)
        {
            return board[row, col];
        }
    }
}
