using personal_assignment.Dungeon;
using personal_assignment.Repository;

namespace personal_assignment
{
    internal class Program
    {
        // Player 관련 값 상수
        const int PLAYER_HP = 100;
        const int PLAYER_SHIELD = 5;
        const int PLAYER_POWER = 10;
        const int PLAYER_MONEY = 1500;

        // 던전 관련 값 상수
        const int EASY = 1;
        const int EASY_SHIELD = 5;
        const int NORMAL = 2;
        const int NORMAL_SHIELD =11;
        const int HARD = 3;
        const int HARD_SHIELD = 17;
        const int SUCCESS_PROBABLILITY = 60;

        static bool isGameOver = false;

        // state
        static int startState = 0;

        static Player player;
        static Store store;

        static IGameDatabaseRepository gameDatabaseRepository;

        static void Main(string[] args)
        {
            gameDatabaseRepository = new DefaultGameDatabaseRepository();

            InitPlayerInfo();
            InitStore();

            while (!isGameOver)
            {
                // startState - 0: 시작 화면, 1: 상태 보기, 2: 인벤토리, 3: 상점, 4: 던전 입장, 5: 휴식하기, 6: 게임 저장, -1: 게임 종료
                if (startState == 0) DisplayStartState();
                else if (startState == 1) DisplayPlayerInfo();
                else if (startState == 2) DisplayInventoryInfo();
                else if (startState == 3) DisplayStore();
                else if (startState == 4) DisplayDungeonInfo();
                else if (startState == 5) TakeRest();
                else if (startState == 6) SaveGame();
                else EndGame();
            }
        }

        // 이전에 플레이한 기록이 있다면 gameDatabaseRepository를 통해 파일을 읽어와서 player 객체에 저장
        // 기록이 없다면 플레이어 닉네임을 받아서 새 플레이어 객체 생성
        static void InitPlayerInfo()
        {
            Player tmp = gameDatabaseRepository.GetPlayerInfo();
            if (tmp == null)
            {
                Console.Title = "[ 스파르타 던전 ]";
                Console.WriteLine("[ 스파르타 던전 ]");
                Console.WriteLine();
                Console.Write("Player 닉네임을 입력해주세요 : ");
                string name = Console.ReadLine();

                player = new Player(name, PLAYER_HP, PLAYER_SHIELD, PLAYER_POWER, PLAYER_MONEY, 0, new List<Item>(), new List<string>());

                List<Item> allItemList = gameDatabaseRepository.GetStoreItemList();
                player.InitItemList(allItemList[0]);
                player.InitItemList(allItemList[1]);
            }
            else player = tmp;        
        }        

        // gameDatabaseRepository로부터 상점 아이템 DB와 상점 아이템 판매 현황 리스트를 읽어와서 Store 객체를 초기화
        static void InitStore()
        {
            store = new Store(gameDatabaseRepository.GetStoreItemList(), gameDatabaseRepository.GetStoreItemSoldStateList());
        }

        // 시작 화면을 보여주는 함수
        static void DisplayStartState()
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            ("1").PrintWithColor(ConsoleColor.Magenta, false);
            Console.WriteLine(". 상태 보기");
            ("2").PrintWithColor(ConsoleColor.Magenta, false);
            Console.WriteLine(". 인벤토리");
            ("3").PrintWithColor(ConsoleColor.Magenta, false);
            Console.WriteLine(". 상점");
            ("4").PrintWithColor(ConsoleColor.Magenta, false);
            Console.WriteLine(". 던전 입장");
            ("5").PrintWithColor(ConsoleColor.Magenta, false);
            Console.WriteLine(". 휴식하기");
            ("6").PrintWithColor(ConsoleColor.Magenta, false);
            Console.WriteLine(". 게임 저장");
            ("0").PrintWithColor(ConsoleColor.Magenta, false);
            Console.WriteLine(". 게임 종료");
            Console.WriteLine();
            int select = GetPlayerSelect(0, 6);
            if (select == 0) startState = -1;   // 게임 종료
            else startState = select;
        }

