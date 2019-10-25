using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int[]> points = new List<int[]>();
            string[] xy = { "X1=", "\tY1=", "\tX2=", "\tY2=" };
            Random rnd = new Random();
            while (true)
            {
                Console.WriteLine("1. add line (none, none)");
                Console.WriteLine("2. add line (strelka, strelka)");
                Console.WriteLine("3. add line (romb, romb)");
                Console.WriteLine("4. print lines");
                switch (Console.ReadLine())
                {
                    case "1": points.Add(new int[]{
                    rnd.Next(-10, 11),rnd.Next(-10, 11),
                    rnd.Next(-10, 11),rnd.Next(-10, 11),
                    1,1}); break;
                    case "2": points.Add(new int[]{
                    rnd.Next(-10, 11),rnd.Next(-10, 11),
                    rnd.Next(-10, 11),rnd.Next(-10, 11),
                    2,2}); break;
                    case "3": points.Add(new int[]{
                    rnd.Next(-10, 11),rnd.Next(-10, 11),
                    rnd.Next(-10, 11),rnd.Next(-10, 11),
                    3,3}); break;
                    case "4":
                        foreach (int[] point in points)
                        {
                            for (int i = 0; i < 4; i++)
                                Console.Write(xy[i] + point[i]);
                            switch (point[4])
                            {
                                case 1: Console.Write("\t(none, "); break;
                                case 2: Console.Write("\t(strelka, "); break;
                                case 3: Console.Write("\t(romb, "); break;
                            }
                            switch (point[5])
                            {
                                case 1: Console.Write("none)"); break;
                                case 2: Console.Write("strelka)"); break;
                                case 3: Console.Write("romb)"); break;
                            }
                            Console.WriteLine();
                        }
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
