using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight.DLL.Entities
{
    public class Field
    {
        public Ship[] ships { get; private set; }
        public int[][] FieldSize;
        private double xCenter;
        private double yCenter;
        private int shipsLimit;
        public delegate void FieldHandler(string message);
        public event FieldHandler Notify;

        public Field(int shipsLimit = 10)
        {
            FieldSize = new int[10][];
            for (int i = 0; i < FieldSize.Length; i++)
            {
                FieldSize[i] = new int[10];
            }

            xCenter = yCenter = 10 / 2;
            ships = new Ship[shipsLimit];
            this.shipsLimit = shipsLimit;
        }

        public Field(int x, int y, int shipsLimit = 10)
        {
            FieldSize = new int[x][];
            for(int i=0;i < FieldSize.Length; i++)
            {
                FieldSize[i] = new int[y];
            }

            xCenter = x / 2;
            yCenter = y / 2;
            ships = new Ship[shipsLimit];
            this.shipsLimit = shipsLimit;
        }

        public Field(int[][] field, int shipsLimit = 10)
        {
            FieldSize = field;
            xCenter = field.Length / 2;
            int max = 0; // longest column
            for (int i = 0; i < field.Length; i++)
            {
                if (field[i].Length > max)
                {
                    max=field[i].Length;
                }
            }
            yCenter = max / 2;
            ships = new Ship[shipsLimit];
            this.shipsLimit = shipsLimit;
        }
        
        public Ship this[int xStart, int yStart, int quadrant]
        {
            get
            {
                for (int i = 0; i < ships.Length; i++)
                {
                    if (ships[i]!=null&&ships[i].Quadrant == quadrant && ships[i].xStart == xStart && ships[i].yStart == yStart)
                        return ships[i];
                }
                return null;
            }
        }

        public void AddShip(Ship ship)
        {
            // If there is no "free space" in the array, we can't create new ship
            if (!ships.Contains(null))
            {
                Notify?.Invoke("Список полон. Вы не можете добавить ещё один корабль.");
                return;
            }

            if (ship.xStart>FieldSize.Length || ship.xEnd>FieldSize.Length || ship.yStart>FieldSize.Length || ship.yEnd>FieldSize.Length)
            {
                Notify?.Invoke("Ваши индексы выходят за границу поля.");
                return;
            }

            ship.Quadrant = ship.FindQuadrant(xCenter, yCenter);
            ship.DistanceToCenter=ship.FindDistanceToCenter(xCenter, yCenter);

            // Check if we can create a ship
            for (int i = 0; i < ships.Length; i++)
            {
                if (ships[i] == null)
                    break;
                int coincidences = 0;
                // Checking "free" coordinates (x and y)
                for (int j = ship.xStart; j <= ship.xEnd; j++)
                    for (int k = ships[i].xStart; k <= ships[i].xEnd; k++)
                    {
                        if (j == k)
                            ++coincidences;
                    }

                for (int j = ship.yStart; j <= ship.yEnd; j++)
                    for (int k = ships[i].yStart; k <= ships[i].yEnd; k++)
                    {
                        if (j == k)
                            ++coincidences;
                    }

                if (coincidences > 1)
                {
                    Notify?.Invoke("Данные индексы уже заняты.");
                    return;
                }
            }
            // If we can create a ship:
            for (int i = 0; i < ships.Length; i++)
            {
                if (ships[i] == null)
                {
                    ships[i] = ship;
                    break;
                }
            }

            Notify?.Invoke("Корабль успешно добавлен.");
        }

        public void FeildStatus()
        {
            StringBuilder info=new StringBuilder();
            Array.Sort(ships);
            int number = 1;
            foreach(Ship s in ships)
            {
                if (s != null)
                {
                    info.AppendLine($"{number}. Корабль с начальными координатами {s.xStart};{s.yStart}, длинной {s.Length}.\nPасстояние от центра поля ({xCenter};{yCenter}) =     {s.DistanceToCenter}.\n Квадрант: {s.Quadrant}");
                    ++number;
                }
            }
            Notify?.Invoke(info.ToString());
        }
    }
}
