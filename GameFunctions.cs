using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TicTacToe
{
    internal class GameFunctions
    {
        public char[,] gameBoard;
        public bool gameWon = false;
        public bool computerWon = false;
        public int userX = 0;
        public int userY = 0;

        public GameFunctions(char[,] board) { 
            gameBoard = board;
        }

        public void printBoard(char[,] board)
        {
            string output = "";
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void computerTurn()
        {
            Random random = new Random();
            int computerX = random.Next(1, 4);
            int computerY = random.Next(1, 4);

            while (gameBoard[computerY, computerX] == 'X' || gameBoard[computerY, computerX] == 'O')
            {
                computerX = random.Next(1, 4);
                computerY = random.Next(1, 4);
                if (checkTie())
                {
                    break;
                }
            }
            if (checkTie())
            {
                Console.WriteLine("TIE GAME!");
            }
            else
            {
                gameBoard[computerY, computerX] = 'O';
            }
        }

        public bool checkTie()
        {
            // Iterate over each cell to check if all are filled
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    if (gameBoard[i, j] == '#') // If an empty cell is found
                    {
                        return false; // It's not a tie
                    }
                }
            }
            return true; // No empty cells found, so it's a tie
        }

        public bool updateGameBoard()
        {
            if (gameBoard[userX, userY] == 'O' || gameBoard[userX, userY] == 'X')
            {
                Console.WriteLine("Space is already taken.");
                return false;
            }
            else
            {
                gameBoard[userX, userY] = 'X';
                return true;
            }
        }

        public char[,] getGameBoard()
        {
            return gameBoard;
        }

        public bool getGameWon()
        {
            return gameWon;
        }

        public bool checkGameWon()
        {
            computerWon = false;
            // Check rows for a win
            for (int i = 1; i <= 3; i++)
            {
                if (gameBoard[i, 1] == 'O' && gameBoard[i, 2] == 'O' && gameBoard[i, 3] == 'O')
                {
                    Console.WriteLine("Won with a row");
                    computerWon = true;
                    return true;
                }
                else if (gameBoard[i, 1] == 'X' && gameBoard[i, 2] == 'X' && gameBoard[i, 3] == 'X')
                {
                    Console.WriteLine("Won with a row");
                    return true;
                }
            }

            // Check columns for a win
            for (int i = 1; i <= 3; i++)
            {
                if (gameBoard[1, i] == 'O' && gameBoard[2, i] == 'O' && gameBoard[3, i] == 'O')
                {
                    Console.WriteLine("Won with a column");
                    computerWon = true;
                    return true;
                }
                else if (gameBoard[1, i] == 'X' && gameBoard[2, i] == 'X' && gameBoard[3, i] == 'X')
                {
                    Console.WriteLine("Won with a column");
                    return true;
                }
            }

            // Check diagonals for a win O
            if ((gameBoard[1, 1] == 'O' && gameBoard[2, 2] == 'O' && gameBoard[3, 3] == 'O') ||
                (gameBoard[1, 3] == 'O' && gameBoard[2, 2] == 'O' && gameBoard[3, 1] == 'O'))
            {
                Console.WriteLine("Won with a cross");
                computerWon = true;
                return true;
            }

            // Check diagonals for a win X
            if ((gameBoard[1, 1] == 'X' && gameBoard[2, 2] == 'X' && gameBoard[3, 3] == 'X') ||
                (gameBoard[1, 3] == 'X' && gameBoard[2, 2] == 'X' && gameBoard[3, 1] == 'X'))
            {
                Console.WriteLine("Won with a cross");
                return true;
            }

            return false;
        }

        public bool getComputerWon()
        {
            return computerWon;
        }

        public void setUserX(int x) { userX = x; }

        public void setUserY(int y) {  userY = y; }
        

    }
}
