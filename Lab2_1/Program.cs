using System;

class Program
{
    static void Main(string[] args)
    {
        // Ввод данных для базового класса
        Console.WriteLine("Введите три целых числа для базового класса (field1, field2, field3):");
        BaseClass baseObj = CreateBaseClassFromInput();

        Console.WriteLine(baseObj.ToString());
        Console.WriteLine("Максимальная последняя цифра: " + baseObj.MaxLastDigit());
        Console.WriteLine("");
        // Тестирование копирования значений
        BaseClass copiedBaseObj = new BaseClass(baseObj);
        Console.WriteLine("Скопированные значения:");
        Console.WriteLine(copiedBaseObj.ToString());
        Console.WriteLine("");

        // Ввод данных для прямоугольника 
        Console.WriteLine("Введите координаты верхнего левого угла прямоугольника (x, y, z) и размеры (ширина, высота):");
        Rectangle rect = CreateRectangleFromInput();

        Console.WriteLine(rect.ToString());
        Console.WriteLine("Площадь: " + rect.Area());
        Console.WriteLine("Периметр: " + rect.Perimeter());
        Console.WriteLine("");

        var topLeft = rect.GetTopLeftCorner();
        Console.WriteLine($"Координаты верхнего левого угла: ({topLeft.x}, {topLeft.y}, {topLeft.z})");
    }

    static BaseClass CreateBaseClassFromInput()
    {
        int field1 = GetValidInt("Введите значение 1: ");
        int field2 = GetValidInt("Введите значение 2: ");
        int field3 = GetValidInt("Введите значение 3: ");
        return new BaseClass(field1, field2, field3);
    }

    static Rectangle CreateRectangleFromInput()
    {
        int x = GetValidInt("Введите x: ");
        int y = GetValidInt("Введите y: ");
        int z = GetValidInt("Введите z: ");
        int width = GetValidPositiveInt("Введите ширину: ");
        int height = GetValidPositiveInt("Введите высоту: ");
        return new Rectangle(x, y, z, width, height);
    }

    static int GetValidInt(string prompt)
    {
        int value;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (int.TryParse(input, out value))
            {
                return value;
            }
            else
            {
                Console.WriteLine("Ошибка: Введите корректное целое число.");
            }
        }
    }

    static int GetValidPositiveInt(string prompt)
    {
        int value;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (int.TryParse(input, out value) && value >= 0)
            {
                return value;
            }
            else
            {
                Console.WriteLine("Ошибка: Введите положительное целое число.");
            }
        }
    }
}
