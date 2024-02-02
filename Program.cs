using TicTacToe;

internal class Program
{

    private static void Main(string[] args)
    {
        char[,] board = {
            {' ', '1', '2', '3'},
            {'1', '#', '#', '#'},
            {'2', '#', '#', '#'},
            {'3', '#', '#', '#'}
        };
        GameFunctions tools = new GameFunctions(board);

        Console.WriteLine("Welcome To Tic-Tac-Toe!");
        Console.WriteLine("**********");


        bool gameRunning = true;
        while (gameRunning)
        {
            bool validInput = false;
            while (!validInput)
            {
                tools.printBoard(board);
                Console.WriteLine("Input a column:");
                int col = int.Parse(Console.ReadLine());

                if (col < 4 && col > 0)
                {
                    tools.setUserY(col);
                    Console.WriteLine("Input a row:");
                    int row = int.Parse(Console.ReadLine());
                    validInput = true;
                    if (row < 4 && row > 0)
                    {
                        tools.setUserX(row);
                        validInput = tools.updateGameBoard();
                    }
                    else
                    {
                        Console.WriteLine("Invalid row entered");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid column entered");
                }
            }
            Console.WriteLine("Computer making turn...");
           
            if (!tools.checkGameWon())
            {
                tools.computerTurn();
                Thread.Sleep(1000);
            }
            gameRunning = !tools.checkGameWon();
            if (!gameRunning || tools.checkTie())
            {
                if (tools.checkTie())
                {
                    Console.WriteLine("**********");
                    gameRunning = false;
                }
                else if (tools.getComputerWon())
                {
                    Console.WriteLine("**********");
                    Console.WriteLine("You lost! The Computer wins.");
                }
                else
                {
                    Console.WriteLine("**********");
                    Console.WriteLine("You defeated the mighty Computer!");
                }
            }
        }
        tools.printBoard(tools.getGameBoard());
        
    }
}   