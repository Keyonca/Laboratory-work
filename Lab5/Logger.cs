using System;  
using System.IO;

public static class Logger
{
    private static StreamWriter logWriter;  // Статическое поле для записи в файл

    public static void InitializeLogger(string logFileName, bool append)  // Метод для инициализации логгера
    {
        FileMode fileMode;  // Переменная для хранения режима открытия файла

        // Проверка флага append, чтобы выбрать нужный режим открытия файла
        if (append == true)
        {
            fileMode = FileMode.Append;  // Если append равно true, выбираем режим добавления в конец файла
        }
        else
        {
            fileMode = FileMode.Create;  // Если append равно false, выбираем режим создания/перезаписи файла
        }

        // Инициализация объекта StreamWriter, который будет записывать в файл
        logWriter = new StreamWriter(new FileStream(logFileName, fileMode, FileAccess.Write))
        {
            AutoFlush = true // Автоматическая запись в файл при каждом вызове WriteLine
        };
    }

    public static void Log(string message)  // Метод для записи лог-сообщения
    {
        // Проверка, был ли инициализирован логгер
        if (logWriter == null)
        {
            // Если логгер не инициализирован, выбрасываем исключение
            throw new InvalidOperationException("Logger не инициализирован. Вызовите InitializeLogger перед использованием Log.");
        }

        // Формирование строки лог-сообщения с текущей меткой времени
        var logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";

        // Запись лог-сообщения в файл
        logWriter.WriteLine(logMessage);
    }
}
