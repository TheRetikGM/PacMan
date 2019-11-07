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
            Input.MoveDelay = 400;

            Generation.init_game();
            Generation.gen_game_level();
            Generation.GenTicTacs();
            Generation.refresh_game();
            Input.InputHandler();
        }
    }
}