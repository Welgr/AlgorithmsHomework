using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsHomework
{
    
    internal class Program
    {

        public const int WINDOW_WIDTH = 120;
        public static void Main()
        {
            Console.Clear();
            List<IHomework> homeworks = new List<IHomework>()
            {
                new Homework1(),
                new Homework2(),
                new Homework3(),
                new Homework4()
            };
            int check = homeworks.Count;
            DrawSpace(homeworks, WINDOW_WIDTH);
            UpdateConsole(homeworks);
            Console.ReadKey(true);
        }
        static void UpdateConsole(List<IHomework> homeworks)
        {
            Program.DrawWindow(0, homeworks.Count + 2, WINDOW_WIDTH - 1, 3);
            Homework3.WriteName(" Введите номер задания ", 0, homeworks.Count + 2, WINDOW_WIDTH - 1);
            Console.SetCursorPosition(1, homeworks.Count + 3);
            CommandEnterParse(WINDOW_WIDTH - 1, homeworks);
        }
        static void CommandEnterParse(int width, List<IHomework> homeworks)
        {
            (int left, int top) = GetCursorPosition();
            StringBuilder command = new StringBuilder();
            char key;
            do
            {
                key = Console.ReadKey().KeyChar;

                if (key != 8 && key != 13)
                    command.Append(key);

                (int currentLeft, int currentTop) = GetCursorPosition();

                if (currentLeft == width - 2)
                {
                    Console.SetCursorPosition(currentLeft - 1, top);
                    Console.Write(" ");
                    Console.SetCursorPosition(currentLeft - 1, top);
                }
                if (key == (char)8/*ConsoleKey.Backspace*/)
                {
                    if (command.Length > 0)
                        command.Remove(command.Length - 1, 1);
                    if (currentLeft >= left)
                    {
                        Console.SetCursorPosition(currentLeft, top);
                        Console.Write(" ");
                        Console.SetCursorPosition(currentLeft, top);
                    }
                    else
                    {
                        Console.SetCursorPosition(left, top);
                    }
                }
            }
            while (key != (char)13);

            foreach (IHomework homework in homeworks)
            {
                if (homework.Name == command.ToString())
                {
                    homework.Run();
                    return;
                }
                else if (homeworks[homeworks.Count - 1] == homework)
                {
                    Console.SetCursorPosition(0, homeworks.Count + 5);
                    Console.Write("Введено неккоретное значение номера работы");
                    UpdateConsole(homeworks);
                }
            }
                
        }

        static void DrawHomeworks(List<IHomework> homeworks, int y)
        {
            for (int i = 0; i < homeworks.Count; i++, y++)
            {
                Console.SetCursorPosition(1, y + 1);
                if (i == homeworks.Count - 1)
                {
                    Console.Write($"└──{homeworks[homeworks.Count - 1].Name}");
                    return;
                }
                Console.Write($"├──{homeworks[i].Name}");
            }
        }
        static void DrawSpace(List<IHomework> homeworks, int WINDOW_WIDTH)
        {
            DrawWindow(0, 0, WINDOW_WIDTH - 1, homeworks.Count + 2);
            Homework3.WriteName(" Доступные работы ", 0, 0, WINDOW_WIDTH - 1);
            DrawHomeworks(homeworks, 0);
        }
        public static void DrawWindow(int x, int y, int width, int height)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("╔");
            for (int i = 0; i < width - 2; i++)
            {
                Console.Write("═");
            }
            Console.WriteLine("╗");
            Console.SetCursorPosition(x, y + 1);
            for (int i = 0; i < height - 2; i++)
            {
                Console.Write("║");
                for (int j = 0; j < width - 2; j++)
                {
                    Console.Write(' ');
                }
                Console.WriteLine("║");
                Console.SetCursorPosition(x, y + 2 + i);
            }
            Console.Write("╚");
            for (int i = 0; i < width - 2; i++)
            {
                Console.Write("═");
            }
            Console.WriteLine("╝");
            Console.SetCursorPosition(x, y);
        }
        public static void ReturntoMainProgram(int y)
        {
            string returnPhrase = "Нажмите любую клавишу для возврата к стартовому меню";
            Console.SetCursorPosition((WINDOW_WIDTH - 1 )/ 2 - returnPhrase.Length / 2 , y);
            Console.Write(returnPhrase);
            Console.ReadKey(true);
            Main();
        }

        public static (int left, int top) GetCursorPosition()
        {
            return (Console.CursorLeft, Console.CursorTop);
        }
       
    }
}
