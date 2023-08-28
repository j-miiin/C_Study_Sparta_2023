using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week4_assignment_text_rpg_retry
{
    internal class StrengthPotion: IItem
    {
        public string Name => "Strength Potion";

        public void Use(Warrior warrior)
        {
            Console.WriteLine("{0}이(가) StrengthPotion을 섭취합니다!", warrior.Name);
            warrior.Attack += 20;
            Console.WriteLine("현재 공격력: {0}", warrior.Attack);
            Console.WriteLine();
        }
    }
}
