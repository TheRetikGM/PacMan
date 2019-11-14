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
                        Globals.Pac.Move(Directions.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        Globals.Pac.Move(Directions.Down);
                        break;
                    case ConsoleKey.LeftArrow:
                        Globals.Pac.Move(Directions.Left);
                        break;
                    case ConsoleKey.RightArrow:
                        Globals.Pac.Move(Directions.Right);
                        break;
                    default:
                        Globals.Pac.Move(Globals.Pac.last_move_dir);
                        break;
                }              
                System.Threading.Thread.Sleep(MoveDelay);

                if (Console.KeyAvailable)
                    c = Console.ReadKey(true);

                Flush_input();

                if (Globals.Pac.Character == Char.ToLower(Globals.Pac.Character))
                    Globals.Pac.Character = char.ToUpper(Globals.Pac.Character);
                else if (Globals.Pac.Character == Char.ToUpper(Globals.Pac.Character))
                    Globals.Pac.Character = char.ToLower(Globals.Pac.Character);
            }
        }
    }
}
