using static System.Net.Mime.MediaTypeNames;

namespace week3_assignment_snake_game
{
    internal class Program
    { 
        const int GAME_BOARD_SIZE = 20;
        const int EMPTY = 0;
        const int SNAKE = 1;
        const int STAR = 2;
        const int FIRST_X = 5;
        const int FIRST_Y = 3;
        const int SPEED = 70;

        static int[] dx = { 0, 1, 0, -1 };
        static int[] dy = {1, 0, -1, 0 };
        static Queue<int[]> queue = new Queue<int[]>();   // 뱀 몸통 좌표를 담을 큐
        static int star_x = 5;  // 별의 x 좌표
        static int star_y = 7;  // 별의 y 좌표
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

            Thread.Sleep(1000);

            int curX = FIRST_X;
            int curY = FIRST_Y;
            bool isGameOver = false;

            // 방향키 입력을 받는 Thread 생성
            Thread thread = new Thread(() => getDirection());
            thread.Start();

            while (!isGameOver)
            {
                // 게임 보드 업데이트
                updateGameBoard(gameBoard);

                // 뱀이 다음에 이동할 좌표값
                int nextX = curX + dx[dir];
                int nextY = curY + dy[dir];

                // 벽에 닿거나 뱀의 몸통에 닿으면 게임 종료
                if (nextX < 0 || nextY < 0 || nextX >= GAME_BOARD_SIZE || nextY >= GAME_BOARD_SIZE ||
                    gameBoard[nextX, nextY] == SNAKE)
                {
                    Console.WriteLine("게임 종료!");
                    isGameOver = true;
                    Environment.Exit(0);
                }
                else
                {
                    moveSnake(nextX, nextY, gameBoard);
                }

                curX = nextX;
                curY = nextY;

                Thread.Sleep(SPEED);
            }
        }

        // 처음 뱀의 위치를 보드에 그림
        static void initSnake(int[,] gameBoard)
        {
            gameBoard[5, 1] = SNAKE;
            gameBoard[5, 2] = SNAKE;
            gameBoard[5, 3] = SNAKE;

            queue.Enqueue(new int[] { 5, 1 });
            queue.Enqueue(new int[] { 5, 2 });
            queue.Enqueue(new int[] { 5, 3 }); 
        } 

        // 게임 보드 업데이트 
        static void updateGameBoard(int[,] gameBoard)
        {
            Console.SetCursorPosition(0, 0);    // 보드를 (0,0)부터 그리기 위해 커서 좌표 이동
            Console.WriteLine("ESC : 종료");
            gameBoard[star_x, star_y] = STAR;   // 게임 보드 위에 별 좌표 설정
            for (int i = 0; i < GAME_BOARD_SIZE; i++)
            {
                for (int j = 0; j < GAME_BOARD_SIZE; j++)
                {
                    int curBoard = gameBoard[i, j];
                    if (curBoard == EMPTY)
                    {
                        Console.Write("□"); // 빈공간
                    } else if (curBoard == SNAKE)
                    {
                        Console.Write("■"); // 뱀
                    } else if(curBoard == STAR)
                    {
                        Console.Write("★"); // 별
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("뱀 길이 : " + snakeLength);
            Console.WriteLine("먹은 별의 개수 : " + star);
        }

        // 방향키 입력을 받아서 뱀의 이동 방향 바꾸기
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

        // 다음 좌표로 뱀 이동시키기 (이동할 x  좌표, 이동할 y 좌표, 게임보드)
        static void moveSnake(int x, int y, int[,] gameBoard)
        {
            // 다음에 이동할 좌표가 빈칸일 때
            if (gameBoard[x, y] == EMPTY)
            {  
                int[] last = queue.Dequeue();   // 뱀의 꼬리 부분 한칸 없애기
                gameBoard[last[0], last[1]] = EMPTY;
            } 
            // 다음에 이동할 좌표가 별일 때
            else if (gameBoard[x, y] == STAR)
            {
                snakeLength++;  // 뱀의 몸 길이 증가
                star++;     // 먹은 별 개수 증가

                // 빈칸 중에서 임의로 골라 별 좌표 업데이트
                do
                {
                    star_x = new Random().Next(0, GAME_BOARD_SIZE);
                    star_y = new Random().Next(0, GAME_BOARD_SIZE);
                } while (gameBoard[star_x, star_y] == SNAKE);            
            }

            gameBoard[x, y] = SNAKE;    // 다음 이동할 좌표를 뱀으로 바꿔줌
            queue.Enqueue(new int[] { x, y });  // 뱀 몸통 업데이트
        }
    }
}