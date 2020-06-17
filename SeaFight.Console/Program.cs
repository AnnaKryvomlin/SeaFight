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
            Ship s1 = new MilitaryShip(1,2,3);
            Ship s2 = new MixedTypeShip(1,3,3);
            Ship s3 = new AuxiliaryShip(2,1,1);
            Ship s4 = new MilitaryShip(1,2,3);
            Ship s5 = new MilitaryShip(3,2,2);
            // Проверка добавления кораблей на поле
            field.AddShip(s1,1,1,1,1);
            field.AddShip(s2,1,1,1,1);
            field.AddShip(s3,3,4,4,4);
            field.AddShip(s4,2,2,6,6);
            //field.AddShip(s5,7,8,5,5); /*Ошибка, длина не соответствует координате*/
            // Проверка статуса поля
            field.FeildStatus();
            // Проверка сравнения.
            Console.WriteLine("Проверка сравнения: " + (s1 == s2) + " " + (s4 == s1) );
            // Проверка индексатора
            Console.WriteLine(field[1, 1, 3]?.Object.Name ?? "Такого обьекта не существует");
            Console.WriteLine(field[3, 1, 3]?.Object.Name ?? "Такого обьекта не существует");
            Console.ReadKey();
        }

        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
