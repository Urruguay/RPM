using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] count = {1, 2, 3, 4, 4, 0, 1, 3};
            // Создаем экземпляр класса Random
            Random random = new Random();

            // Задаем размер массива
            ForegroundColor = ConsoleColor.Magenta;
            Write("Размер необходимого массива -   ");
            ResetColor();
            int size = int.Parse(ReadLine());

            // Создаем массив указанного размера
            int[] count = new int[size];

            // Заполняем массив случайными числами
            for (int i = 0; i < size; i++)
            {
                count[i] = random.Next(0,16);
            }

            // Выводим содержимое массива на консоль
            WriteLine("Случайный массив:");
            foreach (int number in count)
            {
                Write($"< {number} >  ");
            }

            ForegroundColor = ConsoleColor.Magenta;
            Write("\nВыберите число, которое необходимо найти в массиве -   ");
            ResetColor();
            int var = int.Parse(ReadLine());

            for(int i = 0; i < count.Length; i++)
            {
                if (count[i] == var)
                {
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine($"{i}.Мы нашли ваше число, это число - {var} и в массиве оно на {i} месте.");
                    ResetColor();
                }
                else
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine($"Это не ваше число или же вашего числа в данном массиве нет.");
                    ResetColor();
                }
            }

            //function linearSearch(arr, target)
            //{
            //    for (let i = 0; i < arr.length; i++)
            //    {
            //        if (arr[i] === target)
            //        {
            //            return i;
            //        }
            //    }
            //    return -1;
            //}

            //// Пример использования
            //let myList = [1, 2, 3, 4, 5];
            //let target = 3;
            //console.log(linearSearch(myList, target)); // Вывод: 2 (индекс элемента 3)


            Read();
        }
    }
}
