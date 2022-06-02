using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsHomework
{
    public class Homework1: IHomework
    {
        public string Name => "1";
        public void Run()
        {
            Console.Clear();
            DrawSpace();
            UpdateConsole();
            Console.ReadKey(true);
        }

        static void task1(int number)
        {
            int d = 0;
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                    d++;
            }
            if (d == 0)
                Console.WriteLine($"{number} - простое");
            else
                Console.WriteLine($"{number} - не простое");
        }

        static void task1AddCheck()
        {
            Console.WriteLine("Для возврата к стартовому окну, оставьте следующее поле пустым.");
            Console.Write("Введите дополнительное значeние проверки: ");
            string checkNumber = Console.ReadLine();
            if (checkNumber == "")
            {
                Console.Clear();
                DrawSpace();
                UpdateConsole();
            }
            else
            {
                task1(Convert.ToInt32(checkNumber));
                task1AddCheck();
            }

        }

        static void task3()
        {
            Console.WriteLine("Для возврата к стартовому окну, оставьте следующее поле пустым.");
            Console.Write("Введите необходимый номер элемента: ");
            string number = Console.ReadLine();
            if (number == "")
            {
                Console.Clear();
                DrawSpace();
                UpdateConsole();
            }
            else
            {
                Console.WriteLine(task3Recursion(Convert.ToInt32(number)) + " - рекурсивное вычисление");
                Console.WriteLine(task3Statement(Convert.ToInt32(number)) + " - циклическое вычисление");
                task3();
            }
        }
        static int task3Recursion(int n)
        {
            if (n == 0) 
                return 0;
            if (n == 1)
                return 1;
            return task3Recursion(n-2) + task3Recursion(n - 1); 
        }
        static int task3Statement(int n)
        {
            int fn1 = 1;
            int fn2 = 1;
            int fn = 0;
            int i = 2;
            while (i < n)
            {
                fn = fn1 + fn2;
                fn1 = fn2;
                fn2 = fn;
                i++;
            }
            return fn;
        }
        static void DrawSpace()
        {
            Program.DrawWindow(0, 0, Program.WINDOW_WIDTH - 1, 10);
            string nameSpace = " Доступные задания ";
            Console.SetCursorPosition((Program.WINDOW_WIDTH - 1) / 2 - (nameSpace.Length / 2), 0);
            Console.Write(nameSpace);
            Console.SetCursorPosition(1, 1);
            Console.Write("└──1");
            Console.SetCursorPosition(4, 2);
            Console.Write("├─1");
            Console.SetCursorPosition(4, 3);
            Console.Write("└─3");
        }
        static void UpdateConsole()
        {
            Program.DrawWindow(0, 10, Program.WINDOW_WIDTH - 1, 3);
            Console.SetCursorPosition(0, 14);
            Console.Write("Оставьте поле пустым для возврата к стартовому меню");
            string nameSpace = " Введине номер задания ";
            Console.SetCursorPosition((Program.WINDOW_WIDTH - 1) / 2 - (nameSpace.Length / 2), 10);
            Console.Write(nameSpace);
            Console.SetCursorPosition(1, 11);
            CommandEnter(Program.WINDOW_WIDTH - 1);
        }
        static void CommandEnter(int width)
        {
            (int left, int top) = Program.GetCursorPosition();
            StringBuilder command = new StringBuilder();
            char key;
            do
            {
                key = Console.ReadKey().KeyChar;

                if (key != 8 && key != 13)
                    command.Append(key);

                (int currentLeft, int currentTop) = Program.GetCursorPosition();

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
                    Console.Clear();
                    task1(71);
                    task1(212);
                    task1AddCheck();
                    break;
                case "3":
                    Console.Clear();
                    task3();
                    break;
                case "":
                    //var prog = new Program();
                    //prog.Main();
                    Program.Main();
                    break;
                default:
                    Console.SetCursorPosition(0, 13);
                    Console.Write("Введено неккоретное значение номера задания");
                    UpdateConsole();
                    break;
            }
        }
    }
}
