using SeaFight.DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight.DLL.Entities
{
    public class MixedTypeShip : Ship, IRepair, IShot
    {
        public MixedTypeShip(int length) : base( length)
        {
            Name = "Смешанный";
        }

        public MixedTypeShip(int length, int speed, int abilityRange) : base(length, speed, abilityRange)
        {
            Name = "Смешанный";
        }

        public void RepairShip()
        {
            //TODO: Write something here
        }

        public void ShootTheEnemy()
        {
            //TODO: Write something here
        }
    }
}
