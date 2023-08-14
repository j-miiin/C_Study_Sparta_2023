namespace c_study_week2_5_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// 가위바위보
            //string[] choices = { "가위", "바위", "보" };
            //string playerChoice = "";
            //string computerChoice = choices[new Random().Next(0, 3)];

            //while (playerChoice != computerChoice)
            //{
            //    Console.Write("가위, 바위, 보 중 하나를 선택하세요 ");
            //    playerChoice = Console.ReadLine();

            //    if (playerChoice == computerChoice)
            //    {
            //        Console.WriteLine("비겼습니다.");
            //    } else if (
            //        (playerChoice == "가위" && computerChoice == "보") ||
            //        (playerChoice == "바위" && computerChoice == "가위") ||
            //        (playerChoice == "보" && computerChoice == "바위")
            //        )
            //    {
            //        Console.WriteLine("플레이어 승리!");
            //    } else
            //    {
            //        Console.WriteLine("컴퓨터 승리!");
            //    }
            //}

            // 숫자 맞추기
            int targetNumber = new Random().Next(1, 101);
            int guess = 0;
            int count = 0;
            Console.WriteLine("1부터 100 사이의 숫자를 맞춰보세요.");
            
            while (guess != targetNumber)
            {
                guess = int.Parse(Console.ReadLine());
                count++;

                if (guess > targetNumber)
                {
                    Console.WriteLine("입력한 숫자보다 정답이 작습니다.");
                } else if (guess < targetNumber) {
                    Console.WriteLine("입력한 숫자보다 정답이 큽니다.");
                } else
                {
                    Console.WriteLine("정답입니다!");
                    Console.WriteLine("시도한 횟수 : " + count);
                }
            }

        }
    }
}