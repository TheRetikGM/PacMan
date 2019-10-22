using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class Input
    {
        public static void Flush_input()
        {
            while (Console.KeyAvailable)
                Console.ReadKey(true);
        }
        public static void InputHandler()
        {
            ConsoleKeyInfo c;
            while ((c = Console.ReadKey(true)).Key != ConsoleKey.X)
            {
                switch (c.Key)
                {
                    case ConsoleKey.UpArrow:
                        Globals.Pac.move_up();
                        break;
                    case ConsoleKey.DownArrow:
                        Globals.Pac.move_down();
                        break;
                    case ConsoleKey.LeftArrow:
                        Globals.Pac.move_left();
                        break;
                    case ConsoleKey.RightArrow:
                        Globals.Pac.move_right();
                        break;
                }
                Flush_input();
            }
        }
    }
}
