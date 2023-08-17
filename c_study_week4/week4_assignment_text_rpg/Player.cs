using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week4_assignment_text_rpg
{
    internal class Player
    {
        private string name;
        private int hp;
        private int shield;
        private int power;
        private int money;
        private int exp;
        private List<Item> itemList;

        public Player(string name, int hp, int shield, int power, int money, int exp, List<Item> itemList)
        {
            this.name = name;
            this.hp = hp;
            this.shield = shield;
            this.power = power;
            this.money = money;
            this.exp = exp;
            this.itemList = itemList;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
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

        public int Exp
        {
            get { return exp; }
            set { exp = value; }
        }

        public void Attack(string monsterName)
        {
            Console.WriteLine("{0}이(가) {1}을(를) 공격합니다!", name, monsterName);
        }

        public void BuyItem(Item item)
        {
            itemList.Add(item);
            money -= item.Price;
        }

        public int GetItemCount()
        {
            return itemList.Count;
        }

        public void OpenItemInventory()
        {
            int idx = 1;
            foreach(Item item in itemList)
            {
                Console.WriteLine("{0}. {1} {2}", idx, item.Name, item.Value);
                idx++;
            }
        }

        public void UseItem(int itemIdx)
        {
            Item item = itemList[itemIdx];
            Console.WriteLine("{0}번 {1}을(를) 사용합니다!", itemIdx + 1, item.Name);
            item.Use();
            switch (item.Type)
            {
                case 0:
                    hp += item.Value;
                    break;
                case 1:
                    power += item.Value;
                    break;
                case 2:
                    shield += item.Value;
                    break;
            }
            itemList.Remove(item);
        }
    }
}
