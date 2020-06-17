using System;
using System.Collections.Generic;

namespace mars
{
    class Program
    {
        enum CorEnum { N , S , E , W  };
        private enum DrctCmd { L, R, M };

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            beginrover:        
            int x, y;
            Console.WriteLine("Lütfen alanı giriniz (5 5)");
            string areaCmd = Console.ReadLine().Trim();
            string []_area = areaCmd.Split(' ');
            if (_area.Length != 2)
            {
                Console.WriteLine("Alan için 2 sayı giriniz");
                goto beginrover;
            }

            if (!Char.IsNumber(_area[0], 0) || !Char.IsNumber(_area[1], 0))
            {
                Console.WriteLine("Alan için 2 sayı giriniz");
                goto beginrover;
            }


            int[,] area = new int[Convert.ToInt32(_area[0]), Convert.ToInt32(_area[1])];
            int loop = 1;
          
            while (loop <= 2)
            {
                backto:
                Console.WriteLine("\n\nBaşlangıç kordinatını giriniz (örn: 1 2 N)");
                string cordinat = Console.ReadLine().Trim();
                string[] _cordinat = cordinat.Split(' ');
                if (_cordinat.Length == 3)
                {
                    if (!Char.IsNumber(_cordinat[0], 0) || !Char.IsNumber(_cordinat[1], 0))
                    {
                        Console.WriteLine("\\Lütfen rakam giriniz");
                        goto backto;
                    }

                    string cor = _cordinat[2].ToUpper();

                    if (!Enum.IsDefined(typeof(CorEnum), cor))
                    {
                        Console.WriteLine("Geçersiz kordinat");
                        goto backto;
                    }
                    backtoloc:
                    Console.WriteLine("\nLütfen lokasyon giriniz (örn: LMLMLMLMM)");
                    string cmdStr = Console.ReadLine().Trim();
                    if (string.IsNullOrEmpty(cmdStr))
                    {
                        Console.WriteLine("Lokasyon boş geçilemez");
                        goto backtoloc;
                    }

                    foreach (var cmd in cmdStr)
                    {
                        if (!Enum.IsDefined(typeof(DrctCmd), cmd.ToString()))
                        {
                            Console.WriteLine("Geçersiz lokasyon");
                            goto backtoloc;
                        }
                    }
                    int.TryParse(_cordinat[0], out x);
                    int.TryParse(_cordinat[1], out y);
                    move mars = new move(x, y, cor);
                    mars.moveRover(cmdStr, area);
                    if (mars.Ok)
                    {
                        Console.WriteLine("{0} {1} {2}", mars.Xcor, mars.Ycor, mars._Direction);
                        loop++;
                    }
                }
                else
                {
                    Console.WriteLine("Yanlış kordinat girdiniz \n\r Tekrar deneyiniz.");
                }


            }

            


           
            Console.ReadKey();
        }

     

    }
}
