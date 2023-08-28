using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week4_assignment_text_rpg_retry
{
    internal class Monster : ICharacter
    {
        public string Name { get; }
        public int Health { get; set; }
        public int Attack => new Random().Next(10, 30);

        public bool IsDead => Health <= 0;

        public Monster(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
            Console.WriteLine("{0}이(가) 공격 당했습니다! 체력이 {0} 감소합니다!", Name, damage);
            Console.WriteLine("남은 체력: {0}", Health);
            Console.WriteLine();
            if (IsDead) Console.WriteLine("{0}이(가) 죽었습니다.", Name);
        }
    }
}
