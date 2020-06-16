using SeaFight.DLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaFight.View
{
    class Program
    {
        static void Main(string[] args)
        {
            Field field = new Field();
            field.Notify += DisplayMessage;
            Ship s1 = new MilitaryShip(1,1,1,1);
            Ship s2 = new MixedTypeShip(1, 1, 1, 1);
            Ship s3 = new AuxiliaryShip(3, 4, 2, 2);
            Ship s4 = new MilitaryShip(5, 6, 7, 7);
            Ship s5 = new MilitaryShip(8, 9, 7, 7);
            // Проверка добавления кораблей на поле
            field.AddShip(s1);
            field.AddShip(s2);
            field.AddShip(s3);
            field.AddShip(s4);
            field.AddShip(s5);
            // Проверка статуса поля
            field.FeildStatus();
            // Проверка сравнения.
            Console.WriteLine("Проверка сравнения: "+(s1==s2)+ " " +(s4==s5) );
            // Проверка индексатора
            Console.WriteLine(field[1,1,3]?.Name??"Такого обьекта не существует");
            Console.WriteLine(field[3, 1, 3]?.Name ?? "Такого обьекта не существует");
            Console.ReadKey();
        }

        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
