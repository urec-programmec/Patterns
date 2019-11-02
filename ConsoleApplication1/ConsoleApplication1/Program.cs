using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ConsoleApplication1
{    
    class Program
    {
        static List<Line> lines_body = new List<Line>();
        static List<int[]> lines_index = new List<int[]>();
        static int columns = 10;
        static int rows = 50;
        
        
        static void Show()
        {
            Console.Clear();
            string result = "", temp = "", body = "";
            int start = -1, end = -1, row = -1, rowLast = 0;
            for (int j = 0; j < lines_body.Count; j++)
            {
                int len = temp.Length;
                body = lines_body[j].Draw();
                //int[] arr = lines_index[i];
                start = lines_index[j][0];
                end = lines_index[j][1];
                row = lines_index[j][2];

                if (rowLast - row != 0)
                {                   
                    result += temp + "\n";
                    temp = "";
                    

                    for (int qq = 0; qq < row - rowLast - 1; qq++)
                        result += "\n";

                    rowLast = row;
                }
                
                temp += new string(' ', (start - temp.Length)) + body;
                
                
            }
            result += temp;

            for (int qq = 0; qq < columns - rowLast - 1; qq++)
                result += "\n";

            Console.WriteLine(result);
        }

        static void ShowRandom()
        {
            lines_body = new List<Line>();
            lines_index = new List<int[]>();

            int Lenght = 0;
            double random = 0;
            string result = "", temp = "", t = "";            
            EndOfLines[] ends = { new Dot(), new Arrow(), new Rhomb() };            
            Random rnd = new Random();
            Line line;

            for (int j = 0; j < columns; j++)
            {
                temp = "";                
                for (int k = 0; k < rows; k++)
                {
                    if (temp.Length % 2 == 1)
                    {
                        temp += " ";
                        k++;
                    }


                    random = (rnd.Next(0, 1000) / 1000.0);

                    if (random > 0.8)
                    {
                        Lenght = rnd.Next(2, 20);
                        line = new Line(Lenght, ends[rnd.Next(0, 3)], ends[rnd.Next(0, 3)]);
                        line.changed += Show;
                        t = line.Draw();

                        if (temp.Length + t.Length + 1 < rows)
                        {                            
                            lines_body.Add(line);
                            lines_index.Add(new int[] { k, k + t.Length -1, j });
                            temp += t;
                            k += t.Length - 1;
                        }
                        else
                            temp += " ";
                    }
                    else
                        temp += " ";
                }

                result += temp + "\n";
            }

            Console.WriteLine(result);
        }

        static void Main(string[] args)
        {
            /*
            for (int i = 0; i < 10; i++)
            {
                Console.Clear();
                ShowRandom();
                Console.ReadLine();
                Show();
                Console.ReadLine();
            }
            */
            ShowRandom();
            
            for (int j = 0; j < 10; j++)
            {


                Console.WriteLine("Choose line to change (max = " + lines_body.Count + ")");
                int index = int.Parse(Console.ReadLine()) - 1;
                Console.WriteLine("Choose left ends (dot / arrow / rhomb)");
                string left = Console.ReadLine();

                if (left == "")
                    left = "dot";

                Console.WriteLine("Choose right ends (dot / arrow / rhomb)");
                string right = Console.ReadLine();

                if (right == "")
                    right = "dot";

                if (index < lines_body.Count && index >= 0 && (left == "dot" || left == "arrow" || left == "rhomb") && (right == "dot" || right == "arrow" || right == "rhomb"))
                {
                    EndOfLines leftE = null, rightE = null;

                    switch (left)
                    {
                        case "dot":
                            leftE = new Dot();
                            break;
                        case "arrow":
                            leftE = new Arrow();
                            break;
                        case "rhomb":
                            leftE = new Rhomb();
                            break;
                        default:
                            break;
                    }

                    switch (right)
                    {
                        case "dot":
                            rightE = new Dot();
                            break;
                        case "arrow":
                            rightE = new Arrow();
                            break;
                        case "rhomb":
                            rightE = new Rhomb();
                            break;
                        default:
                            break;
                    }

                    lines_body[index].changeLeft(leftE);
                    lines_body[index].changeRight(rightE);

                }
                else
                    Console.WriteLine("No, sorry");
            }            
        }
    }
}
