using System;

public class Fraction : ICloneable, IFractionOperations
{
    private int numerator;
    private int denominator;
    private double? cachedValue; // Кэш для вещественного значения

    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new ArgumentException("Знаменатель не может быть нулем.");

        // Убедимся, что знаменатель положительный
        if (denominator < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }

        this.numerator = numerator;
        this.denominator = denominator;
    }

    public override string ToString()
    {
        return $"{numerator}/{denominator}";
    }

    // Перегрузка оператора сложения
    public static Fraction operator +(Fraction f1, Fraction f2)
    {
        int newNumerator = f1.numerator * f2.denominator + f2.numerator * f1.denominator;
        int newDenominator = f1.denominator * f2.denominator;
        return new Fraction(newNumerator, newDenominator).Simplify();
    }

    // Перегрузка оператора вычитания
    public static Fraction operator -(Fraction f1, Fraction f2)
    {
        int newNumerator = f1.numerator * f2.denominator - f2.numerator * f1.denominator;
        int newDenominator = f1.denominator * f2.denominator;
        return new Fraction(newNumerator, newDenominator).Simplify();
    }

    // Перегрузка оператора умножения
    public static Fraction operator *(Fraction f1, Fraction f2)
    {
        return new Fraction(f1.numerator * f2.numerator, f1.denominator * f2.denominator).Simplify();
    }

    // Перегрузка оператора деления
    public static Fraction operator /(Fraction f1, Fraction f2)
    {
        if (f2.numerator == 0)
            throw new ArgumentException("Деление на ноль.");

        return new Fraction(f1.numerator * f2.denominator, f1.denominator * f2.numerator).Simplify();
    }

    // Перегрузка оператора сложения с целым числом
    public static Fraction operator +(Fraction f, int integer)
    {
        return f + new Fraction(integer, 1);
    }

    // Перегрузка оператора вычитания с целым числом
    public static Fraction operator -(Fraction f, int integer)
    {
        return f - new Fraction(integer, 1);
    }

    // Перегрузка оператора умножения с целым числом
    public static Fraction operator *(Fraction f, int integer)
    {
        return new Fraction(f.numerator * integer, f.denominator).Simplify();
    }

    // Перегрузка оператора деления с целым числом
    public static Fraction operator /(Fraction f, int integer)
    {
        if (integer == 0)
            throw new ArgumentException("Деление на ноль.");

        return new Fraction(f.numerator, f.denominator * integer).Simplify();
    }

    private Fraction Simplify()
    {
        int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
        return new Fraction(numerator / gcd, denominator / gcd);
    }

    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public static Fraction GetFractionFromUser(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            string[] parts = input.Split('/');

            if (parts.Length == 2 &&
                int.TryParse(parts[0], out int numerator) &&
                int.TryParse(parts[1], out int denominator))
            {
                try
                {
                    return new Fraction(numerator, denominator);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Неверный формат ввода. Пожалуйста, введите дробь в формате числитель/знаменатель.");
            }
        }
    }

    public override bool Equals(object obj)
    {
        if (obj is Fraction other)
        {
            // Упрощаем обе дроби перед сравнением
            Fraction simplifiedThis = this.Simplify();
            Fraction simplifiedOther = other.Simplify();

            return simplifiedThis.numerator == simplifiedOther.numerator &&
                   simplifiedThis.denominator == simplifiedOther.denominator;
        }
        return false;
    }


    // Переопределяем метод GetHashCode
    public override int GetHashCode()
    {
        // Используем простую комбинацию для создания хеш-кода
        return numerator.GetHashCode() + denominator.GetHashCode();
    }

    // Реализация метода Clone
    public object Clone()
    {
        return new Fraction(this.numerator, this.denominator);
    }

    public double GetValue()
    {
        if (cachedValue == null) // Если кэш пуст, вычисляем значение
        {
            cachedValue = (double)numerator / denominator;
        }
        return cachedValue.Value; // Возвращаем кэшированное значение
    }

    public void SetNumerator(int numerator)
    {
        this.numerator = numerator;
        cachedValue = null; // Сбрасываем кэш при изменении числителя
    }

    public void SetDenominator(int denominator)
    {
        if (denominator == 0)
            throw new ArgumentException("Знаменатель не может быть нулем.");

        // Убедимся, что знаменатель положительный
        if (denominator < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }

        this.denominator = denominator;
        cachedValue = null; // Сбрасываем кэш при изменении знаменателя
    }

    public static int GetIntegerFromUser(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            try
            {
                return int.Parse(input);
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка ввода: введено некорректное число. Пожалуйста, попробуйте снова.");
            }
        }
    }
}