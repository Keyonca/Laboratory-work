using System;

public class Cat : InterfaceMeowable
{
    private string name;

    // Конструктор, который принимает имя кота
    public Cat(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Имя кота не может быть пустым.");
        }
        this.name = name;
    }

    // Метод для получения текстовой формы кота
    public override string ToString()
    {
        return $"кот {name}";
    }

    // Реализация метода Meow из интерфейса IMeowable
    public void Meow()
    {
        Console.WriteLine($"{name}: мяу!");
    }
}
