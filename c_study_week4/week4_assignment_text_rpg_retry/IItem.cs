using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week4_assignment_text_rpg_retry
{
    internal interface IItem
    {
        string Name { get; }

        void Use(Warrior warrior);
    }
}