        // 시작 화면에서 상태 보기 선택시 실행
        // Player 객체에게 정보를 출력할 것을 요청
        static void DisplayPlayerInfo()
        {
            Console.Clear();
            ("상태 보기").PrintWithColor(ConsoleColor.Yellow, true);
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();

            player.DisplayPlayerInfo();
            Console.WriteLine(); Console.WriteLine();

            ("0").PrintWithColor(ConsoleColor.Magenta, false); Console.WriteLine(". 나가기");
            Console.WriteLine();

            int select = GetPlayerSelect(0, 0);
            if (select == 0) startState = select;
        }

        // 인벤토리 선택시 실행되는 함수
        // Player 객체에게 인벤토리 상태 출력을 요청
        static void DisplayInventoryInfo()
        {
            Console.Clear();
            ("인벤토리").PrintWithColor(ConsoleColor.Yellow, true);
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            if (player.ItemList.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("보유하고 있는 아이템이 없습니다!");
            } else
            {
                player.DisplayItemInventory(0);
                Console.WriteLine();

                ("1").PrintWithColor(ConsoleColor.Magenta, false); Console.WriteLine(". 장착 관리");
                ("2").PrintWithColor(ConsoleColor.Magenta, false); Console.WriteLine(". 아이템 정렬");
                ("0").PrintWithColor(ConsoleColor.Magenta, false); Console.WriteLine(". 나가기");
                Console.WriteLine();

                int select = GetPlayerSelect(0, 2);
                if (select == 0) startState = select;
                else if (select == 1) ManagementItemInventory();
                else ArrangeItemInventory();
            }
        }

        // 인벤토리 - 장착 관리 선택시 실행되는 함수
        // Player 객체에게 인벤토리 목록을 번호와 함께 출력할 것을 요청
        // 아이템 번호를 입력한다면 Player 객체에게 해당 아이템을 장착 및 해제할 것을 요청
        static void ManagementItemInventory()
        {
            bool isExit = false;
            while (!isExit)
            {
                Console.Clear();
                ("인벤토리 - 장착 관리").PrintWithColor(ConsoleColor.Yellow, true);
                Console.WriteLine("보유 중인 아이템을 장착하거나 해제할 수 있습니다.");
                Console.WriteLine();

                player.DisplayItemInventory(1);
                Console.WriteLine();

                ("0").PrintWithColor(ConsoleColor.Magenta, false); Console.WriteLine(". 나가기");
                Console.WriteLine();

                int select = GetPlayerSelect(0, player.ItemList.Count);
                if (select == 0)
                {
                    isExit = true;
                    DisplayInventoryInfo();
                }
                else player.EquipItem(select - 1);
            }  
        }

        // 인벤토리 - 아이템 정렬 선택시 실행되는 함수
        // Player 객체에게 아이템을 정렬하여 출력할 것을 요청
        static void ArrangeItemInventory()
        {
            bool isExit = false;
            while (!isExit)
            {
                Console.Clear();
                ("인벤토리 - 아이템 정렬").PrintWithColor(ConsoleColor.Yellow, true);
                Console.WriteLine("보유 중인 아이템을 정렬할 수 있습니다.");
                Console.WriteLine();

                player.DisplayItemInventory(1);
                Console.WriteLine();

                ("1").PrintWithColor(ConsoleColor.Magenta, false); Console.WriteLine(". 이름");
                ("2").PrintWithColor(ConsoleColor.Magenta, false); Console.WriteLine(". 장착순");
                ("3").PrintWithColor(ConsoleColor.Magenta, false); Console.WriteLine(". 공격력");
                ("4").PrintWithColor(ConsoleColor.Magenta, false); Console.WriteLine(". 방어력");
                ("0").PrintWithColor(ConsoleColor.Magenta, false); Console.WriteLine(". 나가기");
                Console.WriteLine();

                int select = GetPlayerSelect(0, 4);
                if (select == 0)
                {
                    isExit = true;
                    DisplayInventoryInfo();
                }
                else player.ArrangeItemInventory(select);
            }
        }

