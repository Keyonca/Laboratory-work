using System;

class Program
{
    static void Main(string[] args)
    {
        double start = 0;
        double end = 0;

        // Ввод данных от пользователя для начала отрезка
        while (true)
        {
            try
            {
                Console.WriteLine("Введите координаты начала отрезка:");
                start = double.Parse(Console.ReadLine());
                Console.WriteLine("");
                break; // Выход из цикла, если ввод корректен
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: некорректный ввод. Пожалуйста, введите числовое значение.");
                Console.WriteLine("");
            }
        }

        // Ввод данных от пользователя для конца отрезка
        while (true)
        {
            try
            {
                Console.WriteLine("Введите координаты конца отрезка:");
                end = double.Parse(Console.ReadLine());
                Console.WriteLine("");
                break; // Выход из цикла, если ввод корректен
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: некорректный ввод. Пожалуйста, введите числовое значение.");
                Console.WriteLine("");
            }
        }

        // Создание экземпляра класса LineSegment
        LineSegment segment = new LineSegment(start, end);
        Console.WriteLine(segment.ToString()); // Выводим информацию об отрезке 
        // Проверка длины отрезка
        double length = !segment;
        Console.WriteLine($"Длина отрезка: {length}");
        Console.WriteLine("");

        // Увеличение координат границ отрезка на 1
        segment++;
        Console.WriteLine($"Координаты после увеличения на 1: {segment}");
        Console.WriteLine("");

        // Преобразование в int
        int intPart = (int)segment;
        Console.WriteLine($"Целая часть координаты начала отрезка: {intPart}");
        Console.WriteLine("");

        // Преобразование в double
        double doublePart = segment;
        Console.WriteLine($"Координата конца отрезка как double: {doublePart}");
        Console.WriteLine("");

        // Ввод числа для проверки
        double number = 0;
        while (true)
        {
            try
            {
                Console.WriteLine("Введите число для проверки:");
                number = double.Parse(Console.ReadLine());
                Console.WriteLine("");
                break; // Выход из цикла, если ввод корректен
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: некорректный ввод. Пожалуйста, введите числовое значение.");
                Console.WriteLine("");
            }
        }

        // Проверка, попадает ли число в отрезок
        if (segment < (int)number)
        {
            Console.WriteLine($"Число {number} попадает в отрезок.");
            Console.WriteLine("");
        }
        else
        {
            Console.WriteLine($"Число {number} не попадает в отрезок.");
            Console.WriteLine("");
        }

        // Проверка бинарной операции с увеличением координат на целое число
        // Ввод числа для увеличения координат отрезка
        int incrementValue = 0;
        while (true)
        {
            try
            {
                Console.WriteLine("Введите целое число для увеличения координат отрезка:");
                incrementValue = int.Parse(Console.ReadLine());
                Console.WriteLine("");
                break; // Выход из цикла, если ввод корректен
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: некорректный ввод. Пожалуйста, введите целое числовое значение.");
                Console.WriteLine("");
            }
        }

        // Проверка бинарной операции с увеличением координат на введенное число
        LineSegment incrementedSegment = segment + incrementValue;
        Console.WriteLine($"Отрезок после увеличения на {incrementValue}: {incrementedSegment}");
        Console.WriteLine("");

        // Проверка, попадает ли число в новый отрезок
        if (incrementedSegment < (int)number)
        {
            Console.WriteLine($"Число {number} попадает в увеличенный отрезок.");
        }
        else
        {
            Console.WriteLine($"Число {number} не попадает в увеличенный отрезок.");
        }
    }
}

