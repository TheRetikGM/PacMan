using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pacman
{
    public static class Generation
    {
        public static void init_game()
        {
            Globals.Maxx = Console.WindowWidth;
            Globals.Maxy = Console.WindowHeight;
            Globals.Win_base_x = 1;
            Globals.Win_base_y = 1;
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
            Objects.TicTac = '•';
            Objects.ObjectsColor = ConsoleColor.Cyan;

            Console.CursorVisible = false;
        }
        public static void refresh_game()
        {
            Console.SetCursorPosition(Globals.Win_base_x, Globals.Win_base_y);
            for (int i = 0; i < Globals.WIN_MAX_Y; i++)
            {
                for (int j = 0; j < Globals.WIN_MAX_X; j++)
                {
                    Generation.MvColWrite(Globals.Win_base_y + i, Globals.Win_base_x + j, Globals.Game_array[i, j].color, char.ToString(Globals.Game_array[i, j].Character));
                }
            }
            Console.ResetColor();
            Generation.MvColWrite(Globals.Win_base_y - 1, Globals.Win_base_x, ConsoleColor.Red, "Score: 0");
        }
        public static void gen_game_level()
        {
            string[] Level = File.ReadAllLines("../../Generation/level.txt");
            int a = 0;

            foreach (string s in Level)
            {
                Globals.WIN_MAX_Y++;
                a = 0;
                foreach (char c in s)
                    a++;
                if (a > Globals.WIN_MAX_X)
                    Globals.WIN_MAX_X = a;
            }
            Globals.Game_array = new chtype[Globals.WIN_MAX_Y, Globals.WIN_MAX_X];

            if (Console.WindowHeight < Globals.WIN_MAX_Y)
                Console.WindowHeight = Globals.WIN_MAX_Y + 2;
            if (Console.WindowWidth < Globals.WIN_MAX_X)
                Console.WindowWidth = Globals.WIN_MAX_X;

            for (int i = 0; i < Globals.WIN_MAX_Y; i++)
            {
                string s = Level[i];
                for (int j = 0; j < s.Length; j++)
                {
                    if (s[j] == 'P')
                    {
                        Globals.Pac = new Pacman(i, j);
                        Globals.Game_array[i, j].Type = CharTypes.Pacman;
                        Globals.Game_array[i, j].color = Globals.Pac.color;
                    }
                    getCharFromLegend(s[j], ref Globals.Game_array[i, j]);
                    //Globals.Game_array[i, j].Character = c;
                }
                if (s.Length < Globals.WIN_MAX_X)
                    for (int k = s.Length; k < Globals.WIN_MAX_X; k++)
                    {
                        Globals.Game_array[i, k].Character = ' ';
                        Globals.Game_array[i, k].Type = CharTypes.Wall;
                    }
            }
        }
        private static CharTypes extractCharType(string line)
        {
            bool save = false;
            string eType = "";
            string legendLine = "";

            foreach (char c in line)
            {
                if (c == ':')
                {
                    save = (save) ? false : true;
                    continue;
                }
                if (save)
                    eType = eType + c;                                           
            }
            string[] Legend = File.ReadAllLines("../../Generation/legend_chartypes.txt");
            foreach (string line1 in Legend)
            {
                legendLine = "";
                foreach (char c in line1)
                {
                    if (c == ':')
                        break;
                    legendLine = legendLine + c;                   
                }
                legendLine = legendLine + "";
                if (legendLine == eType)
                {
                    legendLine = line1;
                    break;
                }
            }
            return (CharTypes)(legendLine[legendLine.Length - 1] - '0');
        }
        private static void getCharFromLegend(char ch, ref chtype ga)
        {
            string[] legend = File.ReadAllLines("../../Generation/legend.txt");

            bool a = false;
            string line = "#";
            foreach (string line1 in legend)
            {
                line = line1;
                foreach (char c in line)
                {
                    if (c == ch)
                        a = true;
                }
                if (a)
                    break;
            }
            if (ch == 'P')
                Globals.Pac.Character = line[line.Length - 1];
            ga.Character = line[line.Length - 1];
            ga.Type = extractCharType(line);
        }
        public static void GenTicTacs()
        {
            for (int i = 0; i < Globals.WIN_MAX_Y; i++)
            {
                for (int j = 0; j < Globals.WIN_MAX_X; j++)
                {
                    if (j % 2 == 1)
                    {
                        if (Globals.Game_array[i, j].Type == CharTypes.Road)
                        {
                            Globals.Game_array[i, j].Character = Objects.TicTac;
                            Globals.Game_array[i, j].Type = CharTypes.Food;
                        }
                    }
                }
            }
        }
        public static void ColorWrite(ConsoleColor color, string str)
        {
            Console.ForegroundColor = color;
            Console.Write(str);
            Console.ResetColor();
        }
        public static void MvWrite(int y, int x, string str)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(str);
        }
        public static void MvColWrite(int y, int x, ConsoleColor StringColor, string str)
        {
            Console.SetCursorPosition(x, y);
            ColorWrite(StringColor, str);
        }
        public static void SetColors()
        {
            for (int i = 0; i < Globals.WIN_MAX_Y; i++)
            {
                for (int j = 0; j < Globals.WIN_MAX_X; j++)
                {
                    switch (Globals.Game_array[i, j].Type)
                    {
                        case CharTypes.Entity:
                            Globals.Game_array[i, j].color = ConsoleColor.Red;
                            break;
                        case CharTypes.Pacman:
                            Globals.Game_array[i, j].color = ConsoleColor.Yellow;
                            break;
                        case CharTypes.Wall:
                            Globals.Game_array[i, j].color = ConsoleColor.Cyan;
                            break;
                        case CharTypes.Food:
                            Globals.Game_array[i, j].color = ConsoleColor.Magenta;
                            break;
                        default:
                            Globals.Game_array[i, j].color = ConsoleColor.White;
                            break;
                    }
                }
            }
        }
    }
}