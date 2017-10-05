using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BENZIN_1._0
{
    public class Car
    {                
        private Wheels wheels;
        private Corpus corpus;
        private int maxSpeed;
        private int Speed;
        private int Fuel;
        private int maxFuel;
        private double money;
        private int fuelSpend;

        public Car(Wheels wh, Corpus corp, int ms, int maxF, double mon)
        {

            wheels = wh;
            corpus = corp;
            maxSpeed = ms;
            Speed = 0;
            Fuel = maxF;
            maxFuel = maxF;
            money=mon;
            fuelSpend = 2 + wheels.getFuelSpend() + corpus.getFuelSpend();
        }

        public Car(Wheels wh, Corpus corp, int ms, int maxF, int f, double mon)
        {
            wheels = wh;
            corpus = corp;
            maxSpeed = ms;
            Speed = 0;
            Fuel = f;
            maxFuel = maxF;
            money=mon;
            fuelSpend = 2 + wheels.getFuelSpend() + corpus.getFuelSpend();
        }
        public int getMaxSpeed()
        {
            return maxSpeed;
        }
        public int getMaxFuel()
        {
            return maxFuel;
        }
        public int getSpeed()
        {
            return Speed;
        }
        public int getFuel()
        {
            return Fuel;
        }
        public double getMoney()
        {
            return money;
        }

        public Wheels getWheels()
        {
            return wheels;
        }
        public Corpus getCorpus()
        {
            return corpus;
        }


        public void refuel()
        {
            Fuel = maxFuel;
        }
        public void refuelFromTank()
        {
            Fuel += 30;
            if (Fuel > maxFuel) Fuel = maxFuel;
            corpus.useFuelTank();
        }

        public void repairWheels()
        {
            wheels.repair();
        }
        public void repairWheelsFromKit()
        {
            wheels.repair(30);
            corpus.useRepairKit();
        }

        public void repairCorpus()
        {
            corpus.repair();
        }
        public void repairCorpusFromKit()
        {
            corpus.repair(30);
            corpus.useRepairKit();
        }

        public int speedUp()
        {
            Speed += 10;
            if (Speed > maxSpeed) Speed = maxSpeed;
            return Speed;
        }
        public int speedDown()
        {
            Speed -= 10;
            if (Speed < 0) Speed = 0;
            return Speed;
        }
        public int stop()
        {
            Speed = 0;
            return 0;
        }

        public int[] move()
        {
            int[] results=new int[4];
            for (int i = 0; i < 4; i++) results[i] = 0;

            Random RNGJeesus = new Random();
            int threshold = 25;
            if (RNGJeesus.Next(100) < threshold)
            {
                results[0]=wheels.damage();
                if (RNGJeesus.Next(100) < 10) results[1]=wheels.damage(RNGJeesus.Next(75));
                
            }
            if (RNGJeesus.Next(100) < threshold - 15)
            {
                results[2]=corpus.damage();
                if (RNGJeesus.Next(100) < 5) results[3]=corpus.damage(RNGJeesus.Next(75));
            }
            Fuel -= fuelSpend;
            if (Fuel < 0) Fuel = 0;
            money += 0.9;
            return results;
        }

        public void buyFuelTank()
        {
            if (corpus.getFuelTanks() < corpus.getMaxFuelTanks())
            {
                money -= 10;
                corpus.addFuelTank();
            }
            else throw new Exception("noPlaceForTank");
        }

        public void buyRepairKit()
        {
            if (corpus.getRepairKits() < corpus.getMaxRepairKits())
            {
                money -= 10;
                corpus.addRepairKit();
            }
            else throw new Exception("noPlaceForKit");
        }

    }
}
