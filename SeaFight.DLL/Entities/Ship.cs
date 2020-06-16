using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight.DLL.Entities
{
    public abstract class Ship : IComparable
    {
        private int length;
        public double DistanceToCenter;
        public string Name { get; protected set; }
        protected int speed;
        protected int abilityRange;
        public int xStart { get; protected set; }
        public int xEnd { get; protected set; }
        public int yStart { get; protected set; }
        public int yEnd { get; protected set; }
        protected int quadrant;
        static readonly int sizeLimit=4;
        static readonly int speedLimit=1;
        static readonly int abilityRangeLimit=2;

        // The ship should be limited in its size
        public int Length
        {
            set
            {
                if (value <= 0 || value > sizeLimit)
                {
                    // TODO: new exeption or messege 
                }
                else
                    length = value;
            }

            get
            {
                return length;
            }
        }

        public int Speed
        {
            set
            {
                if (value < 0 || value > speedLimit)
                {
                    // TODO: new exeption or messege 
                }
                else
                    speed = value;
            }

            get
            {
                return speed;
            }
        }

        public int AbilityRange
        {
            set
            {
                if (value <= 0 || value > abilityRangeLimit)
                {
                    // TODO: new exeption or messege 
                }
                else
                    abilityRange = value;
            }

            get
            {
                return abilityRange;
            }
        }

        public int Quadrant
        {
            set
            {
                if (value <= 0 || value > 4)
                {
                    // TODO: new exeption or messege 
                }
                else
                {
                    quadrant = value;
                }
            }

            get
            {
                return quadrant;
            }
        }

        public int CompareTo(object o)
        {
            Ship ship = o as Ship;
            if (ship != null)
                return this.DistanceToCenter.CompareTo(ship.DistanceToCenter);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }

        public Ship(int xStart, int xEnd, int yStart, int yEnd)
        {
            this.xStart = Math.Abs(xStart);
            this.xEnd = Math.Abs(xEnd);
            this.yStart = Math.Abs(yStart);
            this.yEnd = Math.Abs(yEnd);
            Length=CheckLength(xStart,  xEnd,  yStart,  yEnd);
            speed = 0;
            abilityRange = 1;
        }

        public Ship(int xStart, int xEnd, int yStart, int yEnd, int speed, int abilityRange)
        {
            this.xStart = Math.Abs(xStart);
            this.xEnd = Math.Abs(xEnd);
            this.yStart = Math.Abs(yStart);
            this.yEnd = Math.Abs(yEnd);
            Length = CheckLength(xStart, xEnd, yStart, yEnd);
            Speed = speed;
            AbilityRange = abilityRange;
        }

        public static bool operator ==(Ship ship1, Ship ship2)
        {
            if (ship1?.Name == ship2?.Name && ship1?.Speed == ship2?.Speed && ship1?.Length == ship2?.Length)
                return true;
            else
                return false;
        }

        public static bool operator !=(Ship ship1, Ship ship2)
        {
            if (ship1?.Name == ship2?.Name && ship1?.Speed == ship2?.Speed && ship1?.Length == ship2?.Length)
                return false;
            else
                return true;
        }

        protected int CheckLength(int xStart, int xEnd, int yStart, int yEnd)
        {
            ++xEnd;
            ++yEnd;
            if (Math.Abs(xEnd - xStart) > 1 && Math.Abs(yEnd - yStart) > 1)
            {
                throw new Exception("Корабль должен составлять отрезок");
            }
            else if (Math.Abs(xEnd - xStart) > 1)
            {
                return Math.Abs(xEnd - xStart);
            }
            else if (Math.Abs(yEnd - yStart) > 1)
            {
                return Math.Abs(yEnd - yStart);
            }
            else
            {
                    return 1;
            }
        }

        public int FindQuadrant (double xCenter, double yCenter)
        {

            if (xStart >= xCenter && yStart >= yCenter)
            {
                return 1;
            }
            else if (xStart < xCenter && yStart >= yCenter)
            {
                return 2;
            }
            else if (xStart < yCenter && yStart < yCenter)
            {
                return 3;
            }
            else
                return 4;
        }

        // Finding the length of vectors.
        public double FindDistanceToCenter(double xCenter, double yCenter)
        {
            if (xStart == xCenter)
                return yStart;
            if (yStart == yCenter)
                return xStart;
            double xlength = Math.Abs(xStart - xCenter);
            double ylength = Math.Abs(yStart - yCenter);
            return Math.Sqrt(Math.Pow(xlength, 2) + Math.Pow(ylength, 2));
        }
    }
}
