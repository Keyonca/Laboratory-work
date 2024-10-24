using System;

public class Rectangle : BaseClass
{
    private int width;
    private int height;

    public Rectangle(int x, int y, int z, int width, int height)
        : base(x, y, z)
    {
        this.width = width;
        this.height = height;
    }


    // Метод для вычисления площади прямоугольника
    public int Area()
    {
        return width * height;
    }

    // Метод для вычисления периметра прямоугольника
    public int Perimeter()
    {
        return 2 * (width + height);
    }

    // Метод для получения координат верхнего левого угла прямоугольника
    public (int x, int y, int z) GetTopLeftCorner()
    {
        return (field1, field2, field3); // Используем поля базового класса как координаты
    }

    // Перегрузка метода ToString() для дочернего класса
    public override string ToString()
    {
        return base.ToString() + $", Ширина: {width}, Высота: {height}";
    }
}

