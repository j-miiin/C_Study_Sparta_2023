namespace week3_assignment_blackjack
{
    internal class Program
    {
        const int PLAYER_TYPE = 0;
        const int DEALER_TYPE = 1;

        const int SPADE = 0;
        const int HEART = 1;
        const int DIAMOND = 2;
        const int CLOVER = 3;

        // Ace, 2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King
        const int SIZE = 14;
        const int BLACKJACK = 21;
        
        // 전체 카드 덱
        static Dictionary<int, bool[]> cardDeck = new Dictionary<int, bool[]>();

        // player 손에 있는 카드
        static List<int[]> playerHand = new List<int[]>();

        // dealer 손에 있는 카드
        static List<int[]> dealerHand = new List<int[]>();

        static void Main(string[] args)
        {
            for (int i = 0; i < 4; i++)
            {
                cardDeck.Add(i, new bool[SIZE]);
            }

            int playerMoney = 1000;
            int curBetMoney = 0;
            playerMoney -= curBetMoney;

            Console.WriteLine("Player Money : " + playerMoney);
            Console.Write("베팅 금액 : ");
            curBetMoney = betMoney();   // 플레이어 베팅

            giveCards();    // 딜러가 카드를 돌림

            bool isGameOver = false;
            // 플레이어 플레이 시작
            bool isPlayerEnd = false;
            Console.WriteLine();
            while (!isPlayerEnd)
            {
                Console.WriteLine("플레이 방법을 선택하세요");
                Console.WriteLine("1 : Black Jack");
                Console.WriteLine("2 : Stand");
                Console.WriteLine("3 : Hit");
                Console.WriteLine("4 : Double Down");
                Console.WriteLine("5 : Surrender");
                Console.Write("선택 : ");
                int select = int.Parse(Console.ReadLine());

                Console.WriteLine();
                switch (select)
                {
                    case 1:
                        int result = BlackJack(PLAYER_TYPE);
                        if (result == -1)   // 블랙잭이 아닌 경우
                        {
                            Console.WriteLine("블랙잭이 아닙니다. 다시 고르세요.");
                        } else
                        {
                            isPlayerEnd = true;
                            isGameOver = true;

                            // dealer도 블랙잭인 경우 Push
                            if (BlackJack(DEALER_TYPE) == 1)    
                            {                                
                                Console.WriteLine("Push!");
                            } 
                            // player가 블랙잭에 성공한 경우
                            else
                            {
                                Console.WriteLine("Blak Jack!");
                                playerMoney += (int)(curBetMoney * 1.5);    // 베팅 금액의 1.5배를 얻음
                            }     
                        }
                        break;
                    case 2:
                        isPlayerEnd = true; // Stand 선언한 경우 dealer 플레이 시작
                        break;
                    case 3:                       
                        if (Hit(PLAYER_TYPE))   // player의 hit 선언 후 Bust가 된 경우
                        {
                            Console.WriteLine("Bust!");
                            playerMoney -= curBetMoney;
                            isGameOver = true;
                            isPlayerEnd = true;
                        }
                        // hit 후 player 카드 상태를 보여줌
                        Console.Write("Player Card : ");
                        foreach (int[] card in playerHand)
                        {
                            WriteCardType(card);
                            Console.Write(' ');
                        }
                        Console.WriteLine();
                        break;
                    case 4:
                        if (playerMoney - curBetMoney < 0) Console.WriteLine("베팅 금액 부족으로 Double Down 할 수 없습니다. 다시 고르세요.");
                        else
                        {
                            curBetMoney *= 2;
                            playerMoney -= curBetMoney;
                        }
                        getNewCard(PLAYER_TYPE);    // DoubleDown 선언 후 새 카드를 뽑음
                        isPlayerEnd = true;
                        if (isBust(PLAYER_TYPE))    // Bust
                        {
                            Console.WriteLine("Bust!");                         
                            isGameOver = true;
                        } 
                        break;
                    //case 5:
                    //    if (isPair) Split();
                    //    else Console.WriteLine("Split 할 수 없습니다. 다시 고르세요.");
                    //    break;
                    case 5:
                        // 베팅 금액의 절반을 돌려받고 게임 포기
                        playerMoney += (int)(curBetMoney / 2);
                        isPlayerEnd = true;
                        isGameOver = true;
                        break;
                }
            }

            Console.WriteLine();
            if (isGameOver)
            {
                // 게임 종류 후 player와 dealer 카드를 보여줌
                showCardResult();
                Console.WriteLine("게임 종료");
                Console.WriteLine("Player Money : " + playerMoney);
                return;
            } else
            {
                // dealer 플레이 시작
                bool isDealerEnd = false;
                int result = -1;    // player, dealer 승패 여부 (2일 때는 무승부)
                while (!isDealerEnd)
                {
                    // 현재 dealer 카드의 합계
                    int dealerSum = 0;
                    foreach (int[] card in dealerHand)
                    {
                        if (card[1] >= 11) dealerSum += 10;
                        else dealerSum += card[1];                     
                    }

                    // 21을 초과할 경우 딜러 패배
                    if (dealerSum > BLACKJACK)
                    {
                        isDealerEnd = true;
                        result = PLAYER_TYPE;
                    } 
                    // 17 ~ 21일 경우 player와 카드 합 비교
                    else if (dealerSum >= 17)
                    {
                        // dealer 카드 합이 딱 21인 경우 dealer 승리
                        // player가 승리할 수는 없음 (앞에서 블랙잭인 경우를 걸러냈으므로 이 경우 무조건 player 카드 합은 21보다 작기 때문)
                        if (BlackJack(DEALER_TYPE) == 1) result = DEALER_TYPE;
                        else result = compareSum();
                        isDealerEnd = true;
                    } 
                    // 16 이하인 경우
                    else
                    {
                        // dealer는 히트 카드를 받고 Bust 여부 판단
                        if (Hit(DEALER_TYPE))
                        {
                            // Bust이면 player 승리
                            isDealerEnd = true;
                            result = PLAYER_TYPE;
                        }
                    }
                }

                showCardResult();

                Console.WriteLine("게임 종료");
                if (result == PLAYER_TYPE)
                {
                    Console.WriteLine("Player 승리!");
                    playerMoney += curBetMoney;
                } else if (result == DEALER_TYPE)
                {
                    Console.WriteLine("Dealer 승리!");
                } else
                {
                    Console.WriteLine("Push!"); // player와 dealer 카드 합이 같은 경우 무승부 Push
                }
                Console.WriteLine("Player Money : " + playerMoney);
            }
        }

        // 맨 처음 금액 베팅
        static int betMoney()
        {
            int betMoney = 0;

            while (true)
            {
                string input = Console.ReadLine();
                bool isNum = int.TryParse(input, out betMoney);
                if (!isNum || betMoney <= 0 || betMoney > 1000)
                {
                    Console.WriteLine("베팅 금액이 잘못되었습니다. 다시 입력하세요.");
                    Console.Write("베팅 금액 : ");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("현재 베팅 금액 : " + betMoney);
                    break;
                }
            }

            return betMoney;
        }

        // 맨 처음에 딜러가 카드를 돌림
        static void giveCards()
        {
            // player와 dealer는 각각 카드를 2장씩 받음
            while (playerHand.Count < 2)
            {
                getNewCard(PLAYER_TYPE);
            }

            while (dealerHand.Count < 2)
            {
                getNewCard(DEALER_TYPE);
            }

            // player 카드 공개
            Console.Write("Player Card : ");
            foreach (int[] card in playerHand)
            {
                WriteCardType(card);
                Console.Write(' ');
            }

            Console.WriteLine();

            // dealer의 첫 번째 카드 공개
            Console.Write("Dealer Card : ");
            WriteCardType(dealerHand[0]);

            Console.WriteLine();
        }

        // Hit인 경우 새 카드를 뽑음 (새 카드를 뽑는 사람 player or dealer)
        static void getNewCard(int personType)
        {
            int shape = new Random().Next(0, 4);
            int cardNum = new Random().Next(1, 14);
            if (!cardDeck[shape][cardNum])
            {
                cardDeck[shape][cardNum] = true;
                if (personType == PLAYER_TYPE)
                {
                    playerHand.Add(new int[] { shape, cardNum });
                } else
                {
                    dealerHand.Add(new int[] { shape, cardNum });
                }
            }
        }

        // 인덱스를 받아서 카드 타입을 작성 
        // card = {1, 2} 인 경우, ♥2
        static void WriteCardType(int[] card)
        {
            switch (card[0])
            {
                case SPADE:
                    Console.Write("♠");
                    break;
                case HEART:
                    Console.Write("♥");
                    break;
                case DIAMOND:
                    Console.Write("◆");
                    break;
                case CLOVER:
                    Console.Write("♣");
                    break;
            }

            switch (card[1])
            {
                case 1:
                    Console.Write("A");
                    break;
                case 11:
                    Console.Write("J");
                    break;
                case 12:
                    Console.Write("Q");
                    break;
                case 13:
                    Console.Write("K");
                    break;
                default:
                    Console.Write(card[1]);
                    break;
            }
        }

        // BlackJack 판단 여부 (BlackJack 여부를 판단 받을 사람 player or dealer)
        static int BlackJack(int personType)
        {
            if (personType == PLAYER_TYPE)
            {
                if ((playerHand[0][1] == 1 && playerHand[1][1] >= 10) ||
                (playerHand[0][1] >= 10 && playerHand[1][1] == 1))
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            } else
            {
                if ((dealerHand[0][1] == 1 && dealerHand[1][1] >= 10) ||
                (dealerHand[0][1] >= 10 && dealerHand[1][1] == 1))
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }           
        }

        // Hit인 경우 새 카드를 받고, Bust 여부 판단 (Hit를 한 사람 player or dealer)
        static bool Hit(int personType)
        {
            getNewCard(personType);
            return isBust(personType);
        }

        // Bust 여부 판단 (Bust 여부를 판단 받을 사람 player or dealer)
        static bool isBust(int personType)
        {
            if (personType == PLAYER_TYPE)
            {
                int sum = 0;
                foreach (int[] card in playerHand)
                {
                    if (card[1] >= 11) sum += 10;
                    else sum += card[1];
                }
                if (sum > 21) return true;
            } else
            {
                int sum = 0;
                foreach (int[] card in dealerHand)
                {
                    if (card[1] >= 11) sum += 10;
                    else sum += card[1];
                }
                if (sum > 21) return true;
            }
            return false;
        }

        // player와 dealer 카드 합 비교
        static int compareSum()
        {
            int playerSum = 0;
            foreach (int[] card in playerHand)
            {
                if (card[1] >= 11) playerSum += 10;
                else playerSum += card[1];
            }

            int dealerSum = 0;
            foreach (int[] card in dealerHand)
            {
                if (card[1] >= 11) dealerSum += 10;
                else dealerSum += card[1];
            }

            if (playerSum > dealerSum) return PLAYER_TYPE;
            else if (playerSum == dealerSum) return 2;  // Push
            else return DEALER_TYPE;
        }

        // player와 dealer의 최종 카드 상태를 보여줌
        static void showCardResult()
        {
            Console.Write("Player Card 공개 : ");
            foreach (int[] card in playerHand)
            {
                WriteCardType(card);
                Console.Write(' ');
            }

            Console.WriteLine();
            Console.Write("Dealer Card 공개 : ");
            foreach (int[] card in dealerHand)
            {
                WriteCardType(card);
                Console.Write(' ');
            }
            Console.WriteLine();
        }
    }
}