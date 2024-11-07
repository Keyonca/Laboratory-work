using System;

public class MatrixOperations
{
    private int[,] matrix;

    // Конструктор по умолчанию
    public MatrixOperations()
    {
        matrix = new int[0, 0];
    }

    // Конструктор для ввода матрицы пользователем
    public MatrixOperations(int n, int m)
    {
        matrix = new int[n, m];
        Console.WriteLine($"Введите значения для {n}x{m} матрицы:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                while (true)
                {
                    Console.Write($"Элемент [{i},{j}]: ");
                    if (int.TryParse(Console.ReadLine(), out int value))
                    {
                        matrix[i, j] = value;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка ввода! Пожалуйста, введите целое число.");
                    }
                }
            }
        }
    }

    // Конструктор для случайной матрицы n x n
    public MatrixOperations(int n)
    {
        var random = new Random();
        matrix = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i > j)
                    matrix[i, j] = random.Next(-70, 151);  // Ниже диагонали
                else
                    matrix[i, j] = random.Next(17, 171);    // На или выше диагонали
            }
        }
    }

    // Конструктор для "звездочной" матрицы n x n
    public MatrixOperations(int n, bool isStarShape)
    {
        matrix = new int[n, n];
        var random = new Random();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i + j >= n / 2 && j - i <= n / 2 && i - j <= n / 2 && i + j < n + (n / 2))
                {
                    matrix[i, j] = random.Next(1, 51);
                }
                else
                {
                    matrix[i, j] = 0;
                }
            }
        }
    }

    // Задание 2: Найти диагональ с максимальной суммой
    public int MaxParallelDiagonalSum()
    {
        int n = matrix.GetLength(0);
        int maxSum = int.MinValue;

        for (int d = -(n - 1); d <= (n - 1); d++)
        {
            if (d == 0) continue;

            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                int j = i + d;
                if (j >= 0 && j < n)
                {
                    sum += matrix[i, j];
                }
            }
            if (sum > maxSum) maxSum = sum;
        }

        return maxSum;
    }

    // Задание 3: Матричные операции с перегрузкой операторов
    public static MatrixOperations operator *(MatrixOperations a, MatrixOperations b)
    {
        int n = a.matrix.GetLength(0);
        int[,] result = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                result[i, j] = 0;
                for (int k = 0; k < n; k++)
                {
                    result[i, j] += a.matrix[i, k] * b.matrix[k, j];
                }
            }
        }
        MatrixOperations multiplicationResult = new MatrixOperations();
        multiplicationResult.matrix = result;
        return multiplicationResult;
    }

    public static MatrixOperations operator -(MatrixOperations a, MatrixOperations b)
    {
        int n = a.matrix.GetLength(0);
        int[,] result = new int[n, n];

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                result[i, j] = a.matrix[i, j] - b.matrix[i, j];

        MatrixOperations subtractionResult = new MatrixOperations();
        subtractionResult.matrix = result;
        return subtractionResult;
    }

    // Метод для транспонирования матрицы
    public MatrixOperations Transpose()
    {
        int n = matrix.GetLength(0);
        int[,] transposed = new int[n, n];

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                transposed[i, j] = matrix[j, i];

        MatrixOperations transposedMatrix = new MatrixOperations();
        transposedMatrix.matrix = transposed;
        return transposedMatrix;
    }

    // Перегрузка ToString для отображения матрицы
    public override string ToString()
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        string result = "";

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                result += matrix[i, j].ToString().PadLeft(5) + " ";
            }
            result += "\n";
        }
        return result;
    }

}
