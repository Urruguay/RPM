using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //м) В массиве из n целых чисел найти все элементы,
            //равные квадрату другого элемента массива и
            //составить массив из этих элементов

            ForegroundColor = ConsoleColor.Magenta;
            Write("Введите число элементов в массиве - ");
            ResetColor();
            int n = int.Parse(ReadLine());
            int[] mass = new int[n];

            // Инициализация массива
            for (int i = 0; i < n; i++)
            {
                Write($"Введите элемент mass[{i}]: ");
                mass[i] = int.Parse(ReadLine());
            }

            //int[] mass = { 1, 2, 3, 4, 5, 6, 7, 8, 9};
            // Создаем массив для хранения элементов, равных квадрату другого элемента
            int[] arr = new int[mass.Length];
            int count = 0;
            for (int i = 0; i < mass.Length; i++)
            {
                for (int j = 0; j < mass.Length; j++)
                {
                    if (i != j && mass[i] == mass[j] * mass[j])
                    {
                        mass[i] = (int)Math.Sqrt(mass[i]);
                        arr[count] = mass[i];
                        count++;
                        break; // Если нашли квадратный элемент, нет смысла проверять дальше внутренний цикл
                    }
                }
            }

            // Создаем массив, который содержит только реально использованные элементы из squaredElements
            int[] result = new int[count];
            //копирует count элементов из массива arr в массив result, начиная с индекса 0
            Array.Copy(arr, result, count);
            ForegroundColor = ConsoleColor.Magenta;
            WriteLine("Массив из элементов, равных квадрату другого элемента массива:");
            ResetColor();
            foreach (var element in result)
            {
                Write($"< {element} >\t");
            }
            ReadLine();

        }
    }
}
