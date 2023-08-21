using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_assignment
{
    internal class Item
    {
        private string name;
        private int type;   // 0: 방어, 1: 공격
        private int value;
        private int price;
        private string description;
        private bool isEquipped = false;

        public Item(string name, int type, int value, int price, string description)
        {
            this.name = name;
            this.type = type;
            this.value = value;
            this.price = price;
            this.description = description;
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

        public string Description
        {
            get { return description; }
        }

        public bool IsEquipped
        {
            get { return isEquipped; }
            set { isEquipped = value; }
        }
    }
}
