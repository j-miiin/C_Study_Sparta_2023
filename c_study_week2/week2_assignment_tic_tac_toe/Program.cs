namespace week2_assignment_tic_tac_toe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] board = new int[3, 3];

            int gameOver = 0;
            while (gameOver == 0)
            {
                Console.Write("Player1 : ");
                string[] player1Choice = Console.ReadLine().Split(',');
                int player1_x = int.Parse(player1Choice[0]);
                int player1_y = int.Parse(player1Choice[1]);
                board[player1_x, player1_y] = 1;

                Console.Write("Player2 : ");
                string[] player2Choice = Console.ReadLine().Split(',');
                int player2_x = int.Parse(player2Choice[0]);
                int player2_y = int.Parse(player2Choice[1]);
                board[player2_x, player2_y] = 2;

                printGameBoard(board);

                gameOver = isGameOver(board);
                if (gameOver == 1)
                {
                    Console.WriteLine("Player1 승리!");
                }
                else if (gameOver == 2)
                {
                    Console.WriteLine("Player2 승리!");
                }
            }
        }

        static void printGameBoard(int[,] gameBoard)
        {
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    if (gameBoard[i, j] == 1)
                    {
                        Console.Write("O");
                    } else if (gameBoard[i, j] == 2)
                    {
                        Console.Write("X");
                    } else
                    {
                        Console.Write(".");
                    }
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }

        static int isGameOver(int[,] gameBoard)
        {
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                int correct = 0;
                int cur = gameBoard[i, 0];
                for (int j = 1; j < gameBoard.GetLength(1); j++)
                {
                    if (gameBoard[i,j] == cur){
                        correct++;
                    } else
                    {
                        break;
                    }
                }
                if (correct == 2)
                {
                    return cur;
                }
            }

            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                int correct = 0;
                int cur = gameBoard[0, i];
                for (int j = 1; j < gameBoard.GetLength(1); j++)
                {
                    if (gameBoard[j, i] == cur)
                    {
                        correct++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (correct == 2)
                {
                    return cur;
                }
            }

            if (
                (gameBoard[0, 0] == gameBoard[1, 1]) && (gameBoard[0, 0] == gameBoard[2, 2]) ||
                (gameBoard[2, 0] == gameBoard[1, 1]) && (gameBoard[2, 0] == gameBoard[0, 2])
            ) return gameBoard[1, 1];

            return 0;
        }
    }
}