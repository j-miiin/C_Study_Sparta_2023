using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week4_assignment_text_rpg_retry
{
    internal class Warrior : ICharacter
    {
        public string Name { get; }
        public int Health { get; set; }
        public int Attack { get; set; }

        public bool IsDead => Health <= 0;

        public Warrior(string name)
        {
            Name = name;
            Health = 100;
            Attack = 15;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
            Console.WriteLine("{0}이(가) 공격 당했습니다! 체력이 {1} 감소합니다!", Name, damage);
            Console.WriteLine("남은 체력: {0}", Health);
            Console.WriteLine();
            if (IsDead) Console.WriteLine("{0}이(가) 죽었습니다.", Name);
        }
    }
}
