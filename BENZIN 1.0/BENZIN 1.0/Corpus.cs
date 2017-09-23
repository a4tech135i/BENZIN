using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BENZIN_1._0
{
    class Corpus:CarComponent
    {
        private int maxFuelTanks;
        private int maxRepairKits;
        private int fuelTanks;
        private int repairKits;

        public Corpus(string nam, int hp, int fs, int res, int Fuel, int Repair)
            : base(nam, hp, fs, res)
        {
            maxFuelTanks = Fuel;
            maxRepairKits = Repair;
            fuelTanks = Fuel;
            repairKits = Repair;
        }

        public Corpus(string nam, int hp, int fs, int res, int Fuel, int Repair, int maxFuel, int maxRepair)
            : base(nam, hp, fs, res)
        {
            maxFuelTanks = maxFuel;
            maxRepairKits = maxRepair;
            fuelTanks = Fuel;
            repairKits = Repair;
        }

        public int getMaxFuelTanks()
        {
            return maxFuelTanks;
        }
        public int getMaxRepairKitse()
        {
            return maxRepairKits;
        }
        public int getRepairKits()
        {
            return repairKits;
        }
        public int getFuelTanks()
        {
            return fuelTanks;
        }

        public void useFuelTank()
        {
            fuelTanks--;
        }
        public void addFuelTank()
        {
            fuelTanks++;
        }
        
    }
}
