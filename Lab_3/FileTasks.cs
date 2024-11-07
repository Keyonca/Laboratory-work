using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Collections.Generic;

public static class FileTasks
{
    // Задание 4: Исключение повторных чисел в бинарном файле
    public static void Task4_CreateFileWithRandomNumbers(string filePath, int count)
    {
        var random = new Random();
        using (var writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
        {
            for (int i = 0; i < count; i++)
            {
                writer.Write(random.Next(1, 100)); // записываем случайное число
            }
        }
    }

    public static void Task4_RemoveDuplicates(string inputFile, string outputFile)
    {
        HashSet<int> uniqueNumbers = new HashSet<int>();
        using (var reader = new BinaryReader(File.Open(inputFile, FileMode.Open)))
        using (var writer = new BinaryWriter(File.Open(outputFile, FileMode.Create)))
        {
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                int number = reader.ReadInt32();
                if (uniqueNumbers.Add(number))
                {
                    writer.Write(number);
                }
            }
        }
    }

    // Задание 5: Фильтрация игрушек по цене и возрасту
    [Serializable]
    public struct Toy
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int AgeFrom { get; set; }
        public int AgeTo { get; set; }
    }

    // Метод для создания XML файла с данными об игрушках
    public static void Task5_CreateToyFile(string filePath, List<Toy> toys)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Toy>));
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            serializer.Serialize(fs, toys);
        }
    }

    // Метод для получения списка игрушек, подходящих детям 5 лет и не дороже заданной цены
    public static List<string> Task5_GetAffordableToysForAge(string filePath, decimal maxPrice, int age)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Toy>));
        List<Toy> toys;

        using (FileStream fs = new FileStream(filePath, FileMode.Open))
        {
            toys = (List<Toy>)serializer.Deserialize(fs);
        }

        // Фильтруем игрушки, цена которых не превышает maxPrice и возраст от age до age
        var suitableToys = toys
            .Where(t => t.Price <= maxPrice && t.AgeFrom <= age && t.AgeTo >= age)
            .Select(t => t.Name)
            .ToList();

        return suitableToys;
    }

    // Задание 6: Проверка наличия числа в текстовом файле
    public static void Task6_CreateFileWithRandomNumbers(string filePath, int count)
    {
        var random = new Random();
        using (var writer = new StreamWriter(filePath))
        {
            for (int i = 0; i < count; i++)
            {
                writer.WriteLine(random.Next(1, 100));
            }
        }
    }

    public static bool Task6_ContainsNumber(string filePath, int number)
    {
        foreach (var line in File.ReadLines(filePath))
        {
            if (int.TryParse(line, out int num) && num == number)
            {
                return true;
            }
        }
        return false;
    }

    // Задание 7: Сумма чисел, кратных k
    public static void Task7_CreateFileWithRandomNumbers(string filePath, int lines, int numbersPerLine)
    {
        var random = new Random();
        using (var writer = new StreamWriter(filePath))
        {
            for (int i = 0; i < lines; i++)
            {
                var numbers = Enumerable.Range(0, numbersPerLine).Select(_ => random.Next(1, 100));
                writer.WriteLine(string.Join(" ", numbers));
            }
        }
    }

    public static int Task7_SumOfMultiples(string filePath, int k)
    {
        int sum = 0;
        foreach (var line in File.ReadLines(filePath))
        {
            var numbers = line.Split(' ').Select(n => int.Parse(n));
            sum += numbers.Where(n => n % k == 0).Sum();
        }
        return sum;
    }

    // Задание 8: Копирование строк без цифр в другой файл
    public static void Task8_CopyLinesWithoutDigits(string inputFile, string outputFile)
    {
        using (var reader = new StreamReader(inputFile))
        using (var writer = new StreamWriter(outputFile))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (!line.Any(char.IsDigit))
                {
                    writer.WriteLine(line);
                }
            }
        }
    }

    public static void PrintBinaryFileContent(string filePath)
    {
        using (var reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
        {
            Console.WriteLine("Содержимое бинарного файла:");
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                int number = reader.ReadInt32();
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
    }

    public static void PrintTextFileContent(string filePath)
    {
        foreach (var line in File.ReadAllLines(filePath))
        {
            Console.WriteLine(line);
        }
    }

    // Метод для запроса и проверки корректного ввода цены от пользователя
    public static decimal GetUserInputPrice()
    {
        decimal maxPrice;
        while (true)
        {
            Console.Write("Введите максимальную цену игрушки: ");
            string input = Console.ReadLine();

            if (decimal.TryParse(input, out maxPrice) && maxPrice >= 0)
            {
                break; // Корректное значение введено
            }
            else
            {
                Console.WriteLine("Ошибка: Введите положительное число. Попробуйте снова.");
            }
        }
        return maxPrice;
    }

    // Метод для запроса и проверки корректного ввода числа от пользователя
    public static int GetUserInputNumber()
    {
        int number;
        while (true)
        {
            Console.Write("Введите число для поиска в файле: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out number))
            {
                break; // Корректное значение введено
            }
            else
            {
                Console.WriteLine("Ошибка: Введите корректное целое число. Попробуйте снова.");
            }
        }
        return number;
    }

    // Метод для вывода содержимого текстового файла с числами
    public static void Task6_PrintNumbersInFile(string filePath)
    {
        var numbers = File.ReadAllLines(filePath);
        Console.WriteLine("Содержимое файла:");
        Console.WriteLine(string.Join(" ", numbers)); // Вывод чисел в строку, разделённых пробелами
    }

    public static int GetUserInputDivisor()
    {
        int divisor;
        while (true)
        {
            Console.Write("Введите число k для поиска суммы кратных ему чисел в файле: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out divisor) && divisor > 0)
            {
                break; // Корректное значение введено
            }
            else
            {
                Console.WriteLine("Ошибка: Введите корректное целое число, отличное от нуля. Попробуйте снова.");
            }
        }
        return divisor;
    }
}
