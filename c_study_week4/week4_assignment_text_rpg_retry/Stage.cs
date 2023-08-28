using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace week4_assignment_text_rpg_retry
{
    internal class Stage
    {
        private ICharacter player;
        private ICharacter monster;
        private List<IItem> itemList;

        public delegate void GameEvent(ICharacter character);
        public event GameEvent OnCharacterDeath;

        public Stage(ICharacter player, ICharacter monster, List<IItem> itemList)
        {
            this.player = player;
            this.monster = monster;
            this.itemList = itemList;
            OnCharacterDeath += StageClear;
        }

        public void Start()
        {
            Console.WriteLine("스테이지를 시작합니다!");
            Console.WriteLine();
            Console.WriteLine($"Player {player.Name}   체력 {player.Health}    공격력 {player.Attack}");
            Console.WriteLine();
            Console.WriteLine($"Monster {monster.Name}   체력 {monster.Health}    공격력 {monster.Attack}");
            Console.WriteLine();
            Thread.Sleep(1000);

            while (true)
            {
                Console.WriteLine("Player {0} 공격 턴", player.Name);
                Console.WriteLine();
                Thread.Sleep(1000);
                monster.TakeDamage(player.Attack);
                Thread.Sleep(1000);
                if (monster.IsDead) break;
                Console.WriteLine("Monster {0} 공격 턴", monster.Name);
                Console.WriteLine();
                Thread.Sleep(1000);
                player.TakeDamage(monster.Attack);
                Thread.Sleep(1000);
                if (player.IsDead) break;
            }

            if (player.IsDead) OnCharacterDeath?.Invoke(player);
            else OnCharacterDeath?.Invoke(monster);
        }

        private void StageClear(ICharacter character)
        {

            if (character is Monster)
            {
                Console.WriteLine("Monster {0}이(가) 죽었습니다! 스테이지를 종료합니다!", character.Name);
                Console.WriteLine("스테이지 클리어! 보상 아이템을 사용할 수 있습니다!");
                Console.WriteLine();
                int itemNum = 1;
                foreach (IItem item in itemList)
                {
                    Console.WriteLine("{0}. {1}", itemNum++, item.Name);
                }
                Console.Write("선택 : ");
                int select = int.Parse(Console.ReadLine());
                itemList[select - 1].Use((Warrior)player);

                player.Health = 100;
            }
            else
            {
                Console.WriteLine("Player {0}이(가) 죽었습니다! 스테이지를 종료합니다!", character.Name);
                Console.WriteLine("스테이지 실패! 패배했습니다.");
            }
        }
    }
}