        // 상점 선택시 실행되는 함수
        // Store 객체에게 상점 정보를 출력할 것을 요청
        static void DisplayStore()
        {
            Console.Clear();
            ("상점").PrintWithColor(ConsoleColor.Yellow, true);
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();

            player.DisplayMoney();
            Console.WriteLine();

            store.DisplayStore(0);
            Console.WriteLine();

            ("1").PrintWithColor(ConsoleColor.Magenta, false); Console.WriteLine(". 아이템 구매");
            ("2").PrintWithColor(ConsoleColor.Magenta, false); Console.WriteLine(". 아이템 판매");
            ("0").PrintWithColor(ConsoleColor.Magenta, false); Console.WriteLine(". 나가기");

            int select = GetPlayerSelect(0, 2);
            if (select == 0) startState = select;
            else if (select == 1) BuyItem();
            else SellItem();
        }

        // 상점 - 아이템 구매 선택시 실행되는 함수
        // Player 객체에게 현재 보유한 money 값을 출력할 것을 요청
        // Store 객체에게 상점의 아이템 리스트를 번호와 함께 출력할 것을 요청
        static void BuyItem()
        {
            bool isExit = false;
            while (!isExit)
            {
                Console.Clear();
                ("인벤토리 - 아이템 구매").PrintWithColor(ConsoleColor.Yellow, true);
                Console.WriteLine("필요한 아이템을 구매할 수 있습니다.");
                Console.WriteLine();

                player.DisplayMoney();
                Console.WriteLine();

                store.DisplayStore(1);
                Console.WriteLine();

                ("0").PrintWithColor(ConsoleColor.Magenta, false); Console.WriteLine(". 나가기");

                int select = GetPlayerSelect(0, store.GetStoreItemCount());
                if (select == 0)
                {
                    isExit = true;
                }
                else
                {
                    // 상점 아이템 리스트의 select-1번째 아이템이 구매 가능한지 확인
                    if (store.IsAbleToBuy(select - 1))
                    {
                        // 해당 아이템 객체를 받아와서 Player에게 아이템을 구매할 돈이 충분한지 확인
                        Item selectedItem = store.GetStoreItem(select - 1);
                        if (player.IsAbleToBuy(selectedItem.Price))
                        {
                            store.BuyItem(select - 1);
                            player.BuyItem(selectedItem);
                            ("구매를 완료했습니다.").PrintWithColor(ConsoleColor.Blue, true);
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            ("Gold가 부족합니다.").PrintWithColor(ConsoleColor.Red, true);
                            Thread.Sleep(1000);
                        }
                    } else
                    {
                        ("이미 구매한 아이템입니다.").PrintWithColor(ConsoleColor.Blue, true);
                        Thread.Sleep(1000);
                    }
                }
            }
        }

        // 상점 - 아이템 판매 선택시 실행되는 함수
        // Player 객체에게 현재 보유한 돈과 상점에서 구매한 아이템 목록을 출력할 것을 요청
        static void SellItem()
        {
            bool isExit = false;
            while (!isExit)
            {
                Console.Clear();
                ("인벤토리 - 아이템 판매").PrintWithColor(ConsoleColor.Yellow, true);
                Console.WriteLine("아이템을 판매할 수 있습니다.");
                Console.WriteLine();

                player.DisplayMoney();
                Console.WriteLine();

                player.DisplayPurchasedItem();
                Console.WriteLine();

                ("0").PrintWithColor(ConsoleColor.Magenta, false); Console.WriteLine(". 나가기");

                int select = GetPlayerSelect(0, store.GetStoreItemCount());
                if (select == 0)
                {
                    isExit = true;
                }
                else
                {
                    // Player 객체에게 판매한 Item 객체를 받아와서 Store로 전달
                    // Store 객체에서 해당 아이템의 판매 현황을 갱신할 것을 요청
                    string itemName = player.SellItem(select - 1);
                    store.RecoverItem(itemName);
                    ("판매를 완료했습니다.").PrintWithColor(ConsoleColor.Blue, true);
                    Thread.Sleep(1000);
                }
            }
        }

