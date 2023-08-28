using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week4_assignment_text_rpg_retry
{
    internal interface ICharacter
    {
        string Name { get; }
        int Health { get; set; }

        int Attack { get; }

        bool IsDead { get; }

        void TakeDamage(int damage);
    }
}
