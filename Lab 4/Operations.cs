using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;


public class Operations
    {
        // Задание 1: List
        public static void RemoveAllOccurrences<T1>(List<T1> list, T1 value)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list), "Список не может быть null.");
            }

            // Проходим по списку в обратном порядке
            for (int i = list.Count - 1; i >= 0; i--)
            {
                // Сравниваем элементы и удаляем, если они равны
                if (object.Equals(list[i], value))
                {
                    list.RemoveAt(i); // Удаляем элемент по индексу
                }
            }
        }

        // Метод для печати списка
        public static void PrintList<T1>(List<T1> list)
        {
            if (list == null || list.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            Console.WriteLine(string.Join(", ", list));
        }

        
        // Задание 2: LinkedList
        // Основной метод, решающий поставленную задачу
        public static void ReverseSublistBetweenFirstAndLastOccurrence<T2>(LinkedList<T2> list, T2 element)
        {
            if (list == null || list.Count < 2)
            {
                Console.WriteLine("Список пустой или содержит меньше двух элементов.");
                return;
            }

            LinkedListNode<T2> firstOccurrence = FindFirstOccurrence(list, element);
            LinkedListNode<T2> lastOccurrence = FindLastOccurrence(list, element);

            if (firstOccurrence == null || lastOccurrence == null)
            {
                Console.WriteLine("Элемент отсутствует, либо встречается только один раз.");
                return;
            }

            // Выполнить обратное переставление
            ReverseSublist(firstOccurrence, lastOccurrence);
        }

        // Вспомогательный метод для поиска первого вхождения
        private static LinkedListNode<T2> FindFirstOccurrence<T2>(LinkedList<T2> list, T2 element)
        {
            var current = list.First;
            while (current != null)
            {
                if (object.Equals(current.Value, element))
                    return current;
                current = current.Next;
            }
            return null;
        }

        // Вспомогательный метод для поиска последнего вхождения
        private static LinkedListNode<T2> FindLastOccurrence<T2>(LinkedList<T2> list, T2 element)
        {
            var current = list.Last;
            while (current != null)
            {
                if (object.Equals(current.Value, element))
                    return current;
                current = current.Previous;
            }
            return null;
        }

        // Вспомогательный метод для обратного переставления элементов
        private static void ReverseSublist<T2>(LinkedListNode<T2> first, LinkedListNode<T2> last)
        {
            // Создаем массив для хранения элементов, которые нужно будет переставить
            var elements = new List<T2>();
            var current = first.Next;

            // Собираем элементы между first и last
            while (current != null && current != last)
            {
                elements.Add(current.Value);
                current = current.Next;
            }

            if (elements.Count == 0)
            {
                Console.WriteLine("Нет элементов для перестановки.");
                return;
            }

            // Обратный порядок
            elements.Reverse();

            // Заменяем старые значения на новые (в обратном порядке)
            current = first.Next;
            foreach (var item in elements)
            {
                current.Value = item;
                current = current.Next;
            }
        }

        // Метод для отображения содержимого списка
        public static void PrintList<T2>(LinkedList<T2> list)
        {
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
        
        // Задание 3: HashSet
        // Метод для определения фильмов, которые посмотрели все зрители
        public static HashSet<string> MoviesWatchedByAll(HashSet<string> allMovies, List<HashSet<string>> viewersMovies)
        {
            if (allMovies == null || allMovies.Count == 0)
                throw new ArgumentException("Список всех фильмов не может быть пустым.");

            if (viewersMovies == null || viewersMovies.Count == 0)
                throw new ArgumentException("Список просмотров зрителей не может быть пустым.");


            // Копируем список всех фильмов
            var commonMovies = new HashSet<string>(allMovies);

            // Для каждого зрителя пересекаем множество фильмов
            foreach (var viewerMovies in viewersMovies)
            {
                commonMovies.IntersectWith(viewerMovies);
            }

            return commonMovies;
        }

        // Метод для определения фильмов, которые посмотрели хотя бы некоторые зрители
        public static HashSet<string> MoviesWatchedBySome(List<HashSet<string>> viewersMovies)
        {
            if (viewersMovies == null || viewersMovies.Count == 0)
                throw new ArgumentException("Список просмотров зрителей не может быть пустым.");

            // Пустое множество для объединения
            var someMovies = new HashSet<string>();

            // Объединяем фильмы каждого зрителя
            foreach (var viewerMovies in viewersMovies)
            {
                someMovies.UnionWith(viewerMovies);
            }

            return someMovies;
        }

        // Метод для определения фильмов, которые никто не смотрел
        public static HashSet<string> MoviesWatchedByNoOne(HashSet<string> allMovies, List<HashSet<string>> viewersMovies)
        {

            if (allMovies == null || allMovies.Count == 0)
                throw new ArgumentException("Список всех фильмов не может быть пустым.");

            if (viewersMovies == null || viewersMovies.Count == 0)
                throw new ArgumentException("Список просмотров зрителей не может быть пустым.");

            // Находим фильмы, которые посмотрели хотя бы некоторые
            var watchedBySome = MoviesWatchedBySome(viewersMovies);

            // Копируем список всех фильмов и вычитаем те, которые кто-то смотрел
            var noOneMovies = new HashSet<string>(allMovies);
            noOneMovies.ExceptWith(watchedBySome);

            return noOneMovies;
        }

        // Задание 4: HashSet
        // Множество звонких согласных букв
        private static readonly HashSet<char> VoicedConsonants = new HashSet<char>
        {
            'б', 'в', 'г', 'д', 'ж', 'з', 'й', 'л', 'м', 'н', 'р'
        };

        // Главный метод для обработки текста
        public static void ProcessText(string filePath)
        {
            try
            {
                // Проверяем, существует ли файл
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Ошибка: Файл не найден!");
                    return;
                }
            
                // Считываем текст из файла
                string text = File.ReadAllText(filePath);
            
                if (string.IsNullOrWhiteSpace(text))
                {
                    Console.WriteLine("Ошибка: Файл пуст!");
                    return;
                }
            
                // Разделяем текст на слова
                string[] words = SplitIntoWords(text);
            
                if (words.Length == 0)
                {
                    Console.WriteLine("Ошибка: Текст не содержит слов!");
                    return;
                }
            
                // Храним множества звонких согласных, которые встречаются более чем в одном слове
                HashSet<char> occurringMoreThanOnce = new HashSet<char>();
                HashSet<char> checkedLetters = new HashSet<char>();
            
                foreach (string word in words)
                {
                    // Сохраняем уникальные буквы из текущего слова
                    HashSet<char> uniqueLettersInWord = new HashSet<char>(word);
            
                    foreach (char letter in uniqueLettersInWord)
                    {
                        if (VoicedConsonants.Contains(letter))
                        {
                            // Если буква уже проверялась ранее, добавляем её в множество для вывода
                            if (!checkedLetters.Add(letter))
                            {
                                occurringMoreThanOnce.Add(letter);
                            }
                        }
                    }
                }
            
                // Сортируем результат
                List<char> sortedResult = new List<char>(occurringMoreThanOnce);
                sortedResult.Sort();
            
                // Печатаем результат
                if (sortedResult.Count > 0)
                {
                    Console.WriteLine("Звонкие согласные, которые входят более чем в одно слово:");
                    Console.WriteLine(string.Join(" ", sortedResult));
                }
                else
                {
                    Console.WriteLine("Нет звонких согласных, которые входят более чем в одно слово.");
                }
            }
            catch (Exception ex)
            {
                // Обрабатываем любые ошибки
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        

        // Метод для разделения текста на слова
        private static string[] SplitIntoWords(string text)
            {
                // Убираем все лишние символы, оставляем только буквы и пробелы
                char[] delimiters = { ' ', ',', '.', '!', '?', ';', ':', '-', '\n', '\r', '(', ')', '[', ']', '{', '}' };
                return text.ToLower().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                //// Разбиваем текст на части
                //string[] words = text.ToLower().Split(delimiters);

                //// Убираем пустые строки
                //List<string> filteredWords = new List<string>();
                //foreach (string word in words)
                //{
                //    if (!string.IsNullOrWhiteSpace(word)) // Проверяем, что строка не пустая и не состоит из пробелов
                //    {
                //        filteredWords.Add(word);
                //    }
                //}

                //// Преобразуем список обратно в массив
                //return filteredWords.ToArray();
        }


        // Метод для выполнения задания 5
        public static void Task5()
        {
            try
            {
                // Заполняем исходный файл данными
                string inputFilePath = "employees.xml";

                // Обрабатываем ошибки при создании файла и записи данных
                try
                {
                    FillData(inputFilePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при записи данных в файл. {ex.Message}");
                    return;
                }

                List<Employee> employees = new List<Employee>();
                try
                {
                    employees = LoadData(inputFilePath);
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine($"Ошибка: Файл не найден. {ex.Message}");
                    return;
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Ошибка: Некорректный формат данных в файле. {ex.Message}");
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при загрузке данных из файла. {ex.Message}");
                    return;
                }

                // Проверяем, что данные были загружены
                if (employees.Count == 0)
                {
                    Console.WriteLine("Ошибка: Список сотрудников пуст.");
                    return;
                }

                // Выводим список всех сотрудников
                PrintEmployees(employees);

                // Обрабатываем данные: группируем сотрудников по подразделениям (по телефону)
                Dictionary<string, List<Employee>> departments;
                try
                {
                    departments = GroupByDepartment(employees);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при группировке сотрудников. {ex.Message}");
                    return;
                }

                // Считаем среднее количество сотрудников в одном подразделении
                double averageEmployeesPerDepartment;
                try
                {
                    averageEmployeesPerDepartment = CalculateAverage(departments);
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Ошибка: Деление на ноль (нет подразделений). {ex.Message}");
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Неизвестная ошибка при вычислении среднего числа. {ex.Message}");
                    return;
                }

                // Округляем до целого числа
                int roundedAverage = (int)Math.Round(averageEmployeesPerDepartment);

                // Вывод результата без нулей после запятой
                Console.WriteLine($"В среднем в одном подразделении работает {roundedAverage} сотрудников.");
            }
            catch (Exception ex)
            {
                // Обработка всех неожиданных ошибок
                Console.WriteLine($"Произошла непредвиденная ошибка: {ex.Message}");
            }

        }

        // Метод для заполнения исходного файла данными с использованием XML-сериализации
        private static void FillData(string filePath)
        {
            var employees = new List<Employee>
            {
                new Employee("Иванов", "П.С.", "555-66-77"),
                new Employee("Петров", "И.И.", "555-66-78"),
                new Employee("Сидоров", "А.А.", "555-66-82"),
                new Employee("Кузнецов", "В.В.", "555-66-81"),
                new Employee("Смирнов", "О.О.", "555-66-79"),
                new Employee("Васильев", "Д.М.", "555-66-80"),
                new Employee("Ковалёв", "Е.Е.", "555-67-77"),
                new Employee("Новиков", "Ю.А.", "555-67-78"),
                new Employee("Горшков", "Н.Н.", "555-67-79"),
                new Employee("Лебедев", "М.С.", "555-68-77"),
                new Employee("Орлов", "П.В.", "555-68-78"),
                new Employee("Фёдоров", "В.А.", "555-68-79"),
                new Employee("Тарасов", "Г.Р.", "555-68-81")
                
            };

            XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fs, employees);
            }
        }

        // Метод для загрузки данных из файла с использованием XML-десериализации
        private static List<Employee> LoadData(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                return (List<Employee>)serializer.Deserialize(fs);
            }
        }

        // Метод для группировки сотрудников по номеру телефона (по подразделениям)
        private static Dictionary<string, List<Employee>> GroupByDepartment(List<Employee> employees)
        {
            var departments = new Dictionary<string, List<Employee>>();

            foreach (var employee in employees)
            {
                // Разделяем номер телефона по дефису
                string[] phoneParts = employee.Phone.Split('-');

                // Соединяем первые две части номера телефона для определения подразделения
                string departmentPhone = phoneParts[0] + "-" + phoneParts[1];

                // Проверяем, есть ли уже такое подразделение
                if (!departments.ContainsKey(departmentPhone))
                {
                    departments[departmentPhone] = new List<Employee>();
                }

                // Добавляем сотрудника в список соответствующего подразделения
                departments[departmentPhone].Add(employee);
            }

            return departments;
        }

        // Метод для расчета среднего количества сотрудников в подразделении
        private static double CalculateAverage(Dictionary<string, List<Employee>> departments)
            {
                int totalEmployees = 0;
                int totalDepartments = departments.Count;

                foreach (var department in departments)
                {
                    totalEmployees += department.Value.Count;
                }

                if (totalDepartments > 0)
                {
                    // Если есть подразделения, возвращаем среднее количество сотрудников
                    return (double)totalEmployees / totalDepartments;
                }
                else
                {
                    // Если подразделений нет, возвращаем 0
                    return 0;
                }
            }

        // Класс для представления сотрудника
        public class Employee
            {
                public string LastName { get; set; }
                public string Initials { get; set; }
                public string Phone { get; set; }

                // Пустой конструктор для сериализации
                public Employee() { }

                public Employee(string lastName, string initials, string phone)
                {
                    this.LastName = lastName;
                    this.Initials = initials;
                    this.Phone = phone;
                }
            }

        // Метод для вывода списка сотрудников
        private static void PrintEmployees(List<Employee> employees)
        {
            Console.WriteLine("Список всех сотрудников:\n");

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.LastName} {employee.Initials} {employee.Phone}");
            }
        }

}

