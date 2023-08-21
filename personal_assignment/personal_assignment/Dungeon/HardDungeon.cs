﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_assignment.Dungeon
{
    internal class HardDungeon: IDungeon
    {
        private int recommendedShield = 17;
        private int defaultReward = 2500;

        public int RecommendedShield
        {
            get { return recommendedShield; }
        }
        public int DefaultReward
        {
            get { return defaultReward; }
        }

        public void FailedDungeon()
        {
            ("던전 실패").PrintWithColor(ConsoleColor.Magenta, true);
            Console.WriteLine("어려운 던전 클리어에 실패했습니다.");
            Console.WriteLine();
        }

        public void ClearDungeon()
        {
            ("던전 클리어").PrintWithColor(ConsoleColor.Yellow, true);
            Console.WriteLine("축하합니다!!");
            Console.WriteLine("어려운 던전을 클리어 하였습니다.");
            Console.WriteLine();
        }
    }
}
