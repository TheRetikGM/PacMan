using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class Pacman
    {
        public char Character { get; set; }
        public ConsoleColor color { get; set; }
        public int pos_x { get; set; }
        public int pos_y { get; set; }
        public Directions last_move_dir = Directions.None;
        public int Score { get; set; }

        public Pacman(int pos_y, int pos_x, char pacman_character, ConsoleColor color)
        {           
            this.pos_y = pos_y;
            this.pos_x = pos_x;
            Character = pacman_character;
            this.color = color;
        }
        public Pacman()
        {
            pos_y = 1;
            pos_x = 1;
            Character = 'C';
            color = ConsoleColor.Yellow;
            Score = 0;
            Generation.MvColWrite(Globals.Win_base_y - 1, Globals.Win_base_x, ConsoleColor.Red, "Score: 0");
            Globals.Game_array[pos_y, pos_x].Character = Character;
        }
        public Pacman(int pos_y, int pos_x) : this(pos_y, pos_x, 'C', ConsoleColor.White) { }
        private void move_to(int y, int x)
        {     
            Globals.Game_array[pos_y, pos_x].Character = Objects.Space;
            Globals.Game_array[pos_y, pos_x].Type = CharTypes.Road;
            Globals.Game_array[y, x].Character = Globals.Pac.Character;
            Globals.Game_array[y, x].Type = CharTypes.Pacman;
            Console.SetCursorPosition(Globals.Win_base_x + x, Globals.Win_base_y + y);
            Console.ForegroundColor = color;
            Console.WriteLine(Character);
            Console.SetCursorPosition(Globals.Win_base_x + pos_x, Globals.Win_base_y + pos_y);
            Console.ForegroundColor = color;
            Console.WriteLine(Objects.Space);
            pos_x = x;
            pos_y = y;
        }
        private bool can_move_to(int y, int x)
        {
            if (y >= 0 && y <= Globals.WIN_MAX_Y && x >= 0 && x <= Globals.WIN_MAX_X)
            {
                if (Globals.Game_array[y, x].Type == CharTypes.Food)
                {
                    Score++;
                    Generation.MvColWrite(Globals.Win_base_y - 1, Globals.Win_base_x, ConsoleColor.Red, "Score: " + Score);
                    return true;
                }
                else if (Globals.Game_array[y, x].Type == CharTypes.Road)
                    return true;
                else if (Globals.Game_array[y, x].Type == CharTypes.Warp)
                    return true;
            }
            return false;
        }
        public Directions Move(Directions dir)
        {
            if (dir == Directions.Up)
            {
                if (pos_y - 1 < 0)
                {
                    if (can_move_to(Globals.WIN_MAX_Y - 1, pos_x))
                        move_to(Globals.WIN_MAX_Y - 1, pos_x);
                    last_move_dir = Directions.Up;
                }
                else if (can_move_to(pos_y - 1, pos_x))
                {
                    move_to(pos_y - 1, pos_x);
                    last_move_dir = Directions.Up;
                }
                else
                    return last_move_dir;
                return last_move_dir;
            }
            else if (dir == Directions.Down)
            {
                if (pos_y + 1 > Globals.WIN_MAX_Y - 1)
                {
                    if (can_move_to(0, pos_x))
                        move_to(0, pos_x);
                    last_move_dir = Directions.Down;
                }
                else if (can_move_to(pos_y + 1, pos_x))
                {
                    move_to(pos_y + 1, pos_x);
                    last_move_dir = Directions.Down;
                }
                else
                    return last_move_dir;
                return last_move_dir;
            }
            else if (dir == Directions.Left)
            {
                if (pos_x - 2 < 0 && Globals.Game_array[pos_y, 0].Type == CharTypes.Road)
                {
                    if (can_move_to(pos_y, Globals.WIN_MAX_X - 1))
                        move_to(pos_y, Globals.WIN_MAX_X - 1);
                    last_move_dir = Directions.Left;
                }
                else if (can_move_to(pos_y, pos_x - 2))
                {
                    move_to(pos_y, pos_x - 2);
                    last_move_dir = Directions.Left;
                }
                else
                    return last_move_dir;
                return last_move_dir;
            }
            else if (dir == Directions.Right)
            {
                if (pos_x + 2 > Globals.WIN_MAX_X - 1)
                {
                    if (can_move_to(pos_y, 1))
                        move_to(pos_y, 1);
                    last_move_dir = Directions.Right;
                }
                else if (can_move_to(pos_y, pos_x + 2))
                {
                    move_to(pos_y, pos_x + 2);
                    last_move_dir = Directions.Right;
                }
                else
                    return last_move_dir;
                return last_move_dir;
            }
            else return Directions.None;
        }
    }
}
