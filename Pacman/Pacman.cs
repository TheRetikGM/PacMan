using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class Pacman
    {
        /* Variables */
        private char character;
        public ConsoleColor color;
        public int pos_x, pos_y;

        /* Constructor */
        public Pacman(int pos_y, int pos_x, char pacman_character, ConsoleColor color)
        {
            if (can_move_to(pos_y, pos_x))
            {
                this.pos_y = pos_y;
                this.pos_x = pos_x;
            }
            else
            {
                this.pos_y = 1;
                this.pos_x = 1;
            }
            character = pacman_character;
            this.color = color;

            Globals.Game_array[this.pos_y, this.pos_x] = character;
        }
        public Pacman()
        {
            pos_y = 1;
            pos_x = 1;
            character = 'C';
            color = ConsoleColor.Yellow;

            Globals.Game_array[pos_y, pos_x] = character;
        }

        /* Methods */
        private void move_to(int y, int x)
        {
            if (Globals.Game_array[y, x] == Objects.Space)
            {
                Globals.Game_array[pos_y, pos_x] = Objects.Space;
                Globals.Game_array[y, x] = character;
                Console.SetCursorPosition(Globals.Win_base_x + x, Globals.Win_base_y + y);
                Console.WriteLine(character);
                Console.SetCursorPosition(Globals.Win_base_x + pos_x, Globals.Win_base_y + pos_y);
                Console.WriteLine(Objects.Space);
                pos_x = x;
                pos_y = y;
            }
        }
        private bool can_move_to(int y, int x)
        {
            return (y > 0 && y < Globals.WIN_Y && x > 0 && x < Globals.WIN_X && Globals.Game_array[y, x] == Objects.Space) ? true : false;
        }
        public void move_up()
        {
            if (can_move_to(pos_y - 1, pos_x))
                move_to(pos_y - 1, pos_x);
        }
        public void move_down()
        {
            if (can_move_to(pos_y + 1, pos_x))
                move_to(pos_y + 1, pos_x);
        }
        public void move_left()
        {
            if (can_move_to(pos_y, pos_x - 1))
                move_to(pos_y, pos_x - 1);
        }
        public void move_right()
        {
            if (can_move_to(pos_y, pos_x + 1))
                move_to(pos_y, pos_x + 1);
        }
    }
}
