﻿using SeaFight.DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight.DLL.Entities
{
    public class MixedTypeShip : Ship, IRepair, IShot
    {
        public MixedTypeShip(int xStart, int xEnd, int yStart, int yEnd) : base(xStart, xEnd, yStart, yEnd)
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
