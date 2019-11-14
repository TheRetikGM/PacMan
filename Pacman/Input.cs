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
        private static Directions wantedDir { get; set; }

        public static void Flush_input()
        {
            while (Console.KeyAvailable)
                Console.ReadKey(true);
        }
        public static void InputHandler()
        {
            Directions wanted_dir = Directions.None;
            ConsoleKeyInfo c = Console.ReadKey(true);
            while (c.Key != ConsoleKey.X)
            {
                switch (c.Key)
                {
                    case ConsoleKey.UpArrow:
                        wanted_dir = Directions.Up;
                        cur_dir = Globals.Pac.Move(Directions.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        wanted_dir = Directions.Down;
                        cur_dir = Globals.Pac.Move(Directions.Down);
                        break;
                    case ConsoleKey.LeftArrow:
                        wanted_dir = Directions.Left;
                        cur_dir = Globals.Pac.Move(Directions.Left);
                        break;
                    case ConsoleKey.RightArrow:
                        wanted_dir = Directions.Right;
                        cur_dir = Globals.Pac.Move(Directions.Right);
                        break;
                    default:
                        cur_dir = Globals.Pac.Move(Globals.Pac.last_move_dir);
                        break;
                }
                if (wanted_dir != Globals.Pac.last_move_dir)
                    Globals.Pac.Move(Globals.Pac.last_move_dir);
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
