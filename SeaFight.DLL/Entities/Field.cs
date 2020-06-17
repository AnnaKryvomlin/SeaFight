using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight.DLL.Entities
{
    public class Field
    {
        public GridObject<Ship>[] ObjectsInField { get; private set; }
        public int[][] FieldSize;
        private double xCenter;
        private double yCenter;
        private int objectsLimit;
        public delegate void FieldHandler(string message);
        public event FieldHandler Notify;

        public Field(int objectsLimit = 10, int x=10, int y=10)
        {
            FieldSize = new int[x][];
            for(int i=0;i < FieldSize.Length; i++)
            {
                FieldSize[i] = new int[y];
            }

            xCenter = x / 2;
            yCenter = y / 2;
            this.ObjectsInField = new GridObject<Ship>[objectsLimit];
            this.objectsLimit = objectsLimit;
        }

        public Field(int[][] field, int objectsLimit = 10)
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
            this.ObjectsInField = new GridObject<Ship>[objectsLimit];
            this.objectsLimit = objectsLimit;
        }

        public GridObject<Ship> this[int xStart, int yStart, int quadrant]
        {
            get
            {
                for (int i = 0; i < ObjectsInField.Length; i++)
                {
                    if (ObjectsInField[i] != null && ObjectsInField[i].xStart == xStart && ObjectsInField[i].yStart == yStart && FindQuadrant(ObjectsInField[i]) == quadrant)
                        return ObjectsInField[i];
                }
                return null;
            }
        }


        public void AddShip(Ship ship, int xStart, int xEnd, int yStart, int yEnd)
        {
            GridObject<Ship>.CheckLength(ship.Length, xStart, xEnd, yStart, yEnd);
            // If there is no "free space" in the array, we can't create new ship
            if (!ObjectsInField.Contains(null))
            {
                Notify?.Invoke("Список полон. Вы не можете добавить ещё один корабль.");
                return;
            }

            if (xStart > FieldSize.Length || xEnd > FieldSize.Length || yStart > FieldSize.Length || yEnd > FieldSize.Length)
            {
                Notify?.Invoke("Ваши индексы выходят за границу поля.");
                return;
            }

            // Check if we can create a ship
            for (int i = 0; i < ObjectsInField.Length; i++)
            {
                if (ObjectsInField[i] == null)
                    break;
                int coincidences = 0;
                // Checking "free" coordinates (x and y)
                coincidences += CheckCoincidences(xStart, xEnd, ObjectsInField[i].xStart, ObjectsInField[i].xEnd);
                coincidences += CheckCoincidences(yStart, yEnd, ObjectsInField[i].yStart, ObjectsInField[i].yEnd);
                if (coincidences > 1)
                {
                    Notify?.Invoke("Данные индексы уже заняты.");
                    return;
                }
            }

            // If we can create a ship:
            for (int i = 0; i < ObjectsInField.Length; i++)
            {
                if (ObjectsInField[i] == null)
                {
                    ObjectsInField[i] = new GridObject<Ship>(ship, xStart, xEnd, yStart, yEnd, xCenter, yCenter);
                    break;
                }
            }

            Notify?.Invoke("Корабль успешно добавлен.");
        }

        private int CheckCoincidences(int coordStart, int coordEnd, int objectCoordStart, int objectCoordEnd)
        {
            for (int j = coordStart; j <= coordEnd; j++)
                for (int k = objectCoordStart; k <= objectCoordEnd; k++)
                {
                    if (j == k)
                        return 1;
                }
            return 0;
        }

        public void FeildStatus()
        {
            StringBuilder info = new StringBuilder();
            Array.Sort(ObjectsInField);
            int number = 1;
            foreach (GridObject<Ship> s in ObjectsInField)
            {
                if (s != null)
                {
                    info.AppendLine($"{number}. Корабль с начальными координатами {s.xStart};{s.yStart}, длинной {s.Object.Length}.\nPасстояние от центра поля ({xCenter};{yCenter}) =     {s.FindDistanceToCenter(xCenter,yCenter)}.\n Квадрант: {FindQuadrant(s)}");
                    ++number;
                }
            }
            Notify?.Invoke(info.ToString());
        }

        public int FindQuadrant(GridObject<Ship> ship)
        {

            if (ship.xStart >= xCenter && ship.yStart >= yCenter)
            {
                return 1;
            }
            else if (ship.xStart < xCenter && ship.yStart >= yCenter)
            {
                return 2;
            }
            else if (ship.xStart < yCenter && ship.yStart < yCenter)
            {
                return 3;
            }
            else
                return 4;
        }

    }
}
