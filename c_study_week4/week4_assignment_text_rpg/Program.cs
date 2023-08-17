using System;

namespace week4_assignment_text_rpg
{
    internal class Program
    {
        // 플레이 선택
        // 1 : 사냥하기
        // 2 : 아이템 인벤토리 열기
        // 3 : 상점 열기 - 상점 업데이트
        // 4 : 게임 종료 

        // 화면
        // 최상단 - 플레이어 이름 / 플레이어 체력 / 플레이어 보호구 체력 / 플레이어 공격력 / 플레이어 돈 / 플레이어 경험치
        // 플레이 상태 

        // 흐름
        // 1. 플레이어 닉네임 정하기
        // 2. 플레이어 생성 
        // 3. 플레이 선택하기
        // 3-1. 기존의 몬스터 배열이 없다면 새로운 몬스터 배열 생성 -> 자동사냥 시작
        // 3-2. 아이템 인벤토리 열기 -> 화면에 아이템 목록 표시 -> 아이템 사용 or exit
        // 3-3. 상점 열기 -> 화면에 상점 목록 표시 -> 아이템 구매 or exit
        // 4. 플레이어가 잡은 몬스터 수, 플레이어 경험치 표시 후 종료

        // Player 관련 값 const 변수
        const int PLAYER_HP = 100;
        const int PLAYER_SHIELD = 0;
        const float PLAYER_SHIELD_REDUCE = 0.5f;
        const int PLAYER_POWER = 30;

        // Monster 관련 값 const 변수
        // Slime 
        const string SLIME_NAME = "Slime";
        const int SLIME_HP = 100;
        const int SLIME_POWER = 5;
        const int SLIME_REWARD = 100;
        const int SLIME_EXP = 50;
        // Boar
        const string BOAR_NAME = "Boar";
        const int BOAR_HP = 300;
        const int BOAR_POWER = 20;
        const int BOAR_REWARD = 100;
        const int BOAR_EXP = 200;
        // Toadstool
        const string TOADSTOOL_NAME = "Toadstool";
        const int TOADSTOOL_HP = 500;
        const int TOADSTOOL_POWER = 50;
        const int TOADSTOOL_REWARD = 1000;
        const int TOADSTOOL_EXP = 500;

        // Item 관련 값 const 변수
        // Health Potion
        const string HP_NAME = "Health Potion";
        const int HP_TYPE = 0;
        const int HP_MIN_VALUE = 100;
        const int HP_MAX_VALUE = 301;
        const int HP_MIN_PRICE = 100;
        const int HP_MAX_PRICE = 501;
        // Mana Potion
        const string MP_NAME = "Mana Potion";
        const int MP_TYPE = 1;
        const int MP_MIN_VALUE = 50;
        const int MP_MAX_VALUE = 201;
        const int MP_MIN_PRICE = 100;
        const int MP_MAX_PRICE = 301;
        // Shield Potion
        const string SP_NAME = "Shield Potion";
        const int SP_TYPE = 2;
        const int SP_MIN_VALUE = 60;
        const int SP_MAX_VALUE = 401;
        const int SP_MIN_PRICE = 200;
        const int SP_MAX_PRICE = 401;

        static string playerName;
        static Player player;
        static int playState = 0;
        static int huntedMonsterCnt = 0;

        static List<Monster> monsterList = new List<Monster>();
        static List<Item> storeItemList = new List<Item>();

        static void Main(string[] args)
        {
            Console.Title = "Welcome to Text RPG!";
            Console.Write("Player 닉네임을 입력해주세요 : ");
            playerName = Console.ReadLine();
            player = new Player(playerName, PLAYER_HP, PLAYER_SHIELD, PLAYER_POWER, 500, 0, new List<Item>());

            UpdatePlayerInfo();

            bool isGameOver = false;

            while (!isGameOver)
            {
                Console.Clear();
                UpdatePlayerInfo();

                switch (playState)
                {
                    case 0:
                        SelectPlayState();
                        break;
                    case 1:
                        Hunting();
                        break;
                    case 2:
                        OpenItemInventory();
                        break;
                    case 3:
                        OpenStore();
                        break;
                    case 4:
                        EndGame();
                        isGameOver = true;
                        break;
                }
            }
        }

