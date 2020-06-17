using System;
using System.Collections.Generic;
using System.Text;

namespace mars
{
   public class move
    {
        public int Xcor{ get; set; }
        public int Ycor { get; set; }
        public string _Direction { get; set; }

        public bool Ok=true;

        static Dictionary<string, string> direction = new Dictionary<string, string>();

        public move(int Xpos, int Ypos, string _dir)
        {
            Xcor = Xpos;
            Ycor = Ypos;
            _Direction = _dir;
            init();
        }


        public void moveRover(string cmds, int[,] area)
        {
            foreach (char cmd in cmds)
            {
                if (cmd.Equals('M')) 
                {
                    switch (_Direction)
                    {
                        case "N":
                            Ycor += 1;
                            break;
                        case "S":
                            Ycor -= 1;
                            break;
                        case "E":
                            Xcor += 1;
                            break;
                        case "W":
                            Xcor -= 1;
                            break;
                    }

                    if (Xcor < 0 || Ycor < 0 || Xcor > area.GetLength(0) || Ycor > area.GetLength(1))
                    {
                        Console.WriteLine("!! Rover alan dışında !!");
                        Ok = false;
                    }
                }
                else
                {
                    // change direction 

                    _Direction = getDirection(_Direction+cmd.ToString());
                }
            }
        }


        static void init()
        {
            direction.Clear();
            direction.Add("NR", "E");
            direction.Add("NL", "W");
            direction.Add("NM", "N");

            direction.Add("ER", "S");
            direction.Add("EL", "N");
            direction.Add("EM", "E");

            direction.Add("SR", "W");
            direction.Add("SL", "E");
            direction.Add("SM", "S");

            direction.Add("WR", "N");
            direction.Add("WL", "S");
            direction.Add("WM", "W");



        }

        static string getDirection(string d)
        {
            string val = "";
            if (direction.TryGetValue(d, out val))
                return val;

            return val;
        }


    }
}
