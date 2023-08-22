using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace personal_assignment
{
    internal class Player
    {
        private string name;
        private int jobType = 0;
        private int level = 1;
        private int hp;
        private int shield;
        private int power;
        private int money;
        private int clearDungeonCount;
        private List<Item> itemList;
        private List<string> purchasedItemList;

        public Player(string name, int hp, int shield, int power, int money, int clearDungeonCount, List<Item> itemList, List<string> purchasedItemList)
        {
            this.name = name;
            this.hp = hp;
            this.shield = shield;
            this.power = power;
            this.money = money;
            this.clearDungeonCount = clearDungeonCount;
            this.itemList = itemList;
            this.purchasedItemList = purchasedItemList;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Job
        {
            get
            {
                switch (jobType)
                {
                    default:
                        return "전사";
                }
            }
        }

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        public int HP
        {
            get { return hp; }
            set { hp = value; }
        }

        public int Shield
        {
            get { return shield; }
            set { shield = value; }
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public int Money
        {
            get { return money; }
            set { money = value; }
        }

        public int ClearDungeonCount
        {
            get { return clearDungeonCount; }
            set { clearDungeonCount = value; }
        }

        public List<Item> ItemList
        {
            get { return itemList; }
        }

        public List<string> PurchasedItemList
        {
            get { return purchasedItemList; }
        }

        // 초기 플레이어의 아이템 인벤토리 상태를 초기화하는 함수
        // Item 객체를 받아와서 Player의 itemList에 저장
        public void InitItemList(Item item)
        {
            itemList.Add(item);
        }

        // 플레이어가 착용한 방어 무기로 인한 추가 방어력 반환
        public int GetAdditionalShield()
        {
            int addShield = 0;
            foreach (Item item in itemList)
            {
                if (item.IsEquipped)
                {
                    if (item.Type == 0) addShield += item.Value;
                }
            }
            return addShield;
        }

        // 플레이어가 착용한 공격 무기로 인한 추가 공격력 반환
        public int GetAdditionalPower()
        {
            int addPower = 0;
            foreach (Item item in itemList)
            {
                if (item.IsEquipped)
                {
                    if (item.Type == 1) addPower += item.Value;
                }
            }
            return addPower;
        }

        // 플레이어의 정보를 보여주는 함수
        public void DisplayPlayerInfo()
        {
            Console.Write("Lv. "); ("0" + level).PrintWithColor(ConsoleColor.Magenta, true);
            Console.WriteLine(name + " ( " + Job + " )");

            Console.Write("공격력 : "); (power.ToString()).PrintWithColor(ConsoleColor.Magenta, false);
            if (GetAdditionalPower() > 0)  // 공격 무기 착용시
            {
                // 공격력 : 12 (+2)
                Console.Write(" ("); ("+").PrintWithColor(ConsoleColor.Yellow, false);
                (GetAdditionalPower().ToString()).PrintWithColor(ConsoleColor.Magenta, false); Console.WriteLine(")");
            }
            else Console.WriteLine();   // 공격력 : 12

            Console.Write("방어력 : "); (shield.ToString()).PrintWithColor(ConsoleColor.Magenta, false);
            if (GetAdditionalShield() > 0)  // 방어구 착용시
            {
                // 방어력 : 10 (+5)
                Console.Write(" ("); ("+").PrintWithColor(ConsoleColor.Yellow, false);
                (GetAdditionalShield().ToString()).PrintWithColor(ConsoleColor.Magenta, false); Console.WriteLine(")");
            }
            else Console.WriteLine();   // 방어력 : 10

            Console.Write("체력 : "); (hp.ToString()).PrintWithColor(ConsoleColor.Magenta, true);
            Console.Write("Gold : "); (money.ToString()).PrintWithColor(ConsoleColor.Magenta, false); Console.WriteLine(" G");
        }

        // 플레이어의 현재 아이템 인벤토리 상태를 보여주는 함수
        // type이 0이면 인벤토리, type이 1이면 인벤토리 - 장착 관리 상태 (번호를 출력해야 함)
        public void DisplayItemInventory(int type)
        {
            Console.WriteLine("[ 아이템 목록 ]");
            int idx = 1;
            foreach (Item item in itemList)
            {
                // 아이템 이름
                (" -").PrintWithColor(ConsoleColor.Yellow, false);
                // 장착 관리 상태일 경우 번호 표시
                if (type == 1) (" " + idx.ToString()).PrintWithColor(ConsoleColor.Magenta, false);\
                // 장착한 아이템이라면 [E] 표시
                if (item.IsEquipped) Console.Write(" [E] ");

                Extension.AlignmentPrint(new string[] { item.Name, item.Value.ToString(), item.Description }, item.Type);
                Console.WriteLine();

                idx++;
            }
        }

        // 아이템 장착 함수
        // itemIdx를 받아서 현재 플레이어의 아이템 리스트 중 itemIdx번째 아이템을 장착 또는 해제
        public void EquipItem(int itemIdx)
        {
            Item curItem = itemList[itemIdx];
            if (!curItem.IsEquipped)    // 장착하지 않은 아이템이라면 장착
            {
                foreach (Item item in itemList)
                {
                    if (item.Name == curItem.Name) continue;
                     
                    // 현재 장착하려는 아이템과 같은 타입의 아이템이 이미 장착되어 있다면 해제함
                    if (item.Type == curItem.Type) item.IsEquipped = false;
                }
                // 현재 선택한 아이템 장착
                curItem.IsEquipped = true;
            }
            else curItem.IsEquipped = false;    // 장착한 아이템이라면 해제
        }

        // 플레이어의 아이템 인벤토리를 정렬하는 함수
        // pivot 값에 따라 이름, 장착, 공격력, 방어력 순으로 정렬됨
        public void ArrangeItemInventory(int pivot)
        {
            switch (pivot)
            {
                // 이름 정렬 (긴 순서대로)
                case 1:
                    itemList = itemList.OrderByDescending(item => item.Name.Length).ToList(); 
                    break;
                // 장착순 정렬 -> 이름순 정렬
                case 2:
                    itemList = itemList.OrderByDescending(item => item.IsEquipped).ThenByDescending(item => item.Name.Length).ToList();
                    break;
                // 타입 정렬(공격은 1이므로 1부터 나오도록) -> 공격력 정렬 -> 이름순 정렬
                case 3:
                    itemList = itemList.OrderByDescending(item => item.Type == 1).ThenByDescending(item => item.Value)
                        .ThenByDescending(item => item.Name.Length).ToList();
                    break;
                // 타입 정렬(방어는 0이므로 0부터 나오도록) -> 방어력 정렬 -> 이름순 정렬
                case 4:
                    itemList = itemList.OrderByDescending(item => item.Type == 0).ThenByDescending(item => item.Value)
                        .ThenByDescending(item => item.Name.Length).ToList();
                    break;
            }
        }

        // 플레이어가 가진 돈의 정보를 출력하는 함수
        public void DisplayMoney()
        {
            Console.WriteLine("[ 보유 골드 ]");
            (money.ToString()).PrintWithColor(ConsoleColor.Magenta, false); Console.WriteLine(" G");
        }

        // 아이템 가격을 받아와서 해당 아이템을 살 수 있는지 확인하는 함수
        public bool IsAbleToBuy(int itemPrice)
        {
            return itemPrice <= money;
        }

        // Item 객체를 받아와서 해당 아이템을 구입하는 함수
        // 해당 아이템 가격만큼 money 값을 갱신하고, itemList(인벤토리에 있는 아이템 리스트)와 purchasedItemList(상점에서 구매한 아이템 리스트)에 객체를 추가
        public void BuyItem(Item item)
        {
            itemList.Add(item);
            purchasedItemList.Add(item.Name);
            money -= item.Price;
        }

        // 플레이어가 상점에서 구매한 아이템의 목록을 출력하는 함수
        // 인벤토리 아이템을 foreach로 순회하면서, 현재 아이템 이름이 구매한 아이템 목록에 있다면 해당 아이템 정보를 출력
        public void DisplayPurchasedItem()
        {
            Console.WriteLine("[ 아이템 목록 ]");
            int idx = 1;
            foreach (Item item in itemList)
            {
                if (purchasedItemList.Contains(item.Name))
                {
                    // 아이템 이름
                    (" -").PrintWithColor(ConsoleColor.Yellow, false);
                    (" " + idx.ToString()).PrintWithColor(ConsoleColor.Magenta, false);
                    if (item.IsEquipped) Console.Write(" [E]");

                    Extension.AlignmentPrint(new string[] { item.Name, item.Value.ToString(), item.Description, item.Price.ToString() }, item.Type);
                    Console.WriteLine();

                    idx++;
                }
            }
        }

        // 플레이어가 상점에서 아이템을 판매하는 함수
        // 아이템 장착을 해제하고 아이템 가격 * 0.85 만큼 money에 더해준 뒤 itemList에서 해당 아이템 삭제
        public string SellItem(int itemIdx)
        {
            string itemName = purchasedItemList[itemIdx];
            purchasedItemList.RemoveAt(itemIdx);
            foreach (Item item in itemList)
            {
                if (itemName == item.Name)
                {
                    item.IsEquipped = false;
                    money += (int)(item.Price * 0.85);

                    itemList.Remove(item);

                    return itemName;
                }
            }
            return itemName;
        }

        // 플레이어가 던전을 실패했을 때 실행되는 함수
        // type이 0이라면 권장 방어력보다 플레이어의 방어력이 낮은 경우로, 체력이 1/2로 줄어듦
        // type이 1이라면 권장 방어력보다 플레이어의 방어력이 높았지만, 피해량으로 인해 플레이어 체력이 0 이하가 되어 실패한 경우
        public void DungeonFailed(int type)
        {
            Console.WriteLine("[ 탐험 결과 ]");
            Console.Write("체력 "); 
            (hp.ToString()).PrintWithColor(ConsoleColor.Magenta, false);
            (" -> ").PrintWithColor(ConsoleColor.Yellow, false);

            if (type == 0) hp = (int)(hp / 2);
            else hp = 0;

            (hp.ToString()).PrintWithColor(ConsoleColor.Magenta, true);
            Console.WriteLine();
        }

        // 플레이어가 던전을 성공했을 때 실행되는 함수
        // 플레이어 체력과 money 값을 갱신
        // 클리어한 던전의 수를 증가시킴 
        // 만약 클리어한 던전의 수 = 현재 레벨의 숫자 이면 레벨업 상태
        // 최대 레벨인 5레벨이라면 갱신 X
        // 레벨업시 플레이어의 기본 방어/공격력 증가 및 클리어한 던전의 수를 0으로 초기화 -> 레벨업 정보도 함께 출력
        public void ClearDungeon(int decreasedHP, int reward)
        {
            Console.WriteLine("[ 탐험 결과 ]");
            Console.Write("체력 ");
            (hp.ToString()).PrintWithColor(ConsoleColor.Magenta, false);
            (" -> ").PrintWithColor(ConsoleColor.Yellow, false);

            hp -= decreasedHP;

            (hp.ToString()).PrintWithColor(ConsoleColor.Magenta, true);

            Console.Write("Gold ");
            (money.ToString()).PrintWithColor(ConsoleColor.Magenta, false);
            (" -> ").PrintWithColor(ConsoleColor.Yellow, false);

            money += reward;

            (money.ToString()).PrintWithColor(ConsoleColor.Magenta, true);

            clearDungeonCount++;

            bool isLevelUp = (clearDungeonCount == level);

            if (isLevelUp)
            {
                Console.Write("Level ");
                ("Lv" + level).PrintWithColor(ConsoleColor.Magenta, false);
                (" -> ").PrintWithColor(ConsoleColor.Yellow, false);

                if (level < 5)
                {
                    level++;
                    power += 1;
                    shield += 2;
                    clearDungeonCount = 0;
                }

                ("Lv" + level).PrintWithColor(ConsoleColor.Magenta, true);
            }
            
            Console.WriteLine();
        }

        // 휴식하기 기능
        // 플레이어 체력을 100으로 변경하고, money 값을 500 감소
        public void GetRest()
        {
            hp = 100;
            money -= 500;
        }
    }
}
