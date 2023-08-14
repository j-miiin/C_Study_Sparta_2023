namespace c_study_week2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// if, else 
            //int itemCount = 0;
            //string itemName = "HP 포션";

            //if (itemCount > 0)
            //{
            //    Console.WriteLine($"보유한 {itemName}의 수량 : {itemCount}");
            //} else
            //{
            //    Console.WriteLine($"보유한 {itemName}이 없습니다.");
            //}

            //// else if 
            //int playerScore = 100;
            //string playerRank = "";

            //if (playerScore >= 90)
            //{
            //    playerRank = "Diamond";
            //} else if (playerScore >= 80)
            //{
            //    playerRank = "Platinum";
            //}

            //Console.WriteLine("플레이어의 등급은 {0} 입니다.", playerRank);

            //Console.WriteLine("1: 전사 / 2: 마법사 / 3: 궁수 ");
            //string job = Console.ReadLine();

            //switch (job)
            //{
            //    case "1" :
            //        Console.WriteLine("전사를 선택하셨습니다.");
            //        break;
            //    case "2" :
            //        Console.WriteLine("마법사를 선택하셨습니다.");
            //        break;
            //    default:
            //        Console.WriteLine("궁수를 선택하셨습니다.");
            //        break;
            //}

            //// 홀짝 구분
            //Console.Write("번호를 입력하세요: ");
            //int number = int.Parse(Console.ReadLine());

            //if (number %2 == 0)
            //{
            //    Console.WriteLine("짝수입니다.");
            //} else
            //{
            //    Console.WriteLine("홀수입니다.");
            //}

            //// 등급 출력
            //int playerScore = 100;
            //string playerRank = "";

            //switch (playerScore / 10)
            //{
            //    case 10:
            //    case 9:
            //        playerRank = "Diamond";
            //        break;
            //    case 8:
            //        playerRank = "Platinum";
            //        break;
            //    case 7:
            //        playerRank = "Gold";
            //        break;
            //    case 6:
            //        playerRank = "Silver";
            //        break;
            //    default:
            //        playerRank = "Bronze";
            //        break;
            //}

            //Console.WriteLine(playerRank);

            //// 로그인 프로그램
            //string id = "id";
            //string password = "pw";

            //Console.Write("아이디를 입력하세요: ");
            //string inputId = Console.ReadLine();
            //Console.Write("비밀번호를 입력하세요: ");
            //string inputPassword = Console.ReadLine(); 

            //if (id == inputId && password == inputPassword)
            //{
            //    Console.WriteLine("로그인 성공");
            //} else
            //{
            //    Console.WriteLine("로그인 실패");
            //}

            //// 알파벳 판별
            //Console.Write("문자를 입력하세요: ");
            //char input = Console.ReadLine()[0];

            //if ((input >= 'a' && input <= 'z') || (input >= 'A' && input <= 'Z'))
            //{
            //    Console.WriteLine("알파벳입니다.");
            //} else
            //{
            //    Console.WriteLine("알파벳이 아닙니다.");
            //}

            //// for문
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(i);
            //}

            //// while문
            //int j = 0;
            //while (j < 10)
            //{
            //    Console.WriteLine(j);
            //    j++;
            //}

            //// 구구단 출력
            //for (int i = 1; i <= 9; i++)
            //{
            //    for (int j = 2; j <= 9; j++)
            //    {
            //        Console.Write(j + " x " + i + " = " + (i * j) + "\t");
            //    }
            //    Console.WriteLine();
            //}

            // break, continue
            for (int i = 1; i <= 10; i++)
            {
                if (i %3 == 0)
                {
                    continue;
                }

                Console.WriteLine(i);

                if (i == 7)
                {
                    break;
                }
            }
        }
    }
}