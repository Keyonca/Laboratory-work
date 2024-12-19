using System;

public class Dog : InterfaceMeowable
{
    private string name;

    public Dog(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Имя собаки не может быть пустым.");
        }
        this.name = name;
    }

    // Реализация метода Meow из интерфейса IMeowable
    public void Meow()
    {
        Console.WriteLine($"{name}: гав!");
    }

    public override string ToString()
    {
        return $"собака {name}";
    }


}
