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
        public char Character;
        public ConsoleColor color;
        public int pos_x, pos_y;
        public Directions last_move_dir = Directions.None;
        public int Score = 0;

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
            Character = pacman_character;
            this.color = color;

            Globals.Game_array[this.pos_y, this.pos_x] = Character;
        }
        public Pacman()
        {
            pos_y = 1;
            pos_x = 1;
            Character = 'C';
            color = ConsoleColor.Yellow;

            Globals.Game_array[pos_y, pos_x] = Character;
        }

        /* Methods */
        private void move_to(int y, int x)
        {
            if (Globals.Game_array[y, x] == Objects.Space)
            {
                Globals.Game_array[pos_y, pos_x] = Objects.Space;
                Globals.Game_array[y, x] = Character;
                Console.SetCursorPosition(Globals.Win_base_x + x, Globals.Win_base_y + y);
                Console.ForegroundColor = color;
                Console.WriteLine(Character);
                Console.SetCursorPosition(Globals.Win_base_x + pos_x, Globals.Win_base_y + pos_y);
                Console.ForegroundColor = color;
                Console.WriteLine(Objects.Space);
                pos_x = x;
                pos_y = y;
            }
        }
        private bool can_move_to(int y, int x)
        {
            return (y > 0 && y < Globals.WIN_Y && x > 0 && x < Globals.WIN_X && Globals.Game_array[y, x] == Objects.Space) ? true : false;
        }
        public Directions Move(Directions dir)
        {
            if (dir == Directions.Up)
            {
                if (can_move_to(pos_y - 1, pos_x))
                {
                    move_to(pos_y - 1, pos_x);
                    last_move_dir = Directions.Up;
                    return last_move_dir;
                }
                else
                    return Directions.None;
            }
            else if (dir == Directions.Down)
            {
                if (can_move_to(pos_y + 1, pos_x))
                {
                    move_to(pos_y + 1, pos_x);
                    last_move_dir = Directions.Down;
                    return last_move_dir;
                }
                else
                    return Directions.None;
            }
            else if (dir == Directions.Left)
            {
                if (can_move_to(pos_y, pos_x - 2))
                {
                    move_to(pos_y, pos_x - 2);
                    last_move_dir = Directions.Left;
                    return last_move_dir;
                }
                else
                    return Directions.None;
            }
            else if (dir == Directions.Right)
            {
                if (can_move_to(pos_y, pos_x + 2))
                {
                    move_to(pos_y, pos_x + 2);
                    last_move_dir = Directions.Right;
                    return last_move_dir;
                }
                else
                    return Directions.None;
            }
            else return last_move_dir;
        }
    }
}
