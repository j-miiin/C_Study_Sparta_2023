using System.Numerics;

namespace personal_assignment
{
    internal class Program
    {
        // Item Database
        static List<string[]> itemDB = new List<string[]> 
        { 
            new string[] { "무쇠갑옷", "0", "5", "500", "무쇠로 만들어져 튼튼한 갑옷입니다." } ,
            new string[]{ "낡은 검", "1", "2", "600", "쉽게 볼 수 있는 낡은 검입니다." },
            new string[]{ "수련자 갑옷", "0", "9", "1000", "수련에 도움을 주는 갑옷입니다." },
            new string[]{ "스파르타의 갑옷", "0", "30", "3500", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다." },
            new string[]{ "청동 도끼", "1", "8", "1200", "어디선가 사용된 것 같은 도끼입니다." },
            new string[]{ "스파르타의 창", "1", "15", "2500", "스파르타의 전사들이 사용했다는 전설의 창입니다." }
        };

        // Player 관련 값 const 변수
        const int PLAYER_HP = 100;
        const int PLAYER_SHIELD = 5;
        const int PLAYER_POWER = 10;
        const int PLAYER_MONEY = 1500;

        // state
        static int startState = 0;
        static int playState = 0;

        static Player player;
        static Store store;

        static void Main(string[] args)
        {
            InitPlayerInfo();
            InitStore();

            while (true)
            {
                // 1: 상태 보기, 2: 인벤토리, 3: 상점
                if (startState == 0) DisplayStartState();
                else if (startState == 1) DisplayPlayerInfo();
                else if (startState == 2) DisplayInventoryInfo();
                else DisplayStore();
            }
        }
        
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
            Console.WriteLine();
            startState = GetPlayerSelect(1, 3);
        }

        // 플레이어 닉네임을 받아서 플레이어 객체 생성
        // 초기값을 설정해줌
        static void InitPlayerInfo()
        {
            Console.Title = "[ 스파르타 던전 ]";
            Console.WriteLine("[ 스파르타 던전 ]");
            Console.WriteLine();
            Console.Write("Player 닉네임을 입력해주세요 : ");
            string playerName = Console.ReadLine();
            player = new Player(playerName, PLAYER_HP, PLAYER_SHIELD, PLAYER_POWER, PLAYER_MONEY, new List<Item>());

            player.InitItemList(GetItemFromDB(0));
            player.InitItemList(GetItemFromDB(1));
            player.InitItemList(GetItemFromDB(3));
        }

        static void InitStore()
        {
            List<Item> itemList = new List<Item>();
            for (int i = 0; i < itemDB.Count; i++)
            {
                itemList.Add(GetItemFromDB(i));
            }
            store = new Store(itemList);
        }

        static Item GetItemFromDB(int itemIdx)
        {
            string[] itemStr = itemDB[itemIdx];
            int idx = 0;
            return new Item(
                itemStr[idx++],
                int.Parse(itemStr[idx++]),
                int.Parse(itemStr[idx++]),
                int.Parse(itemStr[idx++]),
                itemStr[idx++]
            );
        }
        
        // 시작 화면에서 상태 보기 선택시 실행
        // 화면에 플레이어의 정보 표시
        // 레벨, 이름, 직업, 공격력, 방어력, 체력, Gold
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

        // 플레이어의 인벤토리 상태를 보여줌
        static void DisplayInventoryInfo()
        {
            Console.Clear();
            ("인벤토리").PrintWithColor(ConsoleColor.Yellow, true);
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            if (player.GetItemCount() == 0)
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

        // 인벤토리 - 장착 관리 
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

                int select = GetPlayerSelect(0, player.GetItemCount());
                if (select == 0)
                {
                    isExit = true;
                    DisplayInventoryInfo();
                }
                else player.EquipItem(select - 1);
            }  
        }

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
            ("0").PrintWithColor(ConsoleColor.Magenta, false); Console.WriteLine(". 나가기");

            int select = GetPlayerSelect(0, 1);
            if (select == 0) startState = select;
            else if (select == 1) BuyItem();
            else ArrangeItemInventory();
        }

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
                    DisplayStore();
                }
                else
                {
                    if (store.IsAbleToBuy(select - 1))
                    {
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

        // 플레이어의 선택이 필요할 때 값이 유효한지 확인하는 함수
        // 플레이어가 start부터 end 사이의 값을 선택했다면 그 값을 리턴
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
    }
}