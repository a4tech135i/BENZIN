using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BENZIN_1._0
{
    [Serializable]
    class Save_game
    {
        Car car;
        Save s;
        public Save_game(Car c,Save s1)
        {
            car = c;
            s = s1;
        }
        public Car getCar()
        {
            return car;
        }
        public Save getS()
        {
            return s;
        }
    } 
}
