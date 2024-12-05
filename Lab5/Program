using System.Linq;
using System;


class Program
{
    public static void Main(string[] args)
    {
        const string logFileName = "log.txt"; // Имя файла по умолчанию
        Console.WriteLine($"Логи будут записываться в файл '{logFileName}'.");

        bool createNewFile = false;
        while (true)
        {
            Console.Write("Создать новый файл логов? (y/n): ");
            string input = Console.ReadLine()?.Trim().ToLower();

            if (input == "y")
            {
                createNewFile = true;
                break;
            }
            else if (input == "n")
            {
                createNewFile = false;
                break;
            }
            else
            {
                Console.WriteLine("Ошибка: введите 'y' для Да или 'n' для Нет.");
            }
        }

        // Инициализация логгера
        Logger.InitializeLogger(logFileName, !createNewFile);
        Logger.Log("Программа запущена");

        var filePath = "LR5-var5.xls";
        var countries = Database.ReadCountries(filePath);
        var clubs = Database.ReadClubs(filePath);
        var achievements = Database.ReadAchievements(filePath);

        while (true)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1. Просмотр базы данных");
            Console.WriteLine("2. Удаление элемента");
            Console.WriteLine("3. Корректировка элемента");
            Console.WriteLine("4. Добавление элемента");
            Console.WriteLine("5. Выполнить запросы");
            Console.WriteLine("6. Выйти");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Logger.Log("Выбран просмотр базы данных");

                    Console.WriteLine("\nВыберите категорию для просмотра:");
                    Console.WriteLine("1. Страны");
                    Console.WriteLine("2. Клубы");
                    Console.WriteLine("3. Достижения");
                    Console.WriteLine("4. Всё");

                    string viewChoice = Console.ReadLine();

                    switch (viewChoice)
                    {
                        case "1":
                            Logger.Log("Просмотр списка стран");
                            Console.WriteLine("Страны:");
                            countries.ForEach(Console.WriteLine);
                            break;

                        case "2":
                            Logger.Log("Просмотр списка клубов");
                            Console.WriteLine("Клубы:");
                            clubs.ForEach(Console.WriteLine);
                            break;

                        case "3":
                            Logger.Log("Просмотр списка достижений");
                            Console.WriteLine("Достижения:");
                            achievements.ForEach(Console.WriteLine);
                            break;

                        case "4":
                            Logger.Log("Просмотр всей базы данных");
                            Console.WriteLine("Страны:");
                            countries.ForEach(Console.WriteLine);
                            Console.WriteLine("\nКлубы:");
                            clubs.ForEach(Console.WriteLine);
                            Console.WriteLine("\nДостижения:");
                            achievements.ForEach(Console.WriteLine);
                            break;

                        default:
                            Logger.Log("Ошибка ввода при выборе категории для просмотра");
                            Console.WriteLine("Ошибка: введите число от 1 до 4.");
                            break;
                    }
                    break;


                case "2": // Удалить запись
                    Console.WriteLine("Выберите таблицу для удаления:");
                    Console.WriteLine("1. Страны");
                    Console.WriteLine("2. Клубы");
                    Console.WriteLine("3. Достижения");
                    var tableChoice = Console.ReadLine();
                    bool validChoice = false;

                    // Цикл для проверки корректного ввода
                    while (!validChoice)
                    {
                        tableChoice = Console.ReadLine();

                        // Проверка, что введен номер от 1 до 3
                        if (tableChoice == "1" || tableChoice == "2" || tableChoice == "3")
                        {
                            validChoice = true; // Ввод корректен, выходим из цикла
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: введите корректный номер таблицы (1, 2 или 3).");
                        }
                    }

                    Console.Write("Введите ID записи для удаления: ");
                    if (int.TryParse(Console.ReadLine(), out int idToDelete))
                    {
                        switch (tableChoice)
                        {
                            case "1": // Удаление страны
                                Operations.DeleteCountry(countries, idToDelete); // Используем метод для удаления страны
                                // Удаление из Excel
                                Operations.DeleteRowFromExcel("LR5-var5.xls", "Страны", idToDelete, 0);
                                break;

                            case "2": // Удаление клуба
                                Operations.DeleteClub(clubs, achievements, idToDelete); // Используем метод для удаления клуба
                                // Удаление из Excel
                                Operations.DeleteRowFromExcel("LR5-var5.xls", "Клубы", idToDelete, 0);
                                Operations.DeleteRowFromExcel("LR5-var5.xls", "Достижения", idToDelete, 0);
                                break;

                            case "3": // Удаление достижений
                                Operations.DeleteAchievement(achievements, idToDelete); // Используем метод для удаления достижений
                                // Удаление из Excel
                                Operations.DeleteRowFromExcel("LR5-var5.xls", "Достижения", idToDelete, 0);
                                break;

                            default:
                                Console.WriteLine("Неверный выбор таблицы.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: введите корректный ID.");
                    }
                    break;


                case "3": // Корректировка элемента
                    Console.WriteLine("Выберите таблицу для корректировки:");
                    Console.WriteLine("1. Страны");
                    Console.WriteLine("2. Клубы");
                    Console.WriteLine("3. Достижения");
                    var updateChoice = Console.ReadLine();

                    switch (updateChoice)
                    {
                        case "1": // Корректировка страны
                            Console.Write("Введите ID страны для корректировки: ");
                            if (int.TryParse(Console.ReadLine(), out int countryIdToUpdate))
                            {
                                var countryToUpdate = countries.FirstOrDefault(c => c.CountryId == countryIdToUpdate);
                                if (countryToUpdate != null)
                                {
                                    Console.Write("Введите новое название страны: ");
                                    var newCountryName = Console.ReadLine();
                                    Operations.UpdateCountry(countries, countryIdToUpdate, newCountryName); // Вызов метода
                                    Operations.UpdateRowInExcel("LR5-var5.xls", "Страны", countryIdToUpdate, newCountryName);
                                }
                                else
                                {
                                    Console.WriteLine("Страна с таким ID не найдена.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ошибка: введите корректный ID.");
                            }
                            break;

                        case "2": // Корректировка клуба
                            Console.Write("Введите ID клуба для корректировки: ");
                            if (int.TryParse(Console.ReadLine(), out int clubIdToUpdate))
                            {
                                var clubToUpdate = clubs.FirstOrDefault(c => c.ClubId == clubIdToUpdate);
                                if (clubToUpdate != null)
                                {
                                    Console.Write("Введите новое название клуба: ");
                                    var newClubName = Console.ReadLine();
                                    Console.Write("Введите новый ID страны для клуба: ");
                                    if (int.TryParse(Console.ReadLine(), out int newCountryId))
                                    {
                                        Operations.UpdateClub(clubs, clubIdToUpdate, newClubName, newCountryId); // Вызов метода
                                        Operations.UpdateRowInExcel("LR5-var5.xls", "Клубы", clubIdToUpdate, newClubName, newCountryId);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ошибка: введите корректный ID страны.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Клуб с таким ID не найден.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ошибка: введите корректный ID.");
                            }
                            break;

                        case "3": // Корректировка достижений
                            Console.Write("Введите ID клуба для корректировки достижений: ");
                            if (int.TryParse(Console.ReadLine(), out int achievementClubIdToUpdate))
                            {
                                var achievementToUpdate = achievements.FirstOrDefault(a => a.ClubId == achievementClubIdToUpdate);
                                if (achievementToUpdate != null)
                                {
                                    // Считывание новых достижений
                                    Console.Write("Введите количество золотых медалей: ");
                                    var newGoldMedals = int.Parse(Console.ReadLine());
                                    Console.Write("Введите количество серебряных медалей: ");
                                    var newSilverMedals = int.Parse(Console.ReadLine());
                                    Console.Write("Введите количество бронзовых медалей: ");
                                    var newBronzeMedals = int.Parse(Console.ReadLine());
                                    Console.Write("Введите количество побед в национальном кубке: ");
                                    var newNationalCupWins = int.Parse(Console.ReadLine());
                                    Console.Write("Введите количество финалов национального кубка: ");
                                    var newNationalCupFinals = int.Parse(Console.ReadLine());
                                    Console.Write("Введите количество побед в Лиге чемпионов: ");
                                    var newChampionsLeagueWins = int.Parse(Console.ReadLine());
                                    Console.Write("Введите количество финалов Лиги чемпионов: ");
                                    var newChampionsLeagueFinals = int.Parse(Console.ReadLine());
                                    Console.Write("Введите количество побед в Лиге Европы: ");
                                    var newEuropaLeagueWins = int.Parse(Console.ReadLine());
                                    Console.Write("Введите количество финалов Лиги Европы: ");
                                    var newEuropaLeagueFinals = int.Parse(Console.ReadLine());
                                    Console.Write("Введите количество побед в Кубке обладателей кубков: ");
                                    var newCupWinnersCupWins = int.Parse(Console.ReadLine());
                                    Console.Write("Введите количество финалов Кубка обладателей кубков: ");
                                    var newCupWinnersCupFinals = int.Parse(Console.ReadLine());
                                    Console.Write("Введите количество побед в Лиге конференций: ");
                                    var newConferenceLeagueWins = int.Parse(Console.ReadLine());
                                    Console.Write("Введите количество финалов Лиги конференций: ");
                                    var newConferenceLeagueFinals = int.Parse(Console.ReadLine());

                                    // Вызов метода обновления достижений
                                    Operations.UpdateAchievement(achievements, achievementClubIdToUpdate, newGoldMedals, newSilverMedals, newBronzeMedals,
                                        newNationalCupWins, newNationalCupFinals, newChampionsLeagueWins, newChampionsLeagueFinals,
                                        newEuropaLeagueWins, newEuropaLeagueFinals, newCupWinnersCupWins, newCupWinnersCupFinals,
                                        newConferenceLeagueWins, newConferenceLeagueFinals);

                                    Operations.UpdateRowInExcel("LR5-var5.xls", "Достижения", achievementClubIdToUpdate,
                                        newGoldMedals, newSilverMedals, newBronzeMedals, newNationalCupWins, newNationalCupFinals,
                                        newChampionsLeagueWins, newChampionsLeagueFinals, newEuropaLeagueWins, newEuropaLeagueFinals,
                                        newCupWinnersCupWins, newCupWinnersCupFinals, newConferenceLeagueWins, newConferenceLeagueFinals);
                                }
                                else
                                {
                                    Console.WriteLine("Достижения клуба с таким ID не найдены.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ошибка: введите корректный ID.");
                            }
                            break;

                        default:
                            Console.WriteLine("Ошибка: выберите правильный вариант.");
                            break;
                    }
                    break;


                case "4": // Добавить запись
                    Console.WriteLine("Выберите таблицу для добавления:");
                    Console.WriteLine("1. Страны");
                    Console.WriteLine("2. Клубы");
                    Console.WriteLine("3. Достижения");
                    var addChoice = Console.ReadLine();

                    switch (addChoice)
                    {
                        case "1": // Добавление страны
                            Console.Write("Введите ID страны: ");
                            if (int.TryParse(Console.ReadLine(), out int newCountryId))
                            {
                                Console.Write("Введите название страны: ");
                                var countryName = Console.ReadLine();
                                // Используем метод AddCountry
                                Operations.AddCountry(countries, newCountryId, countryName);

                                // Добавление в Excel
                                Operations.AddRowToExcel("LR5-var5.xls", "Страны", newCountryId, countryName);
                            }
                            break;

                        case "2": // Добавление клуба
                            Console.Write("Введите ID клуба: ");
                            if (int.TryParse(Console.ReadLine(), out int newClubId))
                            {
                                Console.Write("Введите название клуба: ");
                                var clubName = Console.ReadLine();
                                Console.Write("Введите ID страны: ");
                                if (int.TryParse(Console.ReadLine(), out int clubCountryId))
                                {
                                    // Используем метод AddClub
                                    Operations.AddClub(clubs, newClubId, clubName, clubCountryId);

                                    // Добавление в Excel
                                    Operations.AddRowToExcel("LR5-var5.xls", "Клубы", newClubId, clubName, clubCountryId);
                                }
                            }
                            break;

                        case "3": // Добавление достижений
                            try
                            {
                                Console.Write("Введите ID клуба: ");
                                if (int.TryParse(Console.ReadLine(), out int achievementClubId))
                                {
                                    Console.Write("Введите количество золотых медалей: ");
                                    if (int.TryParse(Console.ReadLine(), out int goldMedals))
                                    {
                                        Console.Write("Введите количество серебряных медалей: ");
                                        if (int.TryParse(Console.ReadLine(), out int silverMedals))
                                        {
                                            Console.Write("Введите количество бронзовых медалей: ");
                                            if (int.TryParse(Console.ReadLine(), out int bronzeMedals))
                                            {
                                                Console.Write("Введите количество выигранных национальных кубков: ");
                                                if (int.TryParse(Console.ReadLine(), out int nationalCupWins))
                                                {
                                                    Console.Write("Введите количество проигранных финалов национальных кубков: ");
                                                    if (int.TryParse(Console.ReadLine(), out int nationalCupFinals))
                                                    {
                                                        Console.Write("Введите количество выигранных Лиг Чемпионов: ");
                                                        if (int.TryParse(Console.ReadLine(), out int championsLeagueWins))
                                                        {
                                                            Console.Write("Введите количество проигранных финалов Лиги Чемпионов: ");
                                                            if (int.TryParse(Console.ReadLine(), out int championsLeagueFinals))
                                                            {
                                                                Console.Write("Введите количество выигранных Лиг Европы: ");
                                                                if (int.TryParse(Console.ReadLine(), out int europaLeagueWins))
                                                                {
                                                                    Console.Write("Введите количество проигранных финалов Лиги Европы: ");
                                                                    if (int.TryParse(Console.ReadLine(), out int europaLeagueFinals))
                                                                    {
                                                                        Console.Write("Введите количество выигранных Кубков обладателей кубков: ");
                                                                        if (int.TryParse(Console.ReadLine(), out int cupWinnersCupWins))
                                                                        {
                                                                            Console.Write("Введите количество проигранных финалов Кубка обладателей кубков: ");
                                                                            if (int.TryParse(Console.ReadLine(), out int cupWinnersCupFinals))
                                                                            {
                                                                                Console.Write("Введите количество выигранных Лиг Конференций: ");
                                                                                if (int.TryParse(Console.ReadLine(), out int conferenceLeagueWins))
                                                                                {
                                                                                    Console.Write("Введите количество проигранных финалов Лиги Конференций: ");
                                                                                    if (int.TryParse(Console.ReadLine(), out int conferenceLeagueFinals))
                                                                                    {
                                                                                        // Создаем объект достижения с полным набором данных
                                                                                        var newAchievement = new Achievement
                                                                                        {
                                                                                            ClubId = achievementClubId,
                                                                                            GoldMedals = goldMedals,
                                                                                            SilverMedals = silverMedals,
                                                                                            BronzeMedals = bronzeMedals,
                                                                                            NationalCupWins = nationalCupWins,
                                                                                            NationalCupFinals = nationalCupFinals,
                                                                                            ChampionsLeagueWins = championsLeagueWins,
                                                                                            ChampionsLeagueFinals = championsLeagueFinals,
                                                                                            EuropaLeagueWins = europaLeagueWins,
                                                                                            EuropaLeagueFinals = europaLeagueFinals,
                                                                                            CupWinnersCupWins = cupWinnersCupWins,
                                                                                            CupWinnersCupFinals = cupWinnersCupFinals,
                                                                                            ConferenceLeagueWins = conferenceLeagueWins,
                                                                                            ConferenceLeagueFinals = conferenceLeagueFinals
                                                                                        };

                                                                                        // Используем метод AddAchievement
                                                                                        Operations.AddAchievement(achievements, newAchievement);

                                                                                        // Добавление в Excel
                                                                                        Operations.AddRowToExcel("LR5-var5.xls", "Достижения", achievementClubId,
                                                                                            goldMedals, silverMedals, bronzeMedals, nationalCupWins,
                                                                                            nationalCupFinals, championsLeagueWins, championsLeagueFinals,
                                                                                            europaLeagueWins, europaLeagueFinals, cupWinnersCupWins,
                                                                                            cupWinnersCupFinals, conferenceLeagueWins, conferenceLeagueFinals);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        throw new FormatException("Неверный формат данных для проигранных финалов Лиги Конференций.");
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    throw new FormatException("Неверный формат данных для выигранных Лиг Конференций.");
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                throw new FormatException("Неверный формат данных для проигранных финалов Кубка обладателей кубков.");
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            throw new FormatException("Неверный формат данных для выигранных Кубков обладателей кубков.");
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        throw new FormatException("Неверный формат данных для проигранных финалов Лиги Европы.");
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    throw new FormatException("Неверный формат данных для выигранных Лиг Европы.");
                                                                }
                                                            }
                                                            else
                                                            {
                                                                throw new FormatException("Неверный формат данных для проигранных финалов Лиги Чемпионов.");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            throw new FormatException("Неверный формат данных для выигранных Лиг Чемпионов.");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        throw new FormatException("Неверный формат данных для проигранных финалов национальных кубков.");
                                                    }
                                                }
                                                else
                                                {
                                                    throw new FormatException("Неверный формат данных для выигранных национальных кубков.");
                                                }
                                            }
                                            else
                                            {
                                                throw new FormatException("Неверный формат данных для бронзовых медалей.");
                                            }
                                        }
                                        else
                                        {
                                            throw new FormatException("Неверный формат данных для серебряных медалей.");
                                        }
                                    }
                                    else
                                    {
                                        throw new FormatException("Неверный формат данных для золотых медалей.");
                                    }
                                }
                                else
                                {
                                    throw new FormatException("Неверный формат данных для ID клуба.");
                                }
                            }
                            catch (FormatException ex)
                            {
                                // Обработка ошибок формата ввода
                                Console.WriteLine($"Ошибка: {ex.Message}");
                                Logger.Log($"Ошибка: {ex.Message}");
                            }
                            catch (Exception ex)
                            {
                                // Обработка других исключений
                                Console.WriteLine($"Произошла ошибка: {ex.Message}");
                                Logger.Log($"Произошла ошибка: {ex.Message}");
                            }
                            break;



                        default:
                            Console.WriteLine("Неверный выбор таблицы.");
                            break;
                    }
                    break;



                case "5":
                    Logger.Log("Выбран пункт запросов");
                    Console.WriteLine("\nВыберите запрос:");
                    Console.WriteLine("1. Перечень клубов с золотыми медалями");
                    Console.WriteLine("2. Перечень клубов с достижениями и странами");
                    Console.WriteLine("3. Количество клубов, выигравших Лигу Чемпионов");
                    Console.WriteLine("4. Количество стран, в которых есть клубы, выигравшие Кубок обладателей кубков");

                    var queryChoice = Console.ReadLine();
                    Logger.Log($"Пользователь выбрал запрос: {queryChoice}");
                    switch (queryChoice)
                    {
                        case "1":
                            Operations.GetGoldMedalsList(achievements); // Выполнение первого запроса
                            break;
                        case "2":
                            Operations.GetClubsWithAchievementsAndCountries(clubs, achievements, countries); // Выполнение второго запроса
                            break;
                        case "3":
                            Operations.GetChampionsLeagueWinnersCount(clubs, achievements); // Выполнение третьего запроса
                            break;
                        case "4":
                            Operations.GetCountriesWithCupWinners(clubs, achievements); // Выполнение четвертого запроса
                            break;
                        default:
                            Console.WriteLine("Неверный выбор запроса.");
                            Logger.Log("Пользователь выбрал неверный запрос.");
                            break;
                    }
                    break;

                case "6":
                    Logger.Log("Программа завершена.");
                    return;

                default:
                    Logger.Log("Неверный выбор меню");
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }
    }

}
