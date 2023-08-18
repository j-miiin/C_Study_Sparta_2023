namespace week2_assignment_guess_number_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tryCount = 0;
            int targetNumber = new Random().Next(1, 101);
            int playerNum = 0;
            Console.WriteLine("1부터 100 사이의 숫자를 맞혀보세요!");
            while (playerNum != targetNumber)
            {
                tryCount++;
                Console.Write("숫자를 입력하세요: ");
                playerNum = int.Parse(Console.ReadLine());
                if (playerNum < targetNumber)
                {
                    Console.WriteLine("너무 작습니다!");
                }
                else if (playerNum > targetNumber)
                {
                    Console.WriteLine("너무 큽니다!");
                }
                else
                {
                    Console.WriteLine("축하합니다! {0}번 만에 숫자를 맞추었습니다.", tryCount);
                }         
            }


            //Console.WriteLine("1부터 9 사이의 숫자 3가지를 맞혀보세요!");

            //int[] targetNumbers = new int[3];
            //for (int i = 0; i < targetNumbers.Length; i++)
            //{
            //    targetNumbers[i] = new Random().Next(1, 10);
            //}

            //while (true)
            //{
            //    Console.Write("숫자 3개를 입력하세요: ");
            //    string[] answer = Console.ReadLine().Split(' ');
            //    int[] playerNums = new int[3];
            //    for (int i = 0; i < playerNums.Length; i++)
            //    {
            //        playerNums[i] = int.Parse(answer[i]);
            //    }

            //    int correct = 0;
            //    for (int i = 0; i < targetNumbers.Length; i++)
            //    {
            //        for (int j = 0; j < playerNums.Length; j++)
            //        {
            //            if (targetNumbers[i] == playerNums[j])
            //            {
            //                correct++;
            //                break;
            //            }
            //        }
            //    }

            //    if (correct == 3)
            //    {
            //        Console.WriteLine("정답입니다!");
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("{0}개 맞혔습니다.", correct);
            //    }
            //}
        }
    }
}