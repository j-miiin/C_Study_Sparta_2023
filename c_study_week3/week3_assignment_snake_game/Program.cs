using static System.Net.Mime.MediaTypeNames;

namespace week3_assignment_snake_game
{
    internal class Program
    { 
        const int GAME_BOARD_SIZE = 10;
        const int EMPTY = 0;
        const int SNAKE = 1;
        const int STAR = 2;
        const int FIRST_X = 5;
        const int FIRST_Y = 3;

        static int[] dx = { 0, 1, 0, -1 };
        static int[] dy = {1, 0, -1, 0 };
        static Queue<int[]> queue = new Queue<int[]>();
        static int star_x = 5;
        static int star_y = 7;
        static int dir = 0;      // → : 0, ↓ : 1, ← : 2, ↑ : 3
        static int snakeLength = 3;
        static int star = 0;


        static void Main(string[] args)
        {
            int[,] gameBoard = new int[GAME_BOARD_SIZE, GAME_BOARD_SIZE];

            initSnake(gameBoard);
            gameBoard[star_x, star_y] = STAR;

            Console.Title = "Snake Game";
            Console.WriteLine("Welcome!");
            Console.WriteLine("ESC : 종료");

            Thread.Sleep(1000);

            int curX = FIRST_X;
            int curY = FIRST_Y;
            bool isGameOver = false;

            Thread thread = new Thread(() => getDirection());
            thread.Start();

            while (!isGameOver)
            {
                updateGameBoard(gameBoard);

                int nextX = curX + dx[dir];
                int nextY = curY + dy[dir];

                if (nextX < 0 || nextY < 0 || nextX >= GAME_BOARD_SIZE || nextY >= GAME_BOARD_SIZE ||
                    gameBoard[nextX, nextY] == SNAKE)
                {
                    Console.WriteLine("게임 종료!");
                    Console.WriteLine("뱀 길이 : " + snakeLength);
                    Console.WriteLine("먹은 별의 개수 : " + star);
                    isGameOver = true;
                }
                else
                {
                    moveSnake(nextX, nextY, gameBoard);
                }

                curX = nextX;
                curY = nextY;

                Thread.Sleep(100);
            }
        }

        static void initSnake(int[,] gameBoard)
        {
            gameBoard[5, 1] = SNAKE;
            gameBoard[5, 2] = SNAKE;
            gameBoard[5, 3] = SNAKE;

            queue.Enqueue(new int[] { 5, 1 });
            queue.Enqueue(new int[] { 5, 2 });
            queue.Enqueue(new int[] { 5, 3 }); 
        } 

        static void updateGameBoard(int[,] gameBoard)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("ESC : 종료");
            gameBoard[star_x, star_y] = STAR;
            for (int i = 0; i < GAME_BOARD_SIZE; i++)
            {
                for (int j = 0; j < GAME_BOARD_SIZE; j++)
                {
                    int curBoard = gameBoard[i, j];
                    if (curBoard == EMPTY)
                    {
                        Console.Write("□");
                    } else if (curBoard == SNAKE)
                    {
                        Console.Write("■");
                    } else if(curBoard == STAR)
                    {
                        Console.Write("★");
                    }
                }
                Console.WriteLine();
            }
        }

        static void getDirection()
        {
            ConsoleKeyInfo input;

            while (true)
            {
                input = Console.ReadKey();

                switch (input.Key)
                {
                    case ConsoleKey.RightArrow:
                        dir = 0;
                        break;
                    case ConsoleKey.DownArrow:
                        dir = 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        dir = 2;
                        break;
                    case ConsoleKey.UpArrow:
                        dir = 3;
                        break;
                    case ConsoleKey.Escape:
                        dir = 4;
                        Environment.Exit(0);
                        break;
                }
            }    
        }

        static void moveSnake(int x, int y, int[,] gameBoard)
        {
            if (gameBoard[x, y] == EMPTY)
            {  
                int[] last = queue.Dequeue();
                gameBoard[last[0], last[1]] = EMPTY;
            } else if (gameBoard[x, y] == STAR)
            {
                snakeLength++;
                star++;

                do
                {
                    star_x = new Random().Next(0, GAME_BOARD_SIZE);
                    star_y = new Random().Next(0, GAME_BOARD_SIZE);
                } while (gameBoard[star_x, star_y] == SNAKE);            
            }

            gameBoard[x, y] = SNAKE;
            queue.Enqueue(new int[] { x, y });
        }
    }
}