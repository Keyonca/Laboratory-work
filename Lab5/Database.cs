using Aspose.Cells; 
using System.Collections.Generic; 

public class Database
{
    // Метод для чтения списка стран из файла Excel
    public static List<Country> ReadCountries(string filePath)
    {
        // Создание экземпляра книги Excel из указанного файла
        var workbook = new Workbook(filePath);

        // Получение рабочего листа "Страны" из книги
        var sheet = workbook.Worksheets["Страны"];

        // Создание пустого списка стран
        var countries = new List<Country>();

        // Цикл по строкам на листе (начиная с 1, так как 0 - это заголовок)
        for (int i = 1; i <= sheet.Cells.MaxDataRow; i++)
        {
            // Добавление новой страны в список
            countries.Add(new Country
            {
                // Чтение ID страны (предполагается, что это целое число)
                CountryId = int.Parse(sheet.Cells[i, 0].Value.ToString()),

                // Чтение названия страны (предполагается, что это строка)
                Name = sheet.Cells[i, 1].Value.ToString()
            });
        }

        // Возвращаем список стран
        return countries;
    }

    // Метод для чтения списка клубов из файла Excel
    public static List<Club> ReadClubs(string filePath)
    {
        // Создание экземпляра книги Excel из указанного файла
        var workbook = new Workbook(filePath);

        // Получение рабочего листа "Клубы" из книги
        var sheet = workbook.Worksheets["Клубы"];

        // Создание пустого списка клубов
        var clubs = new List<Club>();

        // Цикл по строкам на листе (начиная с 1, так как 0 - это заголовок)
        for (int i = 1; i <= sheet.Cells.MaxDataRow; i++)
        {
            // Добавление нового клуба в список
            clubs.Add(new Club
            {
                // Чтение ID клуба (целое число)
                ClubId = int.Parse(sheet.Cells[i, 0].Value.ToString()),

                // Чтение названия клуба (строка)
                Name = sheet.Cells[i, 1].Value.ToString(),

                // Чтение ID страны (целое число, который соответствует стране клуба)
                CountryId = int.Parse(sheet.Cells[i, 2].Value.ToString())
            });
        }

        // Возвращаем список клубов
        return clubs;
    }

    // Вспомогательный метод для получения значения из ячейки Excel с обработкой пустых значений
    private static string GetValueOrDefault(Cell cell)
    {
        // Если ячейка не пуста
        if (cell.Value != null)
        {
            // Возвращаем значение ячейки как строку
            return cell.Value.ToString();
        }
        else
        {
            // Если ячейка пуста, возвращаем строку "0"
            return "0";
        }
    }

    // Метод для чтения списка достижений клубов из файла Excel
    public static List<Achievement> ReadAchievements(string filePath)
    {
        // Создание экземпляра книги Excel из указанного файла
        var workbook = new Workbook(filePath);

        // Получение рабочего листа "Достижения" из книги
        var sheet = workbook.Worksheets["Достижения"];

        // Создание пустого списка достижений
        var achievements = new List<Achievement>();

        // Цикл по строкам на листе (начиная с 1, так как 0 - это заголовок)
        for (int i = 1; i <= sheet.Cells.MaxDataRow; i++)
        {
            // Добавление нового достижения клуба в список
            achievements.Add(new Achievement(
                // Чтение ID клуба (целое число)
                int.Parse(GetValueOrDefault(sheet.Cells[i, 0])),

                // Чтение количества золотых медалей (целое число)
                int.Parse(GetValueOrDefault(sheet.Cells[i, 1])),

                // Чтение количества серебряных медалей (целое число)
                int.Parse(GetValueOrDefault(sheet.Cells[i, 2])),

                // Чтение количества бронзовых медалей (целое число)
                int.Parse(GetValueOrDefault(sheet.Cells[i, 3])),

                // Чтение количества выигранных национальных кубков (целое число)
                int.Parse(GetValueOrDefault(sheet.Cells[i, 4])),

                // Чтение количества проигранных финалов национальных кубков (целое число)
                int.Parse(GetValueOrDefault(sheet.Cells[i, 5])),

                // Чтение количества выигранных Лиги Чемпионов (целое число)
                int.Parse(GetValueOrDefault(sheet.Cells[i, 6])),

                // Чтение количества проигранных финалов Лиги Чемпионов (целое число)
                int.Parse(GetValueOrDefault(sheet.Cells[i, 7])),

                // Чтение количества выигранных Лиги Европы (целое число)
                int.Parse(GetValueOrDefault(sheet.Cells[i, 8])),

                // Чтение количества проигранных финалов Лиги Европы (целое число)
                int.Parse(GetValueOrDefault(sheet.Cells[i, 9])),

                // Чтение количества выигранных Кубка Обладателей Кубков (целое число)
                int.Parse(GetValueOrDefault(sheet.Cells[i, 10])),

                // Чтение количества проигранных финалов Кубка Обладателей Кубков (целое число)
                int.Parse(GetValueOrDefault(sheet.Cells[i, 11])),

                // Чтение количества выигранных Лиги Конференций (целое число)
                int.Parse(GetValueOrDefault(sheet.Cells[i, 12])),

                // Чтение количества проигранных финалов Лиги Конференций (целое число)
                int.Parse(GetValueOrDefault(sheet.Cells[i, 13]))
            ));
        }

        // Возвращаем список достижений
        return achievements;
    }
}
