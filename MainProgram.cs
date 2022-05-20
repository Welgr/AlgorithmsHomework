using System;
using System.Text;

namespace AlgorithmsHomework
{
    internal class Program
    {
        public const int WINDOW_HEIGHT = 30;
        public const int WINDOW_WIDTH = 120;
        public static void Main()
        {
            Console.Clear();
            DrawSpace();
            UpdateConsole();
            Console.ReadKey(true);
        }

        static void UpdateConsole()
        {
            DrawWindow(0, 10, WINDOW_WIDTH - 1, 3);
            string nameSpace = " Введине номер задания ";
            Console.SetCursorPosition((WINDOW_WIDTH - 1) / 2 - (nameSpace.Length / 2), 10);
            Console.Write(nameSpace);
            Console.SetCursorPosition(1, 11);
            CommandEnter(WINDOW_WIDTH - 1);
        }
        static void CommandEnter(int width)
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
            CommandParse(command.ToString());

        }

        static void CommandParse(string command)
        {
            switch (command)
            {
                case "1":
                    Homework1.Homework1Main();
                    break;
                case "2":
                    Homework2.Homework2Main();
                    break;
                default:
                    Console.SetCursorPosition(0, 13);
                    Console.Write("Введено неккоретное значение номера работы");
                    UpdateConsole();
                    break;
            }
        }
        public static (int left, int top) GetCursorPosition()
        {
            return (Console.CursorLeft, Console.CursorTop);
        }
        static void DrawSpace()
        {
            DrawWindow(0, 0, WINDOW_WIDTH - 1, 10);
            string nameSpace = " Доступные работы ";
            Console.SetCursorPosition((WINDOW_WIDTH - 1) / 2 - (nameSpace.Length / 2), 0);
            Console.Write(nameSpace);
            Console.SetCursorPosition(1, 1);
            Console.Write("├──1");
            Console.SetCursorPosition(1, 2);
            Console.Write("└──2");
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
    }
}
