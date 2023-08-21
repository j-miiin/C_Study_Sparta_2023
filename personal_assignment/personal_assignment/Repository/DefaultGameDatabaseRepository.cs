using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace personal_assignment.Repository
{
    internal class DefaultGameDatabaseRepository : IGameDatabaseRepository
    {
        const string DATA_PATH = "D:\\coding\\Game Study\\C_Study_Sparta_2023\\";
        const string PLAYER_DB_PATH = "UserDatabase.txt";
        const string ITEM_DB_PATH = "ItemDatabase.txt";
        const string ITEM_SOLD_STATE_DB_PATH = "ItemSoldStateDatabase.txt";

        public Player? GetPlayerInfo()
        {
            try
            {
                string jdata = File.ReadAllText(DATA_PATH + PLAYER_DB_PATH);
                return JsonConvert.DeserializeObject<Player>(jdata);
            } catch
            {
                return null;
            }
        }

        public List<Item> GetStoreItemList()
        {
            List<string[]> itemDB = new List<string[]>();
            List<Item> storeItemList = new List<Item>();
            try
            {
                StreamReader sr = new StreamReader(DATA_PATH + ITEM_DB_PATH);
                string line = sr.ReadLine();

                while (line != null)
                {
                    itemDB.Add(line.Split("\t"));
                    line = sr.ReadLine();
                }
                sr.Close();

                for (int i = 0; i < itemDB.Count; i++)
                {
                    storeItemList.Add(ParseItemStr(itemDB[i]));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("오류가 발생했습니다 : " + e.Message);
                Environment.Exit(0);
            }
            return storeItemList;
        }

        public Dictionary<string, bool>? GetStoreItemSoldStateList()
        {
            try
            {
                string jdata = File.ReadAllText(DATA_PATH + ITEM_SOLD_STATE_DB_PATH);
                return JsonConvert.DeserializeObject<Dictionary<string, bool>>(jdata);
            }
            catch
            {
                return null;
            }
        }

        public void UpdatePlayerInfo(Player player)
        {
            string jdata = JsonConvert.SerializeObject(player);
            File.WriteAllText(DATA_PATH + PLAYER_DB_PATH, jdata);
        }

        public void UpdateStoreItemSoldState(Dictionary<string, bool> soldState)
        {
            string jdata = JsonConvert.SerializeObject(soldState);
            File.WriteAllText(DATA_PATH + ITEM_SOLD_STATE_DB_PATH, jdata);
        }

        // string 배열을 읽어와서 Item 객체로 파싱하여 반환함
        private static Item ParseItemStr(string[] itemStr)
        {
            int idx = 0;
            return new Item(
                itemStr[idx++],
                int.Parse(itemStr[idx++]),
                int.Parse(itemStr[idx++]),
                int.Parse(itemStr[idx++]),
                itemStr[idx++]
            );
        }
    }
}
