using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_assignment
{
    internal class Store
    {
        private List<Item> itemList;
        private Dictionary<string, bool> soldState;

        public Dictionary<string, bool> SoldState
        {
            get { return soldState; }
        }

        public Store(List<Item> itemList, Dictionary<string, bool> soldState)
        {
            this.itemList = itemList;
            InitStore(soldState);
        }

        private void InitStore(Dictionary<string, bool> soldStateList)
        {
            if (soldStateList == null)
            {
                int length = itemList.Count;
                Console.WriteLine("length = " + length);
                soldState = new Dictionary<string, bool>();
                for (int i = 0; i < length; i++) soldState.Add(itemList[i].Name, false);
            } else
            {
                soldState = soldStateList;
                if (itemList.Count != soldState.Count)
                {
                    foreach (Item item in itemList)
                    {
                        if (soldState[item.Name] == null) 
                        {
                            soldState.Add(item.Name, false);
                        }
                    }
                }
            }
        }

        public int GetStoreItemCount()
        {
            return itemList.Count;
        }

        // 상점 itemList의 itemIdx번째 아이템을 리턴
        public Item GetStoreItem(int itemIdx)
        {
            return itemList[itemIdx];
        }

        // 상점의 아이템 목록을 보여주는 함수
        // type이 0이면 상점, type이 1이면 상점 - 아이템 구매 상태
        public void DisplayStore(int type)
        {
            Console.WriteLine("[ 아이템 목록 ]");
            int idx = 1;
            foreach (Item item in itemList)
            {

                // 아이템 이름
                ("-").PrintWithColor(ConsoleColor.Yellow, false);
                // 아이템 구매 상태일 경우 번호 표시
                if (type == 1) (" " + idx.ToString()).PrintWithColor(ConsoleColor.Magenta, false);

                // 아이템 가격
                string itemValue = "";
                if (soldState.GetValueOrDefault(item.Name)) itemValue = "구매 완료";
                else itemValue = item.Price.ToString();

                Extension.AlignmentPrint(new string[] { item.Name, item.Value.ToString(), item.Description, itemValue }, item.Type);
                Console.WriteLine();

                idx++;
            }
        }

        // Store itemList의 itemIdx번째 아이템이 구매할 수 있는지 확인하는 함수
        public bool IsAbleToBuy(int itemIdx)
        {
            string key = itemList[itemIdx].Name;
            return !soldState.GetValueOrDefault(key);
        }

        // 플레이어가 Store itemList의 itemIdx번째 아이템을 구매할 때 호출되는 함수
        // 해당 아이템의 판매 여부를 true로 바꾸고 아이템을 리턴해줌
        public void BuyItem(int itemIdx)
        {
            Item selectedItem = itemList[itemIdx];
            string key = selectedItem.Name;
            soldState[key] = true;
        }

        public void RecoverItem(string itemName)
        {
            soldState[itemName] = false;
        }
    }
}
