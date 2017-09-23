using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BENZIN_1._0
{
    public class Wheels : CarComponent
    {
        int tireFullness;
        int tireResistance;

        public Wheels(string nam, int hp, int fs, int res, int ful, int tres)
            : base(nam, hp, fs, res)
        {
            tireFullness = ful;
            tireResistance = tres;
        }

        public int getTireFullness()
        {
            return tireFullness;
        }
        public int getTireResistance()
        {
            return tireResistance;
        }
        
    }
}
