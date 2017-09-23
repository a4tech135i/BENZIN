using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BENZIN_1._0
{
    abstract class CarComponent
    {
        protected string name;
        protected double HP;
        protected int fuelSpend;
        protected double resistance;

        public CarComponent(string nam, int hp, int fs, double res)
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

        public double getHP()
        {
            return HP;
        }

        public int getFuelSpend()
        {
            return fuelSpend;
        }

        public void damage(double damage)
        {
            HP -= damage - resistance * 10;
        }
        public void damage()
        {
            HP -= 10 - resistance;
        }

        public void repair()
        {
            HP = 100;
        }
        public void repair(int amount)
        {
            HP += amount;
            if (HP > 100) HP = 100;
        }
    }
}
