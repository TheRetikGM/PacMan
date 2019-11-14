using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Input.MoveDelay = 200;

            Generation.init_game();
            Generation.gen_game_level();
            Globals.Pac.color = ConsoleColor.Yellow;  
            Generation.GenTicTacs();
            Generation.SetColors();
            Generation.refresh_game();
            Generation.MvColWrite(Globals.Win_base_y + Globals.WIN_MAX_Y, Globals.Win_base_x, ConsoleColor.Green, "Press 'x' to quit");
            Input.InputHandler();
        }
    }
}