using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public static class Generation
    {


        public static void init_game()
        {
            Globals.Game_array = new char[Globals.WIN_Y, Globals.WIN_X];    // Main array
            Globals.Maxx = Console.WindowWidth;
            Globals.Maxy = Console.WindowHeight;
            Globals.Win_base_x = (Globals.Maxx - Globals.WIN_X) / 2;
            Globals.Win_base_y = (Globals.Maxy - Globals.WIN_Y) / 2;
            Objects.Space = ' ';
            Objects.Hline = '═';
            Objects.Vline = '║';
            Objects.URcorner = '╔';
            Objects.ULcorner = '╗';
            Objects.DLcorner = '╝';
            Objects.DRcorner = '╚';
            Objects.HUline = '╩';
            Objects.HDline = '╦';
            Objects.VLline = '╣';
            Objects.VRline = '╠';
            Objects.ObjectsColor = ConsoleColor.Cyan;
            Globals.Pac = new Pacman(3, 5, 'C', ConsoleColor.Yellow);

            Console.CursorVisible = false;
        }
        public static void refresh_game()
        {
            Console.SetCursorPosition(Globals.Win_base_x, Globals.Win_base_y);
            for (int i = 0; i < Globals.WIN_Y; i++)
            {
                Console.SetCursorPosition(Globals.Win_base_x, Globals.Win_base_y + i);
                for (int j = 0; j < Globals.WIN_X; j++)
                {
                    if (i == Globals.Pac.pos_y && j == Globals.Pac.pos_x)
                        Console.ForegroundColor = Globals.Pac.color;
                    else
                        Console.ForegroundColor = Objects.ObjectsColor;

                    Console.Write(Globals.Game_array[i, j]);
                }
                Console.SetCursorPosition(Globals.Win_base_x, Globals.Win_base_y + i);
            }
        }
        public static void gen_box()
        {
            for (int i = 0; i < Globals.WIN_Y; i++)
            {
                for (int j = 0; j < Globals.WIN_X; j++)
                {
                    if (i == 0 && j == 0)
                        Globals.Game_array[i, j] = Objects.URcorner;
                    else if ((i == 0 || i == Globals.WIN_Y - 1) && (j > 0 && j < Globals.WIN_X - 1))
                        Globals.Game_array[i, j] = Objects.Hline;
                    else if (i == 0 && j == Globals.WIN_X - 1)
                        Globals.Game_array[i, j] = Objects.ULcorner;
                    else if ((i > 0 && i < Globals.WIN_Y - 1) && (j == 0 || j == Globals.WIN_X - 1))
                        Globals.Game_array[i, j] = Objects.Vline;
                    else if (i == Globals.WIN_Y - 1 && j == 0)
                        Globals.Game_array[i, j] = Objects.DRcorner;
                    else if (i == Globals.WIN_Y - 1 && j == Globals.WIN_X - 1)
                        Globals.Game_array[i, j] = Objects.DLcorner;
                    else if (Globals.Game_array[i, j] == Globals.Pac.Character)
                        continue;
                    else
                        Globals.Game_array[i, j] = Objects.Space;
                }
            }
        }
        public static void gen_game_level()
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            gen_box();
        }
    }
}
