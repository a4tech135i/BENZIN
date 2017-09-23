using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BENZIN_1._0
{
    class Car
    {       

        private Wheels wheels;
        private Corpus corpus;
        private int maxSpeed;
        private int Speed;
        private int Fuel;
        private int maxFuel;
        double money;

        public Car(Wheels wh, Corpus corp, int ms, int maxF, double mon)
        {
            wheels = wh;
            corpus = corp;
            maxSpeed = ms;
            Speed = 0;
            Fuel = maxF;
            maxFuel = maxF;
            money=mon;
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
        }

        public void corpusWheels()
        {
            corpus.repair();
        }
        public void repairCorpusFromKit()
        {
            corpus.repair(30);
        }

        public void move()
        {

        }

    }
}
