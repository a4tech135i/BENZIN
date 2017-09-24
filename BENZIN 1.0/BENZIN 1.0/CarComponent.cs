using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BENZIN_1._0
{
    abstract public class CarComponent
    {
        protected string name;
        protected int HP;
        protected int fuelSpend;
        protected int resistance;

        public CarComponent(string nam, int hp, int fs, int res)
        {
            name = nam;
            HP = hp;
            fuelSpend = fs;
            resistance = res;
        }

        public string getName()
        {
            return name;
        }

        public int getHP()
        {
            return HP;
        }

        public int getFuelSpend()
        {
            return fuelSpend;
        }

        public int damage(int damage)
        {
            int dmg=Math.Abs(damage - resistance * 10);
            HP -= dmg;
            if (HP < 0) HP = 0;
            return dmg;
        }
        public int damage()
        {
            int dmg = 10 - resistance;
            HP -= dmg;
            if (HP < 0) HP = 0;
            return dmg;
        }

        public void repair()
        {
            HP = 100;
        }
        public void repair(int amount)
        {
            HP += amount;
            if (HP >= 100) HP = 100;
        }
    }
}
