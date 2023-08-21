using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_assignment.Repository
{
    internal interface IGameDatabaseRepository
    {
        // Player 정보 불러오기(string name, int hp, int shield, int power, int money) 및 업데이트
        // 전체 상점 Item List 불러오기 및 업데이트
        // 상점의 아이템 판매 현황 불러오기 및 업데이트

        public Player? GetPlayerInfo();

        public List<Item> GetStoreItemList();

        public Dictionary<string, bool>? GetStoreItemSoldStateList();

        public void UpdatePlayerInfo(Player player);

        public void UpdateStoreItemSoldState(Dictionary<string, bool> soldState);
    }
}
