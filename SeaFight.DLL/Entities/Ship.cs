using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight.DLL.Entities
{
    public abstract class Ship
    {
        private int length;
        public string Name { get; protected set; }
        protected int speed;
        protected int abilityRange;
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
                    throw new Exception("Размер корабля привысил лимит");
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
                    throw new Exception("Скорость корабля привысила лимит");
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
                    throw new Exception("Дальность способностей корабля привысила лимит");
                }
                else
                    abilityRange = value;
            }

            get
            {
                return abilityRange;
            }
        }

        public Ship(int length)
        {
            Length = length;
            speed = 0;
            abilityRange = 1;
        }

        public Ship(int length, int speed, int abilityRange)
        {
            Length = length;
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

    }
}
