using SeaFight.DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight.DLL.Entities
{
    public class MilitaryShip : Ship, IShot
    {
        public MilitaryShip(int length) : base(length)
        {
            Name = "Военный";
        }

        public MilitaryShip(int length, int speed, int abilityRange) : base(length, speed, abilityRange)
        {
            Name = "Военный";
        }

        public void ShootTheEnemy()
        {
            //TODO: Write something here
        }
    }
}
