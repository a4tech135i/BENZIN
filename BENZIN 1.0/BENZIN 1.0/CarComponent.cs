using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BENZIN_1._0
{
    abstract class CarComponent
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

        public void damage(int damage)
        {
            HP -= damage - resistance * 10;
        }

        public void damage()
        {
            HP -= 10 - resistance;
        }
    }
}
