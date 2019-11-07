using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class Input
    {
        private static Directions cur_dir;
        public static int MoveDelay = 500;

        public static void Flush_input()
        {
            while (Console.KeyAvailable)
                Console.ReadKey(true);
        }
        public static void InputHandler()
        {
            ConsoleKeyInfo c = Console.ReadKey(true);
            while (c.Key != ConsoleKey.X)
            {
                switch (c.Key)
                {
                    case ConsoleKey.UpArrow:
                        cur_dir = Globals.Pac.Move(Directions.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        cur_dir = Globals.Pac.Move(Directions.Down);
                        break;
                    case ConsoleKey.LeftArrow:
                        cur_dir = Globals.Pac.Move(Directions.Left);
                        break;
                    case ConsoleKey.RightArrow:
                        cur_dir = Globals.Pac.Move(Directions.Right);
                        break;
                    default:
                        cur_dir = Globals.Pac.Move(Globals.Pac.last_move_dir);
                        break;
                }
                if (cur_dir != Directions.None)
                {
                    System.Threading.Thread.Sleep(MoveDelay);
                    if (Console.KeyAvailable)
                        c = Console.ReadKey(true);
                }
                else
                    c = Console.ReadKey(true);
                Flush_input();
                if (Globals.Pac.Character == 'C') Globals.Pac.Character = 'c';
                else if (Globals.Pac.Character == 'c') Globals.Pac.Character = 'C';
            }
        }
    }
}
