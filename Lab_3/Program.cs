using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("Вариант 5");
        Console.WriteLine("Выберите задание:");
        Console.WriteLine("1. Задание 1-3");
        Console.WriteLine("2. Задание 4");
        Console.WriteLine("3. Задание 5");
        Console.WriteLine("4. Задание 6");
        Console.WriteLine("5. Задание 7");
        Console.WriteLine("6. Задание 8");
        Console.Write("Задание: ");
        int taskNumber = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("");

        switch (taskNumber)
        {
            case 1:

                int n, m;

                while (true)
                {
                    Console.Write("Введите количество строк n: ");
                    if (int.TryParse(Console.ReadLine(), out n) && n > 0) break;
                    Console.WriteLine("Ошибка ввода! Пожалуйста, введите положительное целое число.");
                }

                while (true)
                {
                    Console.Write("Введите количество столбцов m: ");
                    if (int.TryParse(Console.ReadLine(), out m) && m > 0)
                    {
                        if (m == n)
                            break;
                        else
                            Console.WriteLine("Ошибка: m должно быть равно n для квадратной матрицы.");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка ввода! Пожалуйста, введите положительное целое число.");
                    }
                }

                MatrixOperations matrixA = new MatrixOperations(n, m);
                MatrixOperations matrixB = new MatrixOperations(n);
                MatrixOperations matrixC = new MatrixOperations(n, true);

                Console.WriteLine("Матрица A (введенная пользователем):\n" + matrixA);
                Console.WriteLine("Матрица B (случайная):\n" + matrixB);
                Console.WriteLine("Матрица C (звездочка):\n" + matrixC);

                int maxSum = matrixB.MaxParallelDiagonalSum();
                Console.WriteLine("Максимальная сумма параллельной диагонали в Матрице B: " + maxSum);

                MatrixOperations result = matrixA.Transpose() * matrixB - matrixC.Transpose();
                Console.WriteLine("Результат выражения A^T * B - C^T:\n" + result);
                break;

            case 2:
                // Задание 4: Исключение повторных чисел в бинарном файле
                Console.WriteLine("Задание 4: Исключение повторных чисел в бинарном файле");
                string task4InputFile = "task4_input.bin";
                string task4OutputFile = "task4_output.bin";

                // Создаем файл с числами и выводим его содержимое
                FileTasks.Task4_CreateFileWithRandomNumbers(task4InputFile, 20);
                Console.WriteLine("Содержимое исходного файла:");
                FileTasks.PrintBinaryFileContent(task4InputFile);

                // Удаляем дублирующиеся значения и выводим содержимое обновленного файла
                FileTasks.Task4_RemoveDuplicates(task4InputFile, task4OutputFile);
                Console.WriteLine("Содержимое файла после удаления повторов:");
                FileTasks.PrintBinaryFileContent(task4OutputFile);
                break;

            case 3:
                // Задание 5: Фильтрация игрушек по цене и возрасту
                Console.WriteLine("Задание 5: Фильтрация игрушек по цене и возрасту");
                string task5File = "task5_toys.xml";

                // Создаем список игрушек
                var toys = new List<FileTasks.Toy>
                    {
                        new FileTasks.Toy { Name = "Плюшевый мишка", Price = 300, AgeFrom = 3, AgeTo = 6 },
                        new FileTasks.Toy { Name = "Машинка", Price = 100, AgeFrom = 2, AgeTo = 5 },
                        new FileTasks.Toy { Name = "Кукла", Price = 150, AgeFrom = 5, AgeTo = 7 },
                        new FileTasks.Toy { Name = "Пазл", Price = 80, AgeFrom = 4, AgeTo = 5 },
                        new FileTasks.Toy { Name = "Конструктор Лего", Price = 600, AgeFrom = 6, AgeTo = 12 },
                        new FileTasks.Toy { Name = "Игрушечный робот", Price = 750, AgeFrom = 5, AgeTo = 10 },
                        new FileTasks.Toy { Name = "Набор для рисования", Price = 200, AgeFrom = 4, AgeTo = 8 },
                        new FileTasks.Toy { Name = "Мягкий заяц", Price = 120, AgeFrom = 1, AgeTo = 3 },
                        new FileTasks.Toy { Name = "Игровой домик", Price = 500, AgeFrom = 3, AgeTo = 6 },
                        new FileTasks.Toy { Name = "Детский микрофон", Price = 250, AgeFrom = 4, AgeTo = 8 },
                        new FileTasks.Toy { Name = "Набор кубиков", Price = 90, AgeFrom = 1, AgeTo = 4 },
                        new FileTasks.Toy { Name = "Игровая кухня", Price = 1000, AgeFrom = 5, AgeTo = 10 },
                        new FileTasks.Toy { Name = "Железная дорога", Price = 850, AgeFrom = 3, AgeTo = 7 },
                        new FileTasks.Toy { Name = "Магнитный алфавит", Price = 150, AgeFrom = 3, AgeTo = 6 },
                        new FileTasks.Toy { Name = "Игрушечный телефон", Price = 50, AgeFrom = 1, AgeTo = 3 },
                        new FileTasks.Toy { Name = "Настольная игра \"Лото\"", Price = 200, AgeFrom = 5, AgeTo = 12 },
                        new FileTasks.Toy { Name = "Мягкая игрушка Лев", Price = 400, AgeFrom = 2, AgeTo = 6 },
                        new FileTasks.Toy { Name = "Электрическая железная дорога", Price = 950, AgeFrom = 6, AgeTo = 12 },
                        new FileTasks.Toy { Name = "Прыгающий мяч", Price = 70, AgeFrom = 3, AgeTo = 7 },
                        new FileTasks.Toy { Name = "Головоломка", Price = 120, AgeFrom = 7, AgeTo = 12 }
                    };

                // Создаем XML файл с игрушками
                FileTasks.Task5_CreateToyFile(task5File, toys);

                // Запрашиваем у пользователя максимальную цену с проверкой на корректность ввода
                decimal maxPrice = FileTasks.GetUserInputPrice();

                // Устанавливаем целевой возраст
                int targetAge = 5;
                var affordableToys = FileTasks.Task5_GetAffordableToysForAge(task5File, maxPrice, targetAge);

                Console.WriteLine($"\nИгрушки, доступные для детей 5 лет и стоимостью не более {maxPrice} руб:");
                affordableToys.ForEach(Console.WriteLine);
                break;

            case 4:
                // Задание 6: Проверка наличия числа в текстовом файле
                Console.WriteLine("Задание 6: Проверка наличия числа в текстовом файле");
                string task6File = "task6_numbers.txt";

                // Создаем текстовый файл с числами и выводим его содержимое
                FileTasks.Task6_CreateFileWithRandomNumbers(task6File, 20);
                FileTasks.Task6_PrintNumbersInFile(task6File);

                // Запрашиваем у пользователя число для поиска с проверкой ввода
                int searchNumber = FileTasks.GetUserInputNumber();

                // Проверка, содержится ли число в файле
                bool containsNumber = FileTasks.Task6_ContainsNumber(task6File, searchNumber);
                if (containsNumber)
                {
                    Console.WriteLine($"Число {searchNumber} присутствует в файле.");
                }
                else
                {
                    Console.WriteLine($"Число {searchNumber} отсутствует в файле.");
                }
                break;

            case 5:
                // Задание 7: Сумма чисел, кратных k
                Console.WriteLine("Задание 7: Сумма чисел, кратных k");
                string task7File = "task7_numbers.txt";

                // Создаем текстовый файл с числами и выводим его содержимое
                FileTasks.Task7_CreateFileWithRandomNumbers(task7File, 5, 10);
                Console.WriteLine("Содержимое файла:");
                FileTasks.PrintTextFileContent(task7File);

                // Запрашиваем у пользователя значение k с проверкой ввода
                int k = FileTasks.GetUserInputDivisor();

                // Находим сумму чисел, кратных k, и выводим результат
                int sumOfMultiples = FileTasks.Task7_SumOfMultiples(task7File, k);
                Console.WriteLine($"Сумма чисел, кратных {k}, в файле: {sumOfMultiples}");
                break;

            case 6:
                // Задание 8: Копирование строк без цифр в другой файл
                Console.WriteLine("\nЗадание 8: Копирование строк без цифр в другой файл");
                string task8InputFile = "task8_input.txt";
                string task8OutputFile = "task8_output.txt";
                using (var writer = new StreamWriter(task8InputFile))
                {
                    writer.WriteLine("This is a line without digits.");
                    writer.WriteLine("Another line with no digits.");
                    writer.WriteLine("This line has 3 numbers.");
                    writer.WriteLine("Hello world");
                    writer.WriteLine("Привет, как дела?");
                    writer.WriteLine("На улице 0 градусов");
                    writer.WriteLine("Телефон: 123-456-7890");
                    writer.WriteLine("Цена: 99 рублей");
                    writer.WriteLine("Сегодня пятница");
                    writer.WriteLine("ID12345");
                    writer.WriteLine("Просто текст без чисел");
                    writer.WriteLine("2024 год - новый вызов!");
                }
                FileTasks.Task8_CopyLinesWithoutDigits(task8InputFile, task8OutputFile);
                Console.WriteLine("Содержимое файла с строками без цифр:");
                FileTasks.PrintTextFileContent(task8OutputFile);
                break;


            default:
                Console.WriteLine("Неправильный выбор задания");
                break;
        }

    }
}

