using SeaFight.DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight.DLL.Entities
{
    public class AuxiliaryShip : Ship, IRepair
    {

        public AuxiliaryShip(int length, int speed, int abilityRange) : base(length, speed, abilityRange)
        {
            Name = "Военный";
        }

        public void RepairShip()
        {
            //TODO: Write something here
        }
    }
}
