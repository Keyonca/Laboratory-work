using System.Linq;
using System;
using System.Collections.Generic;
using Aspose.Cells;

public class Operations
    {
        // Метод для удаления страны из списка стран по ID
        public static void DeleteCountry(List<Country> countries, int countryId)
        {
            // Находим страну по её ID
            var country = countries.FirstOrDefault(c => c.CountryId == countryId);
            if (country != null) // Если страна найдена
            {
                countries.Remove(country); // Удаляем страну из списка
                Logger.Log($"Удалена страна с ID {countryId} ({country.Name})."); // Логируем удаление
                Console.WriteLine($"Страна с ID {countryId} успешно удалена."); // Выводим сообщение в консоль
            }
            else // Если страна не найдена
            {
                Logger.Log($"Попытка удаления страны с ID {countryId}: не найдена."); // Логируем ошибку
                Console.WriteLine($"Страна с ID {countryId} не найдена."); // Выводим сообщение в консоль
            }
        }

        // Метод для удаления клуба и его достижений по ID клуба
        public static void DeleteClub(List<Club> clubs, List<Achievement> achievements, int clubId)
        {
            // Находим клуб по ID
            var club = clubs.FirstOrDefault(c => c.ClubId == clubId);
            if (club != null) // Если клуб найден
            {
                clubs.Remove(club); // Удаляем клуб из списка
                achievements.RemoveAll(a => a.ClubId == clubId); // Удаляем все достижения, связанные с клубом
                Logger.Log($"Удалён клуб с ID {clubId} ({club.Name}). Связанные достижения также удалены."); // Логируем удаление клуба
                Console.WriteLine($"Клуб с ID {clubId} и связанные достижения успешно удалены."); // Выводим сообщение в консоль
            }
            else // Если клуб не найден
            {
                Logger.Log($"Попытка удаления клуба с ID {clubId}: не найден."); // Логируем ошибку
                Console.WriteLine($"Клуб с ID {clubId} не найден."); // Выводим сообщение в консоль
            }
        }

        // Метод для удаления достижений клуба по ID клуба
        public static void DeleteAchievement(List<Achievement> achievements, int clubId)
        {
            // Находим достижения клуба по ID клуба
            var achievement = achievements.FirstOrDefault(a => a.ClubId == clubId);
            if (achievement != null) // Если достижения найдены
            {
                achievements.Remove(achievement); // Удаляем достижения
                Logger.Log($"Удалены достижения клуба с ID {clubId}."); // Логируем удаление достижений
                Console.WriteLine($"Достижения для клуба с ID {clubId} успешно удалены."); // Выводим сообщение в консоль
            }
            else // Если достижения не найдены
            {
                Logger.Log($"Попытка удаления достижений для клуба с ID {clubId}: не найдены."); // Логируем ошибку
                Console.WriteLine($"Достижения для клуба с ID {clubId} не найдены."); // Выводим сообщение в консоль
            }
        }

        // Метод для удаления строки из Excel файла по ID записи и индексу колонки с ID
        public static void DeleteRowFromExcel(string filePath, string sheetName, int recordId, int idColumnIndex)
        {
            // Открываем существующий файл Excel
            var workbook = new Workbook(filePath);

            // Получаем нужный лист по имени
            var worksheet = workbook.Worksheets[sheetName];
            if (worksheet == null) // Если лист не найден
            {
                Console.WriteLine($"Лист с именем '{sheetName}' не найден.");
                return;
            }

            // Получаем ячейки на листе
            var cells = worksheet.Cells;
            int rowToDelete = -1;

            // Перебираем строки на листе
            for (int i = 0; i <= cells.MaxDataRow; i++)
            {
                var cellValue = cells[i, idColumnIndex].StringValue;
                if (int.TryParse(cellValue, out int currentId) && currentId == recordId) // Если ID совпадает
                {
                    rowToDelete = i; // Запоминаем индекс строки
                    break;
                }
            }

            if (rowToDelete >= 0) // Если строка найдена
            {
                cells.DeleteRow(rowToDelete); // Удаляем строку
                workbook.Save(filePath); // Сохраняем изменения в файле
                Console.WriteLine($"Запись с ID {recordId} удалена из листа '{sheetName}'."); // Выводим сообщение
            }
            else // Если строка не найдена
            {
                Console.WriteLine($"Запись с ID {recordId} не найдена на листе '{sheetName}'."); // Выводим сообщение
            }
        }

        // Метод для обновления информации о стране по её ID
        public static void UpdateCountry(List<Country> countries, int countryId, string newName)
        {
            // Находим страну по ID
            var country = countries.FirstOrDefault(c => c.CountryId == countryId);
            if (country != null) // Если страна найдена
            {
                country.Name = newName; // Обновляем имя страны
                Logger.Log($"Обновлена страна с ID {countryId}, новое имя: {newName}"); // Логируем обновление
                Console.WriteLine("Страна успешно обновлена."); // Выводим сообщение в консоль
            }
            else // Если страна не найдена
            {
                Logger.Log($"Попытка обновления страны с ID {countryId}: не найдена."); // Логируем ошибку
                Console.WriteLine("Страна с таким ID не найдена."); // Выводим сообщение в консоль
            }
        }

        // Метод для обновления информации о клубе по его ID
        public static void UpdateClub(List<Club> clubs, int clubId, string newName, int newCountryId)
        {
            // Находим клуб по ID
            var club = clubs.FirstOrDefault(c => c.ClubId == clubId);
            if (club != null) // Если клуб найден
            {
                club.Name = newName; // Обновляем имя клуба
                club.CountryId = newCountryId; // Обновляем ID страны клуба
                Logger.Log($"Обновлён клуб с ID {clubId}, новое имя: {newName}, новый CountryId: {newCountryId}"); // Логируем обновление
                Console.WriteLine("Клуб успешно обновлён."); // Выводим сообщение в консоль
            }
            else // Если клуб не найден
            {
                Logger.Log($"Попытка обновления клуба с ID {clubId}: не найден."); // Логируем ошибку
                Console.WriteLine("Клуб с таким ID не найден."); // Выводим сообщение в консоль
            }
        }

        // Метод для обновления достижений клуба по его ID
        public static void UpdateAchievement(List<Achievement> achievements, int clubId, int newGoldMedals, int newSilverMedals, int newBronzeMedals, int newNationalCupWins, int newNationalCupFinals, int newChampionsLeagueWins,
            int newChampionsLeagueFinals, int newEuropaLeagueWins, int newEuropaLeagueFinals, int newCupWinnersCupWins, int newCupWinnersCupFinals, int newConferenceLeagueWins, int newConferenceLeagueFinals)
        {
            // Находим достижения клуба по ID клуба
            var achievement = achievements.FirstOrDefault(a => a.ClubId == clubId);
            if (achievement != null) // Если достижения найдены
            {
                // Обновляем достижения клуба
                achievement.GoldMedals = newGoldMedals;
                achievement.SilverMedals = newSilverMedals;
                achievement.BronzeMedals = newBronzeMedals;
                achievement.NationalCupWins = newNationalCupWins;
                achievement.NationalCupFinals = newNationalCupFinals;
                achievement.ChampionsLeagueWins = newChampionsLeagueWins;
                achievement.ChampionsLeagueFinals = newChampionsLeagueFinals;
                achievement.EuropaLeagueWins = newEuropaLeagueWins;
                achievement.EuropaLeagueFinals = newEuropaLeagueFinals;
                achievement.CupWinnersCupWins = newCupWinnersCupWins;
                achievement.CupWinnersCupFinals = newCupWinnersCupFinals;
                achievement.ConferenceLeagueWins = newConferenceLeagueWins;
                achievement.ConferenceLeagueFinals = newConferenceLeagueFinals;

                // Логируем обновление достижений клуба
                Logger.Log($"Обновлены достижения клуба с ID {clubId}: Золото: {newGoldMedals}, Серебро: {newSilverMedals}, Бронза: {newBronzeMedals}, " +
                    $"Национальные кубки (Победы: {newNationalCupWins}, Финалы: {newNationalCupFinals}), " +
                    $"Лига Чемпионов (Победы: {newChampionsLeagueWins}, Финалы: {newChampionsLeagueFinals}), " +
                    $"Лига Европы (Победы: {newEuropaLeagueWins}, Финалы: {newEuropaLeagueFinals}), " +
                    $"Кубок обладателей кубков (Победы: {newCupWinnersCupWins}, Финалы: {newCupWinnersCupFinals}), " +
                    $"Лига конференций (Победы: {newConferenceLeagueWins}, Финалы: {newConferenceLeagueFinals}).");

                Console.WriteLine("Достижения клуба успешно обновлены."); // Выводим сообщение в консоль
            }
            else // Если достижения не найдены
            {
                Logger.Log($"Попытка обновления достижений для клуба с ID {clubId}: не найдены."); // Логируем ошибку
                Console.WriteLine("Достижения для клуба с таким ID не найдены."); // Выводим сообщение в консоль
            }
        }

        public static void UpdateRowInExcel(string filePath, string sheetName, int recordId, params object[] newValues)
        {
            // Открываем существующий файл Excel
            var workbook = new Workbook(filePath);

            // Получаем нужный лист по имени
            var worksheet = workbook.Worksheets[sheetName];
            if (worksheet == null)
            {
                // Если лист не найден, выводим сообщение и выходим из метода
                Console.WriteLine($"Лист с именем '{sheetName}' не найден.");
                return;
            }

            // Находим строку с указанным ID
            var cells = worksheet.Cells; // Доступ к ячейкам листа
            int rowToUpdate = -1; // Переменная для хранения индекса строки для обновления

            // Перебираем все строки в листе
            for (int i = 0; i <= cells.MaxDataRow; i++)
            {
                // Считываем значение из первой колонки строки (предполагается, что ID находится в колонке 0)
                var cellValue = cells[i, 0].StringValue;
                if (int.TryParse(cellValue, out int currentId) && currentId == recordId)
                {
                    // Если нашли строку с нужным ID, сохраняем её индекс
                    rowToUpdate = i;
                    break;
                }
            }

            // Проверяем, была ли найдена строка с нужным ID
            if (rowToUpdate >= 0)
            {
                // Обновляем значения в строке начиная с первой доступной колонки
                if (newValues.Length > 0)
                {
                    cells[rowToUpdate, 1].PutValue(newValues[0]); // Записываем первое значение в колонку 1
                }

                if (newValues.Length > 1)
                {
                    // Если есть другие значения, обновляем их в соответствующих колонках
                    for (int col = 2; col < newValues.Length + 1; col++)
                    {
                        cells[rowToUpdate, col].PutValue(newValues[col - 1]);
                    }
                }

                // Сохраняем изменения в файле
                workbook.Save(filePath);
                Console.WriteLine($"Запись с ID {recordId} обновлена на листе '{sheetName}'.");
            }
            else
            {
                // Если строка с указанным ID не найдена, выводим сообщение
                Console.WriteLine($"Запись с ID {recordId} не найдена на листе '{sheetName}'.");
            }
        }

        public static void AddCountry(List<Country> countries, int countryId, string name)
        {
            // Проверяем, что имя страны не пустое
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Имя страны не может быть пустым.");
                Logger.Log("Ошибка: попытка добавить страну с пустым именем.");
                return; // Завершаем выполнение метода
            }

            // Проверяем, существует ли уже страна с таким ID
            if (countries.Any(c => c.CountryId == countryId))
            {
                Console.WriteLine("Страна с таким ID уже существует.");
                Logger.Log($"Ошибка: попытка добавить страну с ID {countryId}, которая уже существует.");
            }
            else
            {
                // Добавляем новую страну в список
                countries.Add(new Country { CountryId = countryId, Name = name });
                Logger.Log($"Добавлена новая страна: ID {countryId}, Имя: {name}");
                Console.WriteLine("Страна успешно добавлена.");
            }
        }

        public static void AddClub(List<Club> clubs, int clubId, string name, int countryId)
        {
            // Проверяем, что имя клуба не пустое
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Имя клуба не может быть пустым.");
                Logger.Log("Ошибка: попытка добавить клуб с пустым именем.");
                return;
            }

            // Проверяем, существует ли уже клуб с таким ID
            if (clubs.Any(c => c.ClubId == clubId))
            {
                Console.WriteLine("Клуб с таким ID уже существует.");
                Logger.Log($"Ошибка: попытка добавить клуб с ID {clubId}, который уже существует.");
            }
            else
            {
                // Добавляем новый клуб в список
                clubs.Add(new Club { ClubId = clubId, Name = name, CountryId = countryId });
                Logger.Log($"Добавлен новый клуб: ID {clubId}, Имя: {name}, ID страны: {countryId}");
                Console.WriteLine("Клуб успешно добавлен.");
            }
        }

        public static void AddAchievement(List<Achievement> achievements, Achievement newAchievement)
        {
            // Проверяем, существуют ли достижения для клуба с указанным ID
            if (achievements.Any(a => a.ClubId == newAchievement.ClubId))
            {
                Console.WriteLine("Достижения для клуба с таким ID уже существуют.");
                Logger.Log($"Ошибка: попытка добавить достижения для клуба с ID {newAchievement.ClubId}, которые уже существуют.");
            }
            else
            {
                // Добавляем достижения в список
                achievements.Add(newAchievement);
                Logger.Log($"Добавлены достижения для клуба с ID {newAchievement.ClubId}");
                Console.WriteLine("Достижения успешно добавлены.");
            }
        }

        public static void AddRowToExcel(string filePath, string sheetName, int idColumnIndex, object idValue, params object[] values)
        {
            // Открываем существующий файл Excel
            var workbook = new Workbook(filePath);

            // Получаем нужный лист по имени
            var worksheet = workbook.Worksheets[sheetName];
            if (worksheet == null)
            {
                Console.WriteLine($"Лист с именем '{sheetName}' не найден.");
                return;
            }

            // Проверяем, существует ли запись с указанным ID
            bool idExists = false;
            for (int row = 0; row <= worksheet.Cells.MaxDataRow; row++)
            {
                if (worksheet.Cells[row, idColumnIndex].Value != null && worksheet.Cells[row, idColumnIndex].Value.ToString() == idValue.ToString())
                {
                    idExists = true;
                    break;
                }

        }

        if (idExists)
            {
                Console.WriteLine($"Запись с ID '{idValue}' уже существует в листе '{sheetName}'.");
                return;
            }

            // Находим следующую пустую строку
            int newRow = worksheet.Cells.MaxDataRow + 1;

            // Записываем значения в новую строку
            for (int col = 0; col < values.Length; col++)
            {
                worksheet.Cells[newRow, col].PutValue(values[col]);
            }

            // Сохраняем изменения в файле
            workbook.Save(filePath);

            Console.WriteLine($"Добавлена запись в лист '{sheetName}'.");
        }



        // Получение перечня клубов с количеством золотых медалей
        public static void GetGoldMedalsList(List<Achievement> achievementsList)
            {
                // Логируем начало запроса
                Logger.Log("Запрос: Перечень клубов с золотыми медалями");

                // Формируем список клубов, у которых есть золотые медали
                var goldMedalsList = from a in achievementsList
                                     where a.GoldMedals > 0 // Фильтруем клубы с количеством золотых медалей больше 0
                                     select new
                                     {
                                         ClubId = a.ClubId, // ID клуба
                                         GoldMedals = a.GoldMedals // Количество золотых медалей
                                     };

                // Выводим список клубов с золотыми медалями
                Console.WriteLine("Перечень клубов с золотыми медалями:");
                foreach (var item in goldMedalsList)
                {
                    // Для каждого клуба выводим его ID и количество золотых медалей
                    Console.WriteLine($"Club ID: {item.ClubId}, Gold Medals: {item.GoldMedals}");
                }

                // Логируем завершение запроса
                Logger.Log("Запрос завершён: Перечень клубов с золотыми медалями");
            }

        // Получение перечня клубов с достижениями и странами
        public static void GetClubsWithAchievementsAndCountries(List<Club> clubsList, List<Achievement> achievementsList, List<Country> countriesList)
        {
            // Логируем начало запроса
            Logger.Log("Запрос: Перечень клубов с достижениями и странами");

            // Объединяем данные о клубах, достижениях и странах
            var clubsWithAchievementsAndCountries = from c in clubsList
                                                    join a in achievementsList on c.ClubId equals a.ClubId // Соединяем клубы с их достижениями по ClubId
                                                    join country in countriesList on c.CountryId equals country.CountryId // Соединяем клубы с их странами по CountryId
                                                    select new
                                                    {
                                                        ClubName = c.Name, // Название клуба
                                                        CountryName = country.Name, // Название страны
                                                        GoldMedals = a.GoldMedals, // Количество золотых медалей
                                                        SilverMedals = a.SilverMedals, // Количество серебряных медалей
                                                        BronzeMedals = a.BronzeMedals // Количество бронзовых медалей
                                                    };

            // Выводим перечень клубов с достижениями и странами
            Console.WriteLine("Перечень клубов с достижениями и странами:");
            foreach (var item in clubsWithAchievementsAndCountries)
            {
                // Для каждого клуба выводим его название, страну и количество медалей
                Console.WriteLine($"Club Name: {item.ClubName}, Country: {item.CountryName}, Gold Medals: {item.GoldMedals}, Silver Medals: {item.SilverMedals}, Bronze Medals: {item.BronzeMedals}");
            }

            // Логируем завершение запроса
            Logger.Log("Запрос завершён: Перечень клубов с достижениями и странами");
        }

        // Получение количества клубов, выигравших Лигу Чемпионов
        public static void GetChampionsLeagueWinnersCount(List<Club> clubsList, List<Achievement> achievementsList)
        {
            // Логируем начало запроса
            Logger.Log("Запрос: Количество клубов, выигравших Лигу Чемпионов");

            // Определяем количество уникальных клубов, у которых количество побед в Лиге Чемпионов больше 0
            var championsLeagueWinnersCount = (from c in clubsList
                                               join a in achievementsList on c.ClubId equals a.ClubId // Соединяем клубы с их достижениями
                                               where a.ChampionsLeagueWins > 0 // Фильтруем только клубы с победами в Лиге Чемпионов
                                               select c).Distinct().Count(); // Считаем уникальные клубы

            // Выводим количество клубов, выигравших Лигу Чемпионов
            Console.WriteLine($"Количество клубов, выигравших Лигу Чемпионов: {championsLeagueWinnersCount}");

            // Логируем завершение запроса и его результат
            Logger.Log($"Запрос завершён: Количество клубов, выигравших Лигу Чемпионов. Результат: {championsLeagueWinnersCount}");
        }

        // Получение количества стран, в которых есть клубы, выигравшие Кубок обладателей кубков
        public static void GetCountriesWithCupWinners(List<Club> clubsList, List<Achievement> achievementsList)
        {
            // Логируем начало запроса
            Logger.Log("Запрос: Количество стран, в которых есть клубы, выигравшие Кубок обладателей кубков");

            // Определяем количество уникальных стран, у которых есть клубы, выигравшие Кубок обладателей кубков
            var countriesWithCupWinners = (from c in clubsList
                                           join a in achievementsList on c.ClubId equals a.ClubId // Соединяем клубы с их достижениями
                                           where a.CupWinnersCupWins > 0 // Фильтруем только клубы с победами в Кубке обладателей кубков
                                           select c.CountryId).Distinct().Count(); // Считаем уникальные страны по CountryId

            // Выводим количество стран, в которых есть клубы с победами
            Console.WriteLine($"Количество стран, в которых есть клубы, выигравшие Кубок обладателей кубков: {countriesWithCupWinners}");

            // Логируем завершение запроса и его результат
            Logger.Log($"Запрос завершён: Количество стран, в которых есть клубы, выигравшие Кубок обладателей кубков. Результат: {countriesWithCupWinners}");
        }

        // Метод для получения целочисленного ввода от пользователя
        public static int GetIntInput(string prompt)
        {
            int value; // Переменная для хранения введённого значения
            while (true)
            {
                // Выводим сообщение с подсказкой
                Console.Write(prompt);

                // Проверяем, удалось ли корректно преобразовать ввод в число
                if (int.TryParse(Console.ReadLine(), out value))
                    break; // Если да, выходим из цикла

                // Если ввод некорректный, выводим сообщение об ошибке
                Console.WriteLine("Ошибка: введите корректное целое число.");
            }

            // Возвращаем введённое значение
            return value;
        }

}

