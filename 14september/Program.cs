using System;

struct Vec3
{
    public double X { get; }
    public double Y { get; }
    public double Z { get; }

    public Vec3(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    // Получение длины вектора
    public double Length()
    {
        return Math.Sqrt(X * X + Y * Y + Z * Z);
    }

    // Сложение векторов
    public static Vec3 operator +(Vec3 v1, Vec3 v2)
    {
        return new Vec3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
    }

    // Умножение вектора на число
    public static Vec3 operator *(Vec3 v, double scalar)
    {
        return new Vec3(v.X * scalar, v.Y * scalar, v.Z * scalar);
    }

    // Скалярное произведение векторов
    public static double Dot(Vec3 v1, Vec3 v2)
    {
        return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
    }

    // Векторное произведение
    public static Vec3 Cross(Vec3 v1, Vec3 v2)
    {
        return new Vec3(
            v1.Y * v2.Z - v1.Z * v2.Y,
            v1.Z * v2.X - v1.X * v2.Z,
            v1.X * v2.Y - v1.Y * v2.X
        );
    }

    // Сравнение векторов
    public static bool operator ==(Vec3 v1, Vec3 v2)
    {
        return v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z;
    }

    public static bool operator !=(Vec3 v1, Vec3 v2)
    {
        return !(v1 == v2);
    }

    // Сонаправленность векторов
    public static bool AreParallel(Vec3 v1, Vec3 v2)
    {
        // Векторы сонаправлены, если их векторное произведение равно нулю
        return Cross(v1, v2).Length() == 0;
    }

    // Переопределение метода Equals для корректной работы сравнения
    public override bool Equals(object obj)
    {
        if (obj is Vec3 other)
        {
            return this == other;
        }
        return false;
    }

    // Переопределение GetHashCode для корректной работы сравнения
    public override int GetHashCode()
    {
        return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
    }
}

class Program
{
    static void Main()
    {
        Vec3 v1 = new Vec3(1, 2, 3);
        Vec3 v2 = new Vec3(4, 5, 6);

        // Примеры использования операций
        Vec3 sum = v1 + v2;
        Vec3 scaled = v1 * 2;
        double dotProduct = Vec3.Dot(v1, v2);
        Vec3 crossProduct = Vec3.Cross(v1, v2);

        // Сравнение векторов и проверка на сонаправленность
        bool areEqual = v1 == v2;
        bool areParallel = Vec3.AreParallel(v1, v2);

        Console.WriteLine($"Sum: {sum.X}, {sum.Y}, {sum.Z}");
        Console.WriteLine($"Scaled: {scaled.X}, {scaled.Y}, {scaled.Z}");
        Console.WriteLine($"Dot Product: {dotProduct}");
        Console.WriteLine($"Cross Product: {crossProduct.X}, {crossProduct.Y}, {crossProduct.Z}");
        Console.WriteLine($"Are Equal: {areEqual}");
        Console.WriteLine($"Are Parallel: {areParallel}");
    }
}