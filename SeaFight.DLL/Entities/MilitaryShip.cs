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
        public MilitaryShip(int xStart, int xEnd, int yStart, int yEnd) : base(xStart, xEnd, yStart, yEnd)
        {
            Name = "Военный";
        }

        public void ShootTheEnemy()
        {
            //TODO: Write something here
        }
    }
}