        // 플레이어의 선택이 필요할 때 값이 유효한지 확인하는 함수
        // start <= 값 <= end 인지 확인하고 올바른 값이라면 그 값을 리턴
        static int GetPlayerSelect(int start, int end)
        {
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            (">> ").PrintWithColor(ConsoleColor.Yellow, false);
            int select = 0;
            bool isNum = false;
            while (true)
            {
                isNum = int.TryParse(Console.ReadLine(), out select);
                if (!isNum || (select < start || select > end))
                {
                    ("잘못된 입력입니다. 다시 고르세요").PrintWithColor(ConsoleColor.Red, true);
                }
                else break;
            }
            return select;
        }

        // 던전 입장시 실행되는 함수
        // 각 던전의 정보를 출력하고 선택값을 받아옴
        // 선택 값은 startDungeon으로 전달하여 알맞는 던전 객체를 생성
        static void DisplayDungeonInfo()
        {
            Console.Clear();
            ("던전 입장").PrintWithColor(ConsoleColor.Yellow, true);
            Console.WriteLine("이곳에서 들어갈 던전을 선택할 수 있습니다.");
            Console.WriteLine();

            printDungeonInfo(EASY, EASY_SHIELD);
            printDungeonInfo(NORMAL, NORMAL_SHIELD);
            printDungeonInfo(HARD, HARD_SHIELD);
            ("0").PrintWithColor(ConsoleColor.Magenta, false); Console.WriteLine(". 나가기");
            Console.WriteLine();

            int select = GetPlayerSelect(0, 3);

            if (select == 0) startState = 0;
            else
            {
                startDungeon(select);
            }
        }

        // 던전의 정보를 출력 
        static void printDungeonInfo(int mode, int recommendedShield)
        {
            (mode.ToString()).PrintWithColor(ConsoleColor.Magenta, false);

            if (mode == 1) Console.Write(". 쉬운 던전");
            else if (mode == 2) Console.Write(". 일반 던전");
            else Console.Write(". 어려운 던전");

            ("\t|    ").PrintWithColor(ConsoleColor.Yellow, false);

            Console.Write("방어력 "); 
            (recommendedShield.ToString()).PrintWithColor(ConsoleColor.Magenta, false); 
            Console.WriteLine(" 이상 권장");
        }

