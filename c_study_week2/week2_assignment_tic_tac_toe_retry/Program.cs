using System.Data;

namespace week2_assignment_tic_tac_toe_retry
{
    internal class Program
    {
        const int PLAYER_1 = 1;
        const int PLAYER_2 = 2; 

        static int[,] gameBoard;
        static Dictionary<int, int[]> matchNumToArray;
        static void Main(string[] args)
        {
            gameBoard = new int[3, 3];
            matchNumToArray = new Dictionary<int, int[]>();

            int dicIdx = 1;
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    matchNumToArray.Add(dicIdx, new int[] { i, j });
                    dicIdx++;
                }
            }

            int gameOver = 0;
            int turn = 1;
            Console.WriteLine("플레이어 1: X 와 플레이어 2: O");
            Console.WriteLine();
            while (gameOver == 0)
            {
                printGameBoard();
                if (turn % 2 != 0)
                {
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine("플레이어 1의 차례");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("선택: ");
                    int select = int.Parse(Console.ReadLine());
                    int[] playerSelect = matchNumToArray.GetValueOrDefault(select);
                    int x = playerSelect[0];
                    int y = playerSelect[1];
                    gameBoard[x, y] = PLAYER_1;
                    gameOver = isGameOver();
                    if (gameOver == 1)
                    {
                        Console.WriteLine("Player1 승리!");
                    }
                } else
                {
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine("플레이어 2의 차례");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("선택: ");
                    int select = int.Parse(Console.ReadLine());
                    int[] playerSelect = matchNumToArray.GetValueOrDefault(select);
                    int x = playerSelect[0];
                    int y = playerSelect[1];
                    gameBoard[x, y] = PLAYER_2;
                    gameOver = isGameOver();
                    if (gameOver == 2)
                    {
                        Console.WriteLine("Player2 승리!");
                    }
                }
                turn++;
                if (checkDraw())
                {
                    Console.WriteLine("무승부!");
                    gameOver = 3;
                }
            }
        }

        static void printGameBoard()
        {
            string blank2 = "  ";
            string blank5 = "     ";
            string blank5_with_wall = "|     |";
            string blank2_with_wall1 = "|  ";
            string blank2_with_wall2 = "  |";
            string under_bar = "_____";
            string under_bar_with_wall = "|_____|";

            Console.SetCursorPosition(0, 7);
            //foreach (KeyValuePair<int, int[]> entry in matchNumToArray)
            //{
            //    int key = entry.Key;
            //    int curX = entry.Value[0];
            //    int curY = entry.Value[1];
            //    int curState = gameBoard[curX, curY];
            //    string curMark = "";
            //    if (curState == PLAYER_1) curMark = player1;
            //    else if (curState == PLAYER_2) curMark = player2;
            //    else curMark = key.ToString();
            //}

            int idx = 1;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(blank5 + blank5_with_wall + blank5);

                Console.Write(blank2 + getMark(idx++) + blank2);
                Console.Write(blank2_with_wall1 + getMark(idx++) + blank2_with_wall2);
                Console.WriteLine(blank2 + getMark(idx++) + blank2);

                if (i != 2) Console.WriteLine(under_bar + under_bar_with_wall + under_bar);
                else Console.WriteLine(blank5 + blank5_with_wall + blank5);
            }
        }

        static string getMark(int idx)
        {
            string player1 = "X";
            string player2 = "O";

            int curX = matchNumToArray.GetValueOrDefault(idx)[0];
            int curY = matchNumToArray.GetValueOrDefault(idx)[1];
            int curState = gameBoard[curX, curY];
            string curMark = "";
            if (curState == PLAYER_1) curMark = player1;
            else if (curState == PLAYER_2) curMark = player2;
            else curMark = idx.ToString();

            return curMark;
        }

        static int isGameOver()
        {
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                int correct = 0;
                int cur = gameBoard[i, 0];
                for (int j = 1; j < gameBoard.GetLength(1); j++)
                {
                    if (gameBoard[i, j] == cur)
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

        static bool checkDraw()
        {
            bool result = true;

            for (int i = 0; i < gameBoard.GetLength(0); i++) { 
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    if (gameBoard[i, j] == 0) return false;
                }
            }

            return result;
        }
    }
}