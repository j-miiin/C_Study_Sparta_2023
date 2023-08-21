using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_assignment.Dungeon
{
    interface IDungeon
    {
        int RecommendedShield { get; }

        int DefaultReward { get; }

        void FailedDungeon();

        void ClearDungeon();
    }
}
