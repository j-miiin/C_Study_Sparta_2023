using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_assignment.Repository
{
    internal interface IGameDatabaseRepository
    {
        // 전체 상점 Item List 불러오기
        // Player 정보 불러오기(string name, int hp, int shield, int power, int money)
        // Player가 가진 Inventory Item List 정보 불러오기
        // Player의 상점 구매 내역 Item List 정보 불러오기

        public Player? GetPlayerInfo();

        public List<Item> GetStoreItemList();

        public Dictionary<string, bool>? GetStoreItemSoldStateList();

        public void UpdatePlayerInfo(Player player);

        public void UpdateStoreItemSoldState(Dictionary<string, bool> soldState);
    }
}
