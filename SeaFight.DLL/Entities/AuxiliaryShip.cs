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
        public AuxiliaryShip(int xStart, int xEnd, int yStart, int yEnd) : base(xStart, xEnd, yStart, yEnd)
        {
            Name = "Воспомогательный";
        }

        public void RepairShip()
        {
            //TODO: Write something here
        }
    }
}
