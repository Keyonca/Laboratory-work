using System;
using System.Collections.Generic;
using System.Linq;

public class Meow
{

    // Метод для мяуканья N раз
    public void Meows(Cat cat, int count)
    {
        if (count < 1)
        {
            throw new ArgumentException("Количество мяуканий должно быть положительным.");
        }

        string meowSound = GetMeowSound(count);
        Console.WriteLine($"{cat.ToString()}: {meowSound}");
    }

    // Метод для формирования строки мяуканья
    private string GetMeowSound(int count)
    {
        string meow = "мяу";
        string[] meows = new string[count];

        for (int i = 0; i < count; i++)
        {
            meows[i] = meow;
        }

        return string.Join("-", meows) + "!";
    }

    public static void MakeThemMeow(InterfaceMeowable[] meowables, int[] counts)
    {
        for (int i = 0; i < meowables.Length; i++)
        {
            if (meowables[i] is Cat cat)
            {
                string meowSound = GetMeowSound1(counts[i]);
                Console.WriteLine($"{cat.ToString()}: {meowSound}");
            }
            else if (meowables[i] is Dog dog)
            {
                string barkSound = GetBarkSound1(counts[i]);
                Console.WriteLine($"{dog.ToString()}: {barkSound}");
            }
        }
    }

    // метод для получения звуков мяуканья
    private static string GetMeowSound1(int count)
    {
        return string.Join("-", Enumerable.Repeat("мяу", count)) + "!";
    }

    // метод для получения звуков гавканья
    private static string GetBarkSound1(int count)
    {
        return string.Join("-", Enumerable.Repeat("гав", count)) + "!";
    }

    // Метод для подсчета мяуканий
    public static void MeowsCare(Meow meowInstance, Cat[] cats, int[] counts)
    {
        for (int i = 0; i < cats.Length; i++)
        {
            string meowSound = meowInstance.GetMeowSound(counts[i]);
            Console.WriteLine($"{cats[i]}: {meowSound}");
            Console.WriteLine($"{cats[i]} мяукал {counts[i]} раз(а).");
        }
    }

    // Словарь для хранения котов и количества мяуканий
    private Dictionary<string, int> meowsCount = new Dictionary<string, int>();

    // Метод для добавления мяуканий в словарь
    public void AddMeows(string catName, int count)
    {
        if (meowsCount.ContainsKey(catName))
        {
            meowsCount[catName] += count; // Увеличиваем количество мяуканий
        }
        else
        {
            meowsCount[catName] = count; // Добавляем нового кота
        }
    }

    // Метод для вывода количества мяуканий
    public void DisplayMeows()
    {
        foreach (var entry in meowsCount)
        {
            Console.WriteLine($"{entry.Key} мяукал {entry.Value} раз(а).");
        }
    }

}
