using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsHomework
{
    public struct PointStructDouble
    {
        public double x;
        public double y;
    }
    public class PointClassDouble
    {
        public double x;
        public double y;
    }
    public class Homework3 : IHomework
    {
        public string Name => "3";
        public void Run()
        {
            Console.Clear();
            DrawSpace();
            Console.SetCursorPosition(4, 1);
            Console.Write("100000");
            Console.SetCursorPosition(4, 3);
            Console.Write("200000");
            (TimeSpan intermediateStructTime, TimeSpan generalStructTime, TimeSpan intermediateClassTime, TimeSpan generalClassTime) = TimeMeasurement();
            Console.SetCursorPosition(24, 1);
            Console.Write(intermediateStructTime);
            Console.SetCursorPosition(24, 3);
            Console.Write(generalStructTime);
            Console.SetCursorPosition(44, 1);
            Console.Write(intermediateClassTime);
            Console.SetCursorPosition(44, 3);
            Console.Write(generalClassTime);
            Console.SetCursorPosition(64, 1);
            Console.Write(intermediateClassTime / intermediateStructTime);
            Console.SetCursorPosition(64, 3);
            Console.Write(generalClassTime / generalStructTime);
            Program.ReturntoMainProgram(5);
        }
        static double PointDistanceStruct(PointStructDouble pointOne, PointStructDouble pointTwo)
        {
            double x = pointOne.x - pointTwo.x;
            double y = pointOne.y - pointTwo.y;
            return Math.Sqrt(x * x + y * y);
        }
        static double PointDistanceClass(PointClassDouble pointOne, PointClassDouble pointTwo)
        {
            double x = pointOne.x - pointTwo.x;
            double y = pointOne.y - pointTwo.y;
            return Math.Sqrt(x * x + y * y);
        }
        static (TimeSpan, TimeSpan, TimeSpan, TimeSpan) TimeMeasurement()
        {
            Random random = new Random();
            Stopwatch stopWatchStruct = new Stopwatch();
            Stopwatch stopWatchClass = new Stopwatch();
            TimeSpan intermediateTimeClass = new TimeSpan();
            TimeSpan intermediateTimeStruct = new TimeSpan();
            for (int i = 0; i < 200000; i++)
            {
                double x1 = random.NextDouble();
                double x2 = random.NextDouble();
                double y1 = random.NextDouble();
                double y2 = random.NextDouble();
                stopWatchClass.Start();
                DistanceCheckClass(x1, x2, y1, y2);
                stopWatchClass.Stop();
                stopWatchStruct.Start();
                DistanceCheckStruct(x1, x2, y1, y2);
                stopWatchStruct.Stop();
                if (i == 99999)
                {
                    intermediateTimeClass = stopWatchClass.Elapsed;
                    intermediateTimeStruct = stopWatchStruct.Elapsed;
                }
            }
            return (intermediateTimeStruct, stopWatchStruct.Elapsed, intermediateTimeClass, stopWatchClass.Elapsed); 
        }
        static void DistanceCheckClass(double x1, double x2, double y1, double y2)
        {
            PointClassDouble pointOne = new PointClassDouble { x = x1, y = y1 };
            PointClassDouble pointTwo = new PointClassDouble { x = x2, y = y2 };
            PointDistanceClass(pointOne, pointTwo);
        }
        static void DistanceCheckStruct(double x1, double x2, double y1, double y2)
        {
            PointStructDouble pointOne = new PointStructDouble { x = x1, y = y1 };
            PointStructDouble pointTwo = new PointStructDouble { x = x2, y = y2 };
            PointDistanceStruct(pointOne, pointTwo);
        }
        static void DrawSpace()
        {
            Program.DrawWindow(0, 0, 3, 5);
            WriteName("№", 0, 0, 3);
            Console.SetCursorPosition(1, 1);
            Console.Write("1");
            Console.SetCursorPosition(1, 2);
            Console.Write("═");
            Console.SetCursorPosition(1, 3);
            Console.Write("2");
            Program.DrawWindow(3, 0, 20, 5);
            WriteName(" Кол-во точек ", 3, 0, 20);
            Program.DrawWindow(23, 0, 20, 5);
            WriteName(" StructTime ", 23, 0, 20);
            Program.DrawWindow(43, 0, 20, 5);
            WriteName(" ClassTime ", 43, 0, 20);
            Program.DrawWindow(63, 0, 20, 5);
            WriteName(" Class/Struct ", 63, 0, 20);
        }
        public static void WriteName(string nameSpace, int x, int y, int width)
        {
            Console.SetCursorPosition(x + width / 2 - (nameSpace.Length / 2), y);
            Console.Write(nameSpace);
        }
    }
}
