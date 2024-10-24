public class LineSegment
{
    private double x1; // Координата начала отрезка
    private double x2; // Координата конца отрезка

    // Конструктор класса
    public LineSegment(double start, double end)
    {
        // Убедимся, что начало меньше конца
        if (start < end)
        {
            x1 = start;
            x2 = end;
        }
        else
        {
            x1 = end;
            x2 = start;
        }
    }

    // Метод для проверки, попадает ли число в отрезок
    public bool Contains(double number)
    {
        return number >= x1 && number <= x2;
    }

    // Перегрузка метода ToString()
    public override string ToString()
    {
        return $"Отрезок: [{x1}, {x2}]";
    }

    // Унарная операция: вычислить длину отрезка
    public static double operator !(LineSegment segment)
    {
        return segment.x2 - segment.x1;
    }

    // Унарная операция: увеличить координаты границ отрезка на 1
    public static LineSegment operator ++(LineSegment segment)
    {
        return new LineSegment(segment.x1 + 1, segment.x2 + 1);
    }

    // Явное преобразование в int
    public static explicit operator int(LineSegment segment)
    {
        return (int)segment.x1; // Возвращаем целую часть координаты начала отрезка
    }

    // Неявное преобразование в double
    public static implicit operator double(LineSegment segment)
    {
        return segment.x2; // Возвращаем координату конца отрезка
    }

    // Бинарная операция: + (увеличение координат на d)
    public static LineSegment operator +(LineSegment segment, int d)
{
    return new LineSegment(segment.x1 + d, segment.x2 + d);
}

    // Бинарная операция: < (проверка, попадает ли целое число в отрезок)
    public static bool operator <(LineSegment segment, int number)
    {
        return segment.Contains(number);
    }

    public static bool operator >(LineSegment segment, int number)
    {
        return !segment.Contains(number); //Возвращаем true, если число не в отрезке
    }
}