        static void UpdatePlayerInfo()
        {   
            Console.WriteLine();
            Console.WriteLine("닉네임 {0}\t체력 {1}\t보호구 체력 {2}\t공격력 {3}\t$ {4}\t경험치 {5}",
                player.Name,
                player.HP,
                player.Shield,
                player.Power,
                player.Money,
                player.Exp);
        }

        static void SelectPlayState()
        {
            Console.WriteLine();
            Console.WriteLine("1: 사냥하기\t2: 아이템 인벤토리 열기\t 3: 상점 열기\t4: 게임 종료");
            Console.Write("플레이를 선택하세요 : ");
            playState = getPlayerSelect(1, 4);
        }

        static int getPlayerSelect(int start, int end)
        {
            int select = 0;
            bool isNum = false;
            while (true)
            {
                isNum = int.TryParse(Console.ReadLine(), out select);
                if (!isNum || (select < start || select > end))
                {
                    Console.WriteLine("잘못된 선택입니다. 다시 고르세요");
                }
                else break;
            }
            return select;
        }

        static void Hunting()
        {
            while (playState == 1)
            {
                if (monsterList.Count == 0)
                {
                    UpdateMonsterList();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("사냥을 시작합니다!");
                    foreach (Monster monster in monsterList)
                    {
                        Console.WriteLine();
                        Console.WriteLine("앗! 야생의 {0}이(가) 나타났다!", monster.Name);
                        while (monster.HP > 0 && player.HP > 0)
                        {
                            Thread.Sleep(700);
                            Console.WriteLine();
                            player.Attack(monster.Name);
                            monster.HP -= player.Power;                          

                            int monsterAttack = new Random().Next(0, 5);
                            if (monsterAttack == 1)
                            {
                                Console.WriteLine();
                                monster.Attack();
                                if (player.Shield > 0)
                                {
                                    if (player.Shield - (int)(monster.Power * PLAYER_SHIELD_REDUCE) >= 0)
                                    {
                                        player.Shield -= (int)(monster.Power * PLAYER_SHIELD_REDUCE);
                                    } else
                                    {
                                        int restDamage = monster.Power - (player.Shield * 2);
                                        player.Shield = 0;
                                        player.HP -= restDamage;
                                    }
                                } else
                                {
                                    player.HP -= monster.Power;
                                }
                                UpdatePlayerInfo();
                                Thread.Sleep(500);
                            }
                        }

                        Thread.Sleep(700);

                        if (monster.HP <= 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("{0}을(를) 처치했습니다!", monster.Name);
                            Console.WriteLine("경험치 {0}을(를) 얻었습니다!", monster.Exp);
                            player.Exp += monster.Exp;
                            player.Money += monster.Reward;
                            huntedMonsterCnt++;
                        }
                        else if (player.HP <= 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("{0}이(가) 사망했습니다!", player.Name);
                            playState = 4;
                            Thread.Sleep(800);
                            return;
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("1: 계속 진행\t0: 사냥 종료");
                    int select = getPlayerSelect(0, 1);
                    if (select == 0)
                    {
                        playState = 0;
                    } else
                    {
                        monsterList = new List<Monster>();
                        Console.Clear();
                        UpdatePlayerInfo();
                    }
                }
            }    
        }

        static void UpdateMonsterList()
        {
            Console.WriteLine();
            Console.WriteLine("새로운 몬스터를 생성합니다!");

            for (int i = 0; i < 5; i++)
            {
                int monsterType = new Random().Next(0, 3);
                switch (monsterType)
                {
                    case 0:
                        monsterList.Add(new Slime(SLIME_NAME, SLIME_HP, SLIME_POWER, SLIME_REWARD, SLIME_EXP));
                        break;
                    case 1:
                        monsterList.Add(new Boar(BOAR_NAME, BOAR_HP, BOAR_POWER, BOAR_REWARD, BOAR_EXP));
                        break;
                    case 2:
                        monsterList.Add(new Toadstool(TOADSTOOL_NAME, TOADSTOOL_HP, TOADSTOOL_POWER, TOADSTOOL_REWARD, TOADSTOOL_EXP));
                        break;
                }
            }
        }

        static void OpenItemInventory()
        {
            while (playState == 2)
            {
                if (player.GetItemCount() == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("보유하고 있는 아이템이 없습니다!");
                    Console.WriteLine("인벤토리를 닫습니다");
                    Thread.Sleep(2000);
                    playState = 0;
                    break;
                }

                Console.WriteLine();
                Console.WriteLine("{0}의 아이템 인벤토리", player.Name);
                player.OpenItemInventory();

                Console.WriteLine();
                Console.WriteLine("1: 아이템 사용\t0: 인벤토리 닫기");
                Console.Write("선택: ");
                int select = getPlayerSelect(0, 1);
                if (select == 0)
                {
                    playState = 0;
                }
                else
                {
                    Console.WriteLine();
                    Console.Write("아이템 번호 선택: ");
                    int itemIdx = getPlayerSelect(1, player.GetItemCount()) - 1;
                    player.UseItem(itemIdx);
                    Thread.Sleep(1000);
                    Console.Clear();
                    UpdatePlayerInfo();
                }
            }
        }

        static void OpenStore()
        {
            while (playState == 3)
            {
                if (storeItemList.Count == 0)
                {
                    UpdateStore();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("상점 아이템 목록");
                    int idx = 1;
                    foreach(Item item in  storeItemList)
                    {
                        Console.WriteLine("{0}. 종류 {1}\t효능 +{2}\t가격 {3}", idx, item.Name, item.Value, item.Price);
                        idx++;
                    }

                    Console.WriteLine();
                    Console.WriteLine("1: 아이템 구매\t2: 상점 업데이트\t0: 상점 나가기");
                    Console.Write("선택: ");
                    int select = getPlayerSelect(0, 2);
                    switch (select)
                    {
                        case 0:
                            playState = 0;
                            break;
                        case 1:
                            BuyItem();
                            Thread.Sleep(1000);
                            Console.Clear();
                            UpdatePlayerInfo();
                            break;
                        case 2:
                            storeItemList = new List<Item>();
                            break;
                    }
                }
            }
        }

        static void UpdateStore()
        {
            Console.Clear();
            UpdatePlayerInfo();
            Console.WriteLine();
            Console.WriteLine("상점을 업데이트합니다!");

            for (int i = 0; i < 5; i++)
            {
                int potionType = new Random().Next(0, 3);
                switch (potionType)
                {
                    case 0:
                        int[] randomHPValues = randomValueAndPrice(HP_MIN_VALUE, HP_MAX_VALUE, HP_MIN_PRICE, HP_MAX_PRICE);
                        storeItemList.Add(new HealthPotion(HP_NAME, HP_TYPE, randomHPValues[0], randomHPValues[1]));
                        break;
                    case 1:
                        int[] randomMPValues = randomValueAndPrice(MP_MIN_VALUE, MP_MAX_VALUE, MP_MIN_PRICE, MP_MAX_PRICE);
                        storeItemList.Add(new ManaPotion(MP_NAME, MP_TYPE, randomMPValues[0], randomMPValues[1]));
                        break;
                    case 2:
                        int[] randomSPValues = randomValueAndPrice(SP_MIN_VALUE, SP_MAX_VALUE, SP_MIN_PRICE, SP_MAX_PRICE);
                        storeItemList.Add(new ShieldPotion(SP_NAME, SP_TYPE, randomSPValues[0], randomSPValues[1]));
                        break;
                }
            }
        }

        static int[] randomValueAndPrice(int minValue, int maxValue, int minPrice, int maxPrice)
        {
            int value = new Random().Next(minValue, maxValue);
            int price = new Random().Next(minPrice, maxPrice);
            return new int[] { value, price };
        }

        static void BuyItem()
        {
            Console.WriteLine();
            Console.Write("구매할 아이템 번호를 입력하세요: ");
            int itemIdx = getPlayerSelect(1, storeItemList.Count) - 1;
            Item selectedItem = storeItemList[itemIdx];
            if (player.Money < selectedItem.Price)
            {
                Console.WriteLine("돈이 부족해 구매할 수 없습니다! 몬스터를 사냥해서 돈을 모으세요!");
            } else
            {
                Console.WriteLine("{0}을(를) 구매했습니다.", selectedItem.Name);
                player.BuyItem(selectedItem);
                storeItemList.Remove(selectedItem);
            }
        }

        static void EndGame()
        {
            Console.WriteLine();
            Console.WriteLine("게임을 종료합니다!");
            Console.WriteLine("사냥한 몬스터 수 {0}", huntedMonsterCnt);
            Console.WriteLine("{0}의 경험치 {1}", player.Name, player.Exp);
        }
    }
}