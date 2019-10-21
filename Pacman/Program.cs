﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class Program
    {
        static void init_game()
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
            Objects.Color = ConsoleColor.Cyan;
            Globals.Pac = new Pacman(3, 5, 'C', ConsoleColor.Yellow);

            Console.CursorVisible = false;
        }
        static void refresh_game()
        {
            for (int i = 0; i < Globals.WIN_Y; i++)
            {
                for (int j = 0; j < Globals.WIN_X; j++)
                {
                    Console.SetCursorPosition(Globals.Win_base_x + j, Globals.Win_base_y + i);

                    if (i == Globals.Pac.pos_y && j == Globals.Pac.pos_x)
                        Console.ForegroundColor = Globals.Pac.color;
                    else
                        Console.ForegroundColor = Objects.Color;

                    Console.Write(Globals.Game_array[i, j]);
                }
            }
        }
        static void gen_box()
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
                    else
                        Globals.Game_array[i, j] = Objects.Space;
                }
            }
        }
        static void gen_rand_walls(char type, int amount)
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int rand_x, rand_y, a, b;

            if (type == 'v')
                a = 3;
            else if (type == 'h')
                a = 6;
            else return;

            for (int i = 0; i < amount; i++)
            {
                rand_x = rnd.Next(1, Globals.WIN_X - 1);
                rand_y = rnd.Next(1, Globals.WIN_Y - 1);

                for (int j = 0; j < a; j++)
                {
                    if ((type == 'v') ? rand_y + j >= Globals.WIN_Y - 1 : rand_x + j >= Globals.WIN_X - 1)
                        break;
                    if (type == 'v')
                        Globals.Game_array[rand_y + j, rand_x] = Objects.Vline;
                    else
                        Globals.Game_array[rand_y, rand_x + j] = Objects.Hline;
                }
            }
        }
        static void link_walls()
        {
            for (int i = 0; i < Globals.WIN_Y; i++)
            {
                for (int j = 0; j < Globals.WIN_X; j++)
                {

                }
            }
        }
        static void gen_game_level()
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            gen_box();
            //gen_rand_walls('v', rnd.Next(8, 10));
            //gen_rand_walls('h', rnd.Next(8, 10));
            //link_walls();

        }
        static void flush_input()
        {
            while (Console.KeyAvailable)
                Console.ReadKey(true);
        }

        static void Main(string[] args)
        {
            init_game();
            gen_game_level();
            refresh_game();

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
                refresh_game();
                //h_input();
            }     
        }
    }
}
