using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание12
{
    class Program
    {
        public static int ImputInt()//Ввод вещественных чисел
        {
            bool rightValue;
            int value;

            do
            {
                string userImput = Console.ReadLine();
                rightValue = Int32.TryParse(userImput, out value);
                if (!rightValue) Console.Write(@"Ожидалось число. Повторите ввод - ");
            }
            while (!rightValue);

            return value;
        }

        public static int ImputNat()//Ввод вещественных чисел
        {
            bool rightValue;
            int value;

            do
            {
                string userImput = Console.ReadLine();
                rightValue = Int32.TryParse(userImput, out value);
                if (value < 1) rightValue = false;
                if (!rightValue) Console.Write(@"Ожидалось число. Повторите ввод - ");
            }
            while (!rightValue);

            return value;
        }

        static void Main(string[] args)
        {
            Console.Write(@"Введите длину массива: ");
            int n = ImputNat();

            Console.WriteLine("Введите эл-ты масссива: ");
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
                arr[i] = ImputInt();

            Console.WriteLine("Ваш массив: ");//Вывод массива
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();

            int[] arr0 = arr;
            int a = 0;
            int b = 0;
            int left = 0;
            int right = n - 1;
            int kolp = 0;
            int kols = 0;

            while (left < right)//сортировка перемешиванием
            {
                for (int i = left; i < right; i++)
                {
                    if (arr[i] > arr[i + 1])//слева на право
                    {
                        a = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = a;
                        b = i;
                        kolp++;
                    }
                    kols++;
                }

                right = b;
                if (left >= right) break;

                for (int i = right; i > left; i--)//справа на лево
                {
                    if (arr[i - 1] > arr[i])
                    {
                        a = arr[i];
                        arr[i] = arr[i - 1];
                        arr[i - 1] = a;
                        b = i;
                        kolp++;
                    }
                    kols++;
                }

                left = b;
            }

            Console.WriteLine("Ваш массив, отсортированный перемешиванием: ");//вывод рез-ов
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine("Кол-во пересылок: " + kolp + " Кол-во сравнений: " + kols);

            kols = 0;
            kolp = 0;
            int k = arr.Last();
            int[] c = new int[k + 1];
            int l = 0;

            for (int i = 0; i < k + 1; i++)//сортировка подсчетом
                c[i] = 0;

            for (int i = 0; i < n; i++)//заполнение доп массива
            {
                c[arr0[i]]++;
                kols++;
            }

            for (int i = 0; i < k; i++)//перезаполнение массива
                for (int j = 0; j < c[i]; j++)
                {
                    arr0[l] = i;
                    l++;
                    kolp++;
                }

            Console.WriteLine("Ваш массив, отсортированный подсчетом: ");//вывод рез-ов
            for (int i = 0; i < n; i++)
                Console.Write(arr0[i] + " ");
            Console.WriteLine("Кол-во пересылок: " + kolp + " Кол-во сравнений: " + kols);

            Console.ReadLine();
        }
    }
}
