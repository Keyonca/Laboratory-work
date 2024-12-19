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
        Console.Write("Задание: ");
        int taskNumber = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("");

        switch (taskNumber)
        {
            case 1:
                Console.WriteLine("Выберите задачу:");
                Console.WriteLine("1. Задача 1");
                Console.WriteLine("2. Задача 2");
                Console.WriteLine("3. Задача 3");
                Console.Write("Задача: ");
                int task = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");

                switch (task)
                {
                    case 1:
                        // Создаем кота по имени "Барсик"
                        Cat barsik = new Cat("Барсик");
                        Meow meow = new Meow();

                        // Кот мяукает один раз
                        meow.Meows(barsik, 1);

                        // Кот мяукает три раза
                        meow.Meows(barsik, 3);
                        break;
                    case 2:
                        // Ввод количества котов
                        Console.Write("Введите количество котов: ");
                        int catCount;
                        while (!int.TryParse(Console.ReadLine(), out catCount) || catCount < 1)
                        {
                            Console.Write("Пожалуйста, введите положительное число: ");
                        }

                        List<Cat> cats = new List<Cat>();
                        List<int> meowCounts = new List<int>();

                        for (int i = 0; i < catCount; i++)
                        {
                            Console.Write($"Введите имя кота {i + 1}: ");
                            string catName = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(catName))
                            {
                                Console.Write("Имя не может быть пустым. Введите имя кота: ");
                                catName = Console.ReadLine();
                            }
                            cats.Add(new Cat(catName));

                            // Ввод количества мяуканий для каждого кота
                            Console.Write($"Введите количество мяуканий для кота {catName}: ");
                            int meowCount;
                            while (!int.TryParse(Console.ReadLine(), out meowCount) || meowCount < 1)
                            {
                                Console.Write("Пожалуйста, введите положительное число: ");
                            }
                            meowCounts.Add(meowCount);
                        }

                        // Ввод количества собак
                        Console.Write("Введите количество собак: ");
                        int dogCount;
                        while (!int.TryParse(Console.ReadLine(), out dogCount) || dogCount < 1)
                        {
                            Console.Write("Пожалуйста, введите положительное число: ");
                        }

                        List<Dog> dogs = new List<Dog>();
                        List<int> barkCounts = new List<int>();

                        for (int i = 0; i < dogCount; i++)
                        {
                            Console.Write($"Введите имя собаки {i + 1}: ");
                            string dogName = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(dogName))
                            {
                                Console.Write("Имя не может быть пустым. Введите имя собаки: ");
                                dogName = Console.ReadLine();
                            }
                            dogs.Add(new Dog(dogName));

                            // Ввод количества гавканий для каждой собаки
                            Console.Write($"Введите количество гавканий для собаки {dogName}: ");
                            int barkCount;
                            while (!int.TryParse(Console.ReadLine(), out barkCount) || barkCount < 1)
                            {
                                Console.Write("Пожалуйста, введите положительное число: ");
                            }
                            barkCounts.Add(barkCount);
                        }

                        // Создаем массив InterfaceMeowable для всех котов и собак
                        InterfaceMeowable[] meowables = new InterfaceMeowable[cats.Count + dogs.Count];
                        int[] counts = new int[cats.Count + dogs.Count];

                        for (int i = 0; i < cats.Count; i++)
                        {
                            meowables[i] = cats[i];
                            counts[i] = meowCounts[i]; // Количество мяуканий
                        }
                        for (int i = 0; i < dogs.Count; i++)
                        {
                            meowables[cats.Count + i] = dogs[i];
                            counts[cats.Count + i] = barkCounts[i]; // Количество гавканий
                        }

                        // Используем метод MakeThemMeow
                        Meow.MakeThemMeow(meowables, counts);

                        break;
                    case 3:
                        Meow meowInstance1 = new Meow();

                        // Ввод количества котов
                        Console.Write("Введите количество котов: ");
                        int catCount1;
                        while (!int.TryParse(Console.ReadLine(), out catCount1) || catCount1 < 1)
                        {
                            Console.Write("Пожалуйста, введите положительное число: ");
                        }

                        List<Cat> catsForMeow = new List<Cat>();
                        List<int> meowCountsForMeow = new List<int>();

                        for (int i = 0; i < catCount1; i++)
                        {
                            Console.Write($"Введите имя кота {i + 1}: ");
                            string catName = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(catName))
                            {
                                Console.Write("Имя не может быть пустым. Введите имя кота: ");
                                catName = Console.ReadLine();
                            }

                            // Создаем кота и добавляем его в список
                            Cat cat = new Cat(catName);
                            catsForMeow.Add(cat);

                            // Ввод количества мяуканий для каждого кота
                            Console.Write($"Введите количество мяуканий для кота {catName}: ");
                            int meowCount;
                            while (!int.TryParse(Console.ReadLine(), out meowCount) || meowCount < 1)
                            {
                                Console.Write("Пожалуйста, введите положительное число: ");
                            }
                            meowCountsForMeow.Add(meowCount);

                            // Добавляем мяуканья в словарь
                            meowInstance1.AddMeows(catName, meowCount);
                        }

                        // Создаем массив InterfaceMeowable для всех котов
                        InterfaceMeowable[] meowablesForMeow = catsForMeow.ToArray();

                        // Используем метод MakeThemMeow, передавая массив counts
                        Meow.MakeThemMeow(meowablesForMeow, meowCountsForMeow.ToArray());

                        // Выводим мяуканья
                        meowInstance1.DisplayMeows();
                        break;


                    default:
                        Console.WriteLine("Неправильный выбор задачи");
                        break;
                }
                break;
            case 2:
                Console.WriteLine("Выберите задачу:");
                Console.WriteLine("1. Задача 1");
                Console.WriteLine("2. Задача 2");
                Console.WriteLine("3. Задача 3");
                Console.WriteLine("4. Задача 4");
                Console.Write("Задача: ");
                int task2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");

                switch (task2)
                {
                    case 1:
                        Fraction f1 = Fraction.GetFractionFromUser("Введите первую дробь (в формате числитель/знаменатель): ");
                        Fraction f2 = Fraction.GetFractionFromUser("Введите вторую дробь (в формате числитель/знаменатель): ");
                        Fraction f3 = Fraction.GetFractionFromUser("Введите третью дробь (в формате числитель/знаменатель): ");

                        // Примеры использования
                        Console.WriteLine(f1.ToString() + " + " + f2.ToString() + " = " + (f1 + f2).ToString());
                        Console.WriteLine(f1.ToString() + " - " + f2.ToString() + " = " + (f1 - f2).ToString());
                        Console.WriteLine(f1.ToString() + " * " + f2.ToString() + " = " + (f1 * f2).ToString());
                        Console.WriteLine(f1.ToString() + " / " + f2.ToString() + " = " + (f1 / f2).ToString());

                        // Примеры использования с целыми числами
                        Console.WriteLine(f1.ToString() + " + 2 = " + (f1 + 2).ToString());
                        Console.WriteLine(f1.ToString() + " - 1 = " + (f1 - 1).ToString());
                        Console.WriteLine(f1.ToString() + " * 3 = " + (f1 * 3).ToString());
                        Console.WriteLine(f1.ToString() + " / 2 = " + (f1 / 2).ToString());

                        // Пример сложной операции
                        var result = (f1 + f2) / f3 - 5;
                        Console.WriteLine($"({f1.ToString()} + {f2.ToString()}) / {f3.ToString()} - 5 = {result.ToString()}");

                        break;
                    case 2:
                        Fraction f4 = Fraction.GetFractionFromUser("Введите первую дробь (в формате числитель/знаменатель): ");
                        Fraction f5 = Fraction.GetFractionFromUser("Введите вторую дробь (в формате числитель/знаменатель): ");

                        if (f4.Equals(f5))
                        {
                            Console.WriteLine(f4.ToString() + " и " + f5.ToString() + " равны.");
                        }
                        else
                        {
                            Console.WriteLine(f4.ToString() + " и " + f5.ToString() + " не равны.");
                        }
                        break;
                    case 3:
                        Fraction fractionToClone = Fraction.GetFractionFromUser("Введите дробь для клонирования (в формате числитель/знаменатель): ");
                        Fraction clonedFraction = (Fraction)fractionToClone.Clone();

                        Console.WriteLine("Оригинальная дробь: " + fractionToClone.ToString());
                        Console.WriteLine("Клонированная дробь: " + clonedFraction.ToString());
                        break;
                    case 4:
                        Fraction fraction = Fraction.GetFractionFromUser("Введите дробь (в формате числитель/знаменатель): ");

                        Console.WriteLine($"Вещественное значение дроби {fraction.ToString()} = {fraction.GetValue()}");

                        
                        int newNumerator = Fraction.GetIntegerFromUser("Введите новый числитель: ");
                        fraction.SetNumerator(newNumerator);
                        Console.WriteLine($"Обновленное вещественное значение дроби {fraction.ToString()} = {fraction.GetValue()}");

                        Console.Write("Введите новый знаменатель: ");
                        int newDenominator;
                        while (true)
                        {
                            newDenominator = Fraction.GetIntegerFromUser("Введите новый знаменатель: ");
                            try
                            {
                                fraction.SetDenominator(newDenominator);
                                break; // Выход из цикла, если установка прошла успешно
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine($"Ошибка: {ex.Message}. Пожалуйста, попробуйте снова.");
                            }
                        }
                        Console.WriteLine($"Обновленное вещественное значение дроби {fraction.ToString()} = {fraction.GetValue()}");
                        break;

                    default:
                        Console.WriteLine("Неправильный выбор задачи");
                        break;
                }
                break;




        }
    }
}

