using System;

public class BaseClass
{
    protected int field1;
    protected int field2;
    protected int field3;


    public BaseClass(int field1, int field2, int field3)
    {
        this.field1 = field1;
        this.field2 = field2;
        this.field3 = field3;
    }


    // Конструктор копирования
    public BaseClass(BaseClass other)
    {
        this.field1 = other.field1;
        this.field2 = other.field2;
        this.field3 = other.field3;
    }


    // Метод для вычисления максимальной из последних цифр полей
    public int MaxLastDigit()
    {
        int lastDigit1 = Math.Abs(field1) % 10;
        int lastDigit2 = Math.Abs(field2) % 10;
        int lastDigit3 = Math.Abs(field3) % 10;
        return Math.Max(lastDigit1, Math.Max(lastDigit2, lastDigit3));
    }


    // Перегрузка метода ToString()
    public override string ToString()
    {
        return $"Значение 1: {field1}, Значение 2: {field2}, Значение 3: {field3}";
    }
}

