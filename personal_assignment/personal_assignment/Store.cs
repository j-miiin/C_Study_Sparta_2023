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
        private Dictionary<string, bool> soldState; // 상점의 아이템 판매 현황 리스트

        public Dictionary<string, bool> SoldState
        {
            get { return soldState; }
        }

        public Store(List<Item> itemList, Dictionary<string, bool> soldState)
        {
            this.itemList = itemList;
            InitStore(soldState);
        }

        // 아이템 판매 현황 리스트를 초기화하는 함수
        private void InitStore(Dictionary<string, bool> soldStateList)
        {
            // 만약 아이템 판매 현황 리스트가 없다면 새로 만듦
            if (soldStateList == null)
            {
                int length = itemList.Count;
                Console.WriteLine("length = " + length);
                soldState = new Dictionary<string, bool>();
                for (int i = 0; i < length; i++) soldState.Add(itemList[i].Name, false);
            } 
            // 아이템 DB의 변경사항이 아이템 판매 현황 리스트에 반영되지 않은 경우 반영
            else
            {
                soldState = soldStateList;
                if (itemList.Count != soldState.Count)
                {
                    Dictionary<string, bool> newSoldState = new Dictionary<string, bool>();
                    foreach (Item item in itemList)
                    {
                        if (soldState.ContainsKey(item.Name)) newSoldState.Add(item.Name, soldState[item.Name]);
                        else newSoldState.Add(item.Name, false);
                    }
                    soldState = newSoldState;
                }
            }
        }

        // 상점에 있는 아이템 개수를 반환
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
        // type이 0이면 상점, type이 1이면 상점 - 아이템 구매 상태 (번호 출력)
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
        // 아이템 판매 현황 리스트를 갱신
        public void BuyItem(int itemIdx)
        {
            Item selectedItem = itemList[itemIdx];
            string key = selectedItem.Name;
            soldState[key] = true;
        }

        // 플레이어가 아이템을 판매했을 때, 해당 아이템의 name 값을 받아와서 아이템 판매 현황 리스트를 갱신
        public void RecoverItem(string itemName)
        {
            soldState[itemName] = false;
        }
    }
}
