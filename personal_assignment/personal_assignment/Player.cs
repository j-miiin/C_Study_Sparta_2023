﻿using System;
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
        private List<Item> itemList;

        public Player(string name, int hp, int shield, int power, int money, List<Item> itemList)
        {
            this.name = name;
            this.hp = hp;
            this.shield = shield;
            this.power = power;
            this.money = money;
            this.itemList = itemList;
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

        // 초기 플레이어의 아이템 인벤토리 상태를 초기화하는 함수
        public void InitItemList(Item item)
        {
            itemList.Add(item);
        }

        // 플레이어 인벤토리 아이템 개수 반환
        public int GetItemCount()
        {
            return itemList.Count;
        }

        // 플레이어 인벤토리 아이템 리스트 반환
        public List<Item> GetItemList()
        {
            return itemList;
        }

        // 플레이어의 정보를 보여주는 함수
        public void DisplayPlayerInfo()
        {
            Console.Write("Lv. "); ("0" + level).PrintWithColor(ConsoleColor.Magenta, true);
            Console.WriteLine(name + " ( " + Job + " )");

            // 착용한 아이템 수치 계산
            int addAttack = 0, addShield = 0;
            foreach (Item item in itemList)
            {
                if (item.IsEquipped)
                {
                    if (item.Type == 0) addShield += item.Value;
                    else addAttack += item.Value;
                }
            }

            Console.Write("공격력 : "); (power.ToString()).PrintWithColor(ConsoleColor.Magenta, false);
            if (addAttack > 0)  // 공격 무기 착용시
            {
                // 공격력 : 12 (+2)
                Console.Write(" ("); ("+").PrintWithColor(ConsoleColor.Yellow, false);
                (addAttack.ToString()).PrintWithColor(ConsoleColor.Magenta, false); Console.WriteLine(")");
            }
            else Console.WriteLine();   // 공격력 : 12

            Console.Write("방어력 : "); (shield.ToString()).PrintWithColor(ConsoleColor.Magenta, false);
            if (addShield > 0)  // 방어구 착용시
            {
                // 방어력 : 10 (+5)
                Console.Write(" ("); ("+").PrintWithColor(ConsoleColor.Yellow, false);
                (addShield.ToString()).PrintWithColor(ConsoleColor.Magenta, false); Console.WriteLine(")");
            }
            else Console.WriteLine();   // 방어력 : 10

            Console.Write("체력 : "); (hp.ToString()).PrintWithColor(ConsoleColor.Magenta, true);
            Console.Write("Gold : "); (money.ToString()).PrintWithColor(ConsoleColor.Magenta, false); Console.WriteLine(" G");
        }

        // 플레이어의 현재 아이템 인벤토리 상태를 보여주는 함수
        // type이 0이면 인벤토리, type이 1이면 인벤토리 - 장착 관리 상태
        public void DisplayItemInventory(int type)
        {
            Console.WriteLine("[ 아이템 목록 ]");
            int idx = 1;
            foreach (Item item in itemList)
            {
                // 아이템 이름
                ("-").PrintWithColor(ConsoleColor.Yellow, false);
                // 장착 관리 상태일 경우 번호 표시
                if (type == 1) (" " + idx.ToString()).PrintWithColor(ConsoleColor.Magenta, false);
                if (item.IsEquipped) Console.Write(" [E]");
                Console.Write(" " + item.Name);

                Extension.MakeDivider();

                // 아이템 효과
                if (item.Type == 0) Console.Write("방어력 "); else Console.Write("공격력 ");
                ("+").PrintWithColor(ConsoleColor.Yellow, false);
                (item.Value.ToString()).PrintWithColor(ConsoleColor.Magenta, false);

                Extension.MakeDivider();

                // 아이템 설명
                Console.WriteLine(item.Description);
                idx++;
            }
        }

        // 아이템 장착 함수
        // itemIdx를 받아서 현재 플레이어의 아이템 리스트 중 itemIdx번째 아이템을 장착 또는 해제
        public void EquipItem(int itemIdx)
        {
            Item curItem = itemList[itemIdx];
            curItem.IsEquipped = !curItem.IsEquipped ;
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

        public void DisplayMoney()
        {
            Console.WriteLine("[ 보유 골드 ]");
            (money.ToString()).PrintWithColor(ConsoleColor.Magenta, false); Console.WriteLine(" G");
        }

        public bool IsAbleToBuy(int itemPrice)
        {
            return itemPrice <= money;
        }

        public void BuyItem(Item item)
        {
            itemList.Add(item);
            money -= item.Price;
        }
    }
}
