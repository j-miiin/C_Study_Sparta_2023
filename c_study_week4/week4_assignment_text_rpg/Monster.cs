using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week4_assignment_text_rpg
{
    internal class Monster
    {
        private string name;
        private int hp;
        private int power;
        private int reward;
        private int exp;

        public Monster(string name, int hp, int power, int reward, int exp)
        {
            this.name = name;
            this.hp = hp;
            this.power = power;
            this.reward = reward;
            this.exp = exp;
        }

        public string Name
        {
            get { return name; }
        }

        public int HP
        {
            get { return hp; }
            set { hp = value; }
        }

        public int Power
        {
            get { return power; }
        }

        public int Reward
        {
            get { return reward; }
        }

        public int Exp
        {
            get { return exp; }
        }

        public virtual void Attack()
        {

        }
    }

    internal class  Slime : Monster
    {
        private string name;
        private int hp;
        private int power;
        private int reward;
        private int exp;

        public Slime(string name, int hp, int power, int reward, int exp) : base(name, hp, power, reward, exp)
        {
            this.name = name;
            this.hp = hp;
            this.power = power;
            this.reward = reward;
            this.exp = exp;
        }

        public override void Attack()
        {
            Console.WriteLine("{0}이(가) {1}만큼의 공격을 합니다!", name, power);
        }
    }

    internal class Boar : Monster
    {
        private string name;
        private int hp;
        private int power;
        private int reward;
        private int exp;

        public Boar(string name, int hp, int power, int reward, int exp) : base(name, hp, power, reward, exp)
        {
            this.name = name;
            this.hp = hp;
            this.power = power;
            this.reward = reward;
            this.exp = exp;
        }

        public override void Attack()
        {
            Console.WriteLine("{0}이(가) {1}만큼의 공격을 합니다!", name, power);
        }
    }

    internal class Toadstool : Monster
    {
        private string name;
        private int hp;
        private int power;
        private int reward;
        private int exp;

        public Toadstool(string name, int hp, int power, int reward, int exp) : base(name, hp, power, reward, exp)
        {
            this.name = name;
            this.hp = hp;
            this.power = power;
            this.reward = reward;
            this.exp = exp;
        }

        public override void Attack()
        {
            Console.WriteLine("{0}이(가) {1}만큼의 공격을 합니다!", name, power);
        }
    }
}
