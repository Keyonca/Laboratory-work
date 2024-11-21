using System;
using System.Collections.Generic;



class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Вариант 5");
        Console.WriteLine("Выберите задание:");
        Console.WriteLine("1. Задание 1");
        Console.WriteLine("2. Задание 2");
        Console.WriteLine("3. Задание 3");
        Console.WriteLine("4. Задание 4");
        Console.WriteLine("5. Задание 5");
        Console.Write("Задание: ");
        int taskNumber = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("");

        switch (taskNumber)
        {
            case 1:
                try
                {
                    // Запрос списка у пользователя
                    Console.WriteLine("Введите числа через пробел:");
                    string input = Console.ReadLine();
                    List<int> numbers = new List<int>();
                    try
                    {
                        numbers = new List<int>(Array.ConvertAll(input.Split(' '), int.Parse));
                    }
                    catch
                    {
                        Console.WriteLine("Ошибка ввода: все элементы должны быть целыми числами.");
                        return;
                    }

                    Console.WriteLine("Ваш список:");
                    Operations.PrintList(numbers);

                    // Запрос числа для удаления
                    Console.Write("Введите число для удаления: ");
                    int valueToRemove;
                    while (!int.TryParse(Console.ReadLine(), out valueToRemove))
                    {
                        Console.WriteLine("Пожалуйста, введите корректное число для удаления:");
                    }

                    // Удаляем все элементы с указанным значением
                    Operations.RemoveAllOccurrences(numbers, valueToRemove);

                    Console.WriteLine("Список после удаления всех элементов:");
                    Operations.PrintList(numbers);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                break;

            case 2:
                try
                {
                    // Запрос списка у пользователя
                    Console.WriteLine("Введите элементы списка через пробел:");
                    string input = Console.ReadLine();
                    LinkedList<int> userList = new LinkedList<int>();
                    try
                    {
                        foreach (var number in Array.ConvertAll(input.Split(' '), int.Parse))
                        {
                            userList.AddLast(number);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Ошибка ввода: все элементы должны быть целыми числами.");
                        return;
                    }

                    // Печатаем введенный список
                    Console.WriteLine("Ваш список:");
                    Operations.PrintList(userList);

                    // Запрос элемента E для обработки
                    Console.Write("Введите элемент E: ");
                    int elementE;
                    while (!int.TryParse(Console.ReadLine(), out elementE))
                    {
                        Console.WriteLine("Пожалуйста, введите корректное число для элемента E:");
                    }

                    // Выполняем обработку списка
                    Operations.ReverseSublistBetweenFirstAndLastOccurrence(userList, elementE);

                    // Выводим список после обработки
                    Console.WriteLine("Список после обработки:");
                    Operations.PrintList(userList);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                break;

            case 3:
                // Все фильмы
                var allMovies = new HashSet<string> { "Фильм 1", "Фильм 2", "Фильм 3", "Фильм 4", "Фильм 5", "Фильм 6", "Фильм 7" };

                // Фильмы, которые посмотрели зрители
                var viewersMovies = new List<HashSet<string>>
                {
                    new HashSet<string> { "Фильм 1", "Фильм 2", "Фильм 3" }, // Зритель 1
                    new HashSet<string> { "Фильм 1", "Фильм 2" },            // Зритель 2
                    new HashSet<string> { "Фильм 1", "Фильм 7" },            // Зритель 3
                    new HashSet<string> { "Фильм 1", "Фильм 2", "Фильм 4" }, // Зритель 4
                    new HashSet<string> { "Фильм 1" }                        // Зритель 5
                };

                // Фильмы, которые посмотрели все зрители
                var watchedByAll = Operations.MoviesWatchedByAll(allMovies, viewersMovies);
                Console.WriteLine("Фильмы, просмотренные всеми зрителями:");
                Console.WriteLine(string.Join(", ", watchedByAll));

                // Фильмы, которые посмотрели хотя бы некоторые зрители
                var watchedBySome = Operations.MoviesWatchedBySome(viewersMovies);
                Console.WriteLine("Фильмы, просмотренные некоторыми зрителями:");
                Console.WriteLine(string.Join(", ", watchedBySome));

                // Фильмы, которые никто не смотрел
                var watchedByNoOne = Operations.MoviesWatchedByNoOne(allMovies, viewersMovies);
                Console.WriteLine("Фильмы, которые не посмотрел ни один зритель:");
                Console.WriteLine(string.Join(", ", watchedByNoOne));
                break;

            case 4:
                string filepath = "Task4.txt";
                Operations.ProcessText(filepath);
                break;

            case 5:
                Operations.Task5();
                break;

            default:
                Console.WriteLine("Неправильный выбор задания");
                break;

        }
    }
}