        // mode 값에 따라서 (0: 쉬운, 1: 일반, 2: 어려운) 알맞는 Dungeon 객체를 생성한 뒤 던전 플레이 진행
        static void startDungeon(int mode)
        {
            Console.Clear();
            Console.WriteLine("던전 진행 중...");
            Thread.Sleep(2000);

            Console.Clear();

            IDungeon dungeon;

            if (mode == EASY) dungeon = new EasyDungeon();
            else if (mode == NORMAL) dungeon = new NormalDungeon();
            else dungeon = new HardDungeon();

            int success = new Random().Next(1, 101);

            // 플레이어의 기본 방어/공격력과 아이템 착용으로 인한 추가 방어/공격력을 더해서 총 방어/공격력 계산
            int playerTotalShield = player.Shield + player.GetAdditionalShield();
            int playerTotalPower = player.Power + player.GetAdditionalPower();

            // 던전의 권장 방어력보다 플레이어의 총 방어력이 낮을 때
            if ((dungeon.RecommendedShield > playerTotalShield) && (success > SUCCESS_PROBABLILITY))
            {
                dungeon.FailedDungeon();
                player.DungeonFailed(0);
            }
            else
            {
                // 던전의 권장 방어력보다 플레이어의 방어력이 높을 때
                // or 던전의 권장 방어력보다 플레이어의 방어력이 높지만 60%의 확률로 던전 클리어를 성공했을 때
                int defaultDecreasedHP = new Random().Next(20, 36);
                int additionalDecreasedHP = dungeon.RecommendedShield - playerTotalShield;
                int decreasedHP = defaultDecreasedHP + additionalDecreasedHP;

                // 만약 던전 탐험으로 인한 피해량으로 플레이어의 체력이 0이하가 되면 던전 클리어 실패
                if (decreasedHP >= player.HP)
                {
                    dungeon.FailedDungeon();
                    player.DungeonFailed(1);
                }
                // 던전 성공시
                else
                {
                    // 플레이어 공격력에 따른 추가 보상 계산
                    int additionalRewardPercent = new Random().Next(playerTotalPower, (playerTotalPower * 2) + 1);
                    int additionalReward = (int)((dungeon.DefaultReward * additionalRewardPercent) / 100);
                    int reward = dungeon.DefaultReward + additionalReward;

                    // Dungeon 객체와 Player 객체에게 던전 클리어를 요청
                    // Player 객체에게는 받은 피해량과 보상값을 전달
                    dungeon.ClearDungeon();
                    player.ClearDungeon(decreasedHP, reward);
                }
            }

            ("0").PrintWithColor(ConsoleColor.Magenta, false); Console.WriteLine(". 나가기");
            Console.WriteLine();

            int select = GetPlayerSelect(0, 0);
            if (select == 0)
            {
                startState = 0;
                return;
            }
        }

        // 휴식하기 선택시 실행되는 함수
        // 현재 플레이어가 보유한 돈이 500 이상이면 Player 객체에게 휴식할 것을 요청
        static void TakeRest()
        {
            bool isExit = false;
            while (!isExit)
            {
                Console.Clear();
                ("휴식하기").PrintWithColor(ConsoleColor.Yellow, true);
                ("500").PrintWithColor(ConsoleColor.Magenta, false); Console.Write(" G를 내면 체력을 회복할 수 있습니다. (보유 골드 : ");
                (player.Money.ToString()).PrintWithColor(ConsoleColor.Magenta, false); Console.WriteLine(" G)");
                Console.WriteLine();

                ("1").PrintWithColor(ConsoleColor.Magenta, false); Console.WriteLine(". 휴식하기");
                ("0").PrintWithColor(ConsoleColor.Magenta, false); Console.WriteLine(". 나가기");
                Console.WriteLine();

                int select = GetPlayerSelect(0, 1);
                if (select == 0)
                {
                    isExit = true;
                    startState = 0;
                }
                else
                {
                    if (player.Money < 500)
                    {
                        ("Gold 가 부족합니다.").PrintWithColor(ConsoleColor.Red, true);
                        Thread.Sleep(1000);
                    } else
                    {
                        ("휴식을 완료했습니다.").PrintWithColor(ConsoleColor.Blue, true);
                        player.GetRest();
                        isExit = true;
                        startState = 0;
                        Thread.Sleep(1000);
                    }
                }
            }
        }

        // 게임 저장시 실행되는 함수
        // gameDatabaseRepository에게 Player 정보와 Store 정보 저장을 요청
        static void SaveGame()
        {
            gameDatabaseRepository.UpdatePlayerInfo(player);
            gameDatabaseRepository.UpdateStoreItemSoldState(store.SoldState);
            startState = 0;
        }

        // 게임 종료시 실행되는 함수
        static void EndGame()
        {
            SaveGame();
            Console.Clear();
            ("게임을 종료합니다.").PrintWithColor(ConsoleColor.Yellow, true);
            isGameOver = true;
        }
    }
}