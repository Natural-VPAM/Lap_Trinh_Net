using System;

class Program
{
    // Hàm kiểm tra số nguyên tố
    static bool IsPrime(int n)
    {
        if (n < 2) return false;
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0) return false;
        }
        return true;
    }

    // Hàm kiểm tra số hoàn hảo
    static bool IsPerfectNumber(int n)
    {
        if (n <= 1) return false;
        int sum = 0;
        for (int i = 1; i < n; i++)
        {
            if (n % i == 0) sum += i;
        }
        return sum == n;
    }

    // Hàm in N số Fibonacci đầu tiên
    static void PrintFibonacci(int N)
    {
        int a = 0, b = 1;
        for (int i = 1; i <= N; i++)
        {
            Console.Write(a);
            if (i < N) Console.Write(", ");
            int temp = a + b;
            a = b;
            b = temp;
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Console.Write("Nhập số nguyên dương N: ");
        int N = int.Parse(Console.ReadLine());

        // Kiểm tra số hoàn hảo
        if (IsPerfectNumber(N))
            Console.WriteLine($"{N} là Số hoàn hảo!");
        else
            Console.WriteLine($"{N} KHÔNG là Số hoàn hảo.");

        // Kiểm tra số nguyên tố
        if (IsPrime(N))
            Console.WriteLine($"{N} là Số nguyên tố.");
        else
            Console.WriteLine($"{N} KHÔNG là Số nguyên tố.");

        // In dãy Fibonacci
        Console.Write($"Dãy Fibonacci {N} số: ");
        PrintFibonacci(N);
    }
}