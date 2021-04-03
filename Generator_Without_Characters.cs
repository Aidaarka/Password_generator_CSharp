using System;
using System.Text;

namespace Lab2_HkI
{
    class Program
    {
        static void Main(string[] args)
        {
            /* P - вероятность взлома; 
             * V – скорость взлома (число паролей в минуту);
             * T – время действия пароля; А – число парольных символов;
             * L – искомая длина пароля; S - пространство взлома (число возможных паролей).
            */
            int V, T, L = 0;

            double A, A1 = 1;

            double S, P;

            Console.WriteLine("Введите P - вероятность взлома: ");
            P = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите V – скорость взлома (число паролей в минуту): ");
            V = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите T – время действия пароля (в днях): ");
            T = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите А – число парольных символов: ");
            A = Convert.ToDouble(Console.ReadLine());

            S = V * T * 60 * 24 * 12 / P;

            Console.WriteLine("Число возможных паролей S: {0}", Math.Round(S, 2));

            while (A1 < S)
            {
                L++;
                A1 = A1 * A; // степени А
            }

            Console.WriteLine("L: " + L);

            //создаем объект Random, генерирующий случайные числа
            Random rnd = new Random();

            Console.Write("Сгенерированный пароль: ");

            //В цикле генерируется случайная строка символов
            char[] a = new char[L];
            for (int i = 0; i < L; i++)
            {
                a[i] = (char)rnd.Next(33, 125);
                Console.Write(a[i]);
            }
            Console.ReadKey(true);
        }
    }
}


