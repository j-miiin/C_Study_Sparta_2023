using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week4_assignment_text_rpg
{
    internal class Item
    {
        private string name;
        private int type;   // 0: HP, 1: MP, 2: SP
        private int value;
        private int price;

        public Item(string name, int type, int value, int price)
        {
            this.name = name;
            this.type = type;
            this.value = value;
            this.price = price;
        }

        public string Name 
        { 
            get { return name; }            
        }

        public int Type
        {
            get { return type; }
        }

        public int Value
        {
            get { return value; }
        }

        public int Price
        {
            get { return price; }
        }

        public virtual void Use()
        {
            
        }
    }

    internal class HealthPotion : Item
    {
        private string name;
        private int type;
        private int value;
        private int price;

        public HealthPotion(string name, int type, int value, int price) : base(name, type, value, price)
        {
            this.name = name;
            this.type = type;
            this.value = value;
            this.price = price;
        }

        public override void Use()
        {
            Console.WriteLine("체력이 {0}만큼 증가합니다!", value);
        }
    }

    internal class ManaPotion : Item
    {
        private string name;
        private int type;
        private int value;
        private int price;

        public ManaPotion(string name, int type, int value, int price) : base(name, type, value, price)
        {
            this.name = name;
            this.type = type;
            this.value = value;
            this.price = price;
        }

        public override void Use()
        {
            Console.WriteLine("공격력이 {0}만큼 증가합니다!", value);
        }
    }

    internal class ShieldPotion : Item
    {
        private string name;
        private int type;
        private int value;
        private int price;

        public ShieldPotion(string name, int type, int value, int price) : base(name, type, value, price)
        {
            this.name = name;
            this.type = type;
            this.value = value;
            this.price = price;
        }

        public override void Use()
        {
            Console.WriteLine("방어구 체력이 {0}만큼 증가합니다!", value);
        }
    }
}
