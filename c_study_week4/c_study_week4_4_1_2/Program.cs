namespace c_study_week4_4_1_2
{
    internal class Program
    {
        public interface IUsable
        {
            void Use();
        }

        public class Item : IUsable 
        { 
            public string Name { get; set; }

            public void Use()
            {
                Console.WriteLine("아이템 {0}를 사용했습니다.", Name);
            }
        }

        public class Player
        {
            public void UserItem(IUsable item)
            {
                item.Use();
            }
        }

        static void Main(string[] args)
        {
            Player player = new Player();
            Item item = new Item() { Name = "Health Potion" };  // 매개변수가 아님. 초기화를 위해 값을 미리 세팅한 것
            player.UserItem(item);
        }
    }
}