using System;
using System.Diagnostics.SymbolStore;
using System.Threading;

namespace labb2
{
    internal class Program
    {
        abstract class Body
        {
            protected abstract double SurfaceArea();
            protected abstract double Volume();
            public virtual double getSurfaceArea
            {
                get { return SurfaceArea(); }
            }
            public virtual double getVolume
            {
                get { return Volume(); }
            }
        }
        class Parallelepiped : Body
        {
            private double A;
            private double B;
            private double C;
            protected override double SurfaceArea() => 2 * (A * C + A * B + B * C);
            protected override double Volume() => A * B * C;
            public Parallelepiped(double a1, double b1, double c1) 
            {
                A = a1;
                B = b1;
                C = c1;
            }
        }
        class Ball : Body
        {
            private double R;
            protected override double SurfaceArea() => 4 * 3.14 * R;
            protected override double Volume() => (4 * 3.14 * R * R * R) / 3;
            public Ball(double r) => R = r;
        }
        class Pyramid : Body
        {
            private double H;
            private double A;
            private double B;
            private double ApophFromA;
            private double ApophFromB;
            protected override double SurfaceArea() => A * B + ApophFromA * A + ApophFromB * B;
            protected override double Volume() => (A * B * H) / 3;
            public Pyramid(double h, double a, double b)
            {
                H = h;
                A = a;
                B = b;
                ApophFromA = Math.Sqrt(H * H + B / 2 * B / 2);
                ApophFromB = Math.Sqrt(H * H + A / 2 * A / 2);
            }
        }
        static void PrintBody(Body body)
        {
            Console.WriteLine($"Площадь поверхности: {body.getSurfaceArea}  Объём: {body.getVolume}");
            Console.WriteLine();
        }
        static double InputDouble()
        {
            double num;
            while (true)
            {
                var input = Console.ReadLine();
                if (double.TryParse(input, out num) == true)
                {
                    if (num != 0)
                    {
                        if (num > 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод!");
                            Console.Write("Введите число ещё раз: ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод!");
                        Console.Write("Введите число ещё раз: ");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод!");
                    Console.Write("Введите число ещё раз: ");
                }
            }
            return num;
        }
        static int InputInt()
        {
            int num;
            while (true)
            {
                var input = Console.ReadLine();
                if (int.TryParse(input, out num) == true)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод!");
                    Console.Write("Введите число ещё раз: ");
                }
            }
            return num;
        }
        static void Main()
        {
            double A1, B1, C1;
            Console.WriteLine("Введите сторону А, B и С параллелепипеда: ");
            A1 = InputDouble();
            B1 = InputDouble();
            C1 = InputDouble();
            Console.Clear();

            double R1;
            Console.WriteLine("Введите радиус шара: ");
            R1 = InputDouble();
            Console.Clear();

            double H1, A2, B2;
            Console.WriteLine("Введите высоту пирамиды: ");
            H1 = InputDouble();
            Console.WriteLine("Введите две стороны пирамиды: ");
            A2 = InputDouble();
            B2 = InputDouble();

            Console.Clear();
            while (true) 
            {
                int menu;
                Console.WriteLine("(1) - Вывести на экран площадь поверхности и объём параллелепипеда;\n");
                Console.WriteLine("(2) - Вывести на экран площадь поверхности и объём шара;\n");
                Console.WriteLine("(3) - Вывести на экран площадь поверхности и объём пирамиды;\n");
                Console.WriteLine("(4) - Вывести на экран введённые значения с клавиатуры; \n");
                Console.WriteLine("(5) - Выход.\n\n");
                Console.WriteLine("Выберите, что должна сделать программа: ");
                menu = InputInt();
                Console.Clear();
                switch (menu)
                {
                    case 1:
                        var parallelepiped1 = new Parallelepiped(A1, B1, C1);
                        PrintBody(parallelepiped1);
                        break;
                    case 2:
                        var ball1 = new Ball(R1);
                        PrintBody(ball1);
                        break;
                    case 3:
                        var pyramid1 = new Pyramid(H1, A2, B2);
                        PrintBody(pyramid1);
                        break;
                    case 4:
                        Console.WriteLine($"Стороны прямоугольника: A = {A1}, B = {B1}, C = {C1};\n");
                        Console.WriteLine($"Радиус шара: R = {R1};\n");
                        Console.WriteLine($"Боковые стороны пирамиды: A = {A2}, B = {B2}; Высота пирамиды H = {H1};\n");
                        break;
                    case 5:
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод!");
                        Thread.Sleep(900);
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
