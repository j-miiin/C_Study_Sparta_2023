using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week4_assignment_text_rpg_retry
{
    internal class HealthPotion : IItem
    {
        public string Name => "Health Potion";

        public void Use(Warrior warrior)
        {
            Console.WriteLine("{0}이(가) HealthPotion을 섭취합니다!", warrior.Name);
            warrior.Health += 50;
            if (warrior.Health > 100) warrior.Health = 100;
            Console.WriteLine("현재 체력: {0}", warrior.Health);
            Console.WriteLine();
        }
    }
}
