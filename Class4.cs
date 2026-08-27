using System;

class Program
{
    static void Main()
    {
        int choice;
        do
        {
            Console.Clear();
            Console.WriteLine("===== MENU CHÍNH =====");
            Console.WriteLine("1. Bài tập 1: Calculator (switch expression)");
            Console.WriteLine("2. Bài tập 2: Giải phương trình bậc 2");
            Console.WriteLine("3. Bài tập 3: Số nguyên tố, số hoàn hảo, Fibonacci");
            Console.WriteLine("0. Thoát chương trình");
            Console.Write("Nhập lựa chọn của bạn: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                choice = -1; // giá trị sai để báo lỗi
            }

            Console.Clear();
            switch (choice)
            {
                case 1:
                    RunCalculator();
                    break;
                case 2:
                    RunQuadraticEquation();
                    break;
                case 3:
                    RunNumberCheck();
                    break;
                case 0:
                    Console.WriteLine("Thoát chương trình...");
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    break;
            }

            if (choice != 0)
            {
                Console.WriteLine("\nNhấn phím bất kỳ để quay lại Menu...");
                Console.ReadKey();
            }

        } while (choice != 0);
    }

    // Bài tập 1: Calculator
    static void RunCalculator()
    {
        Console.Write("Nhập a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Nhập b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Nhập phép toán (+, -, *, /, %): ");
        char op = Console.ReadKey().KeyChar;
        Console.WriteLine();

        try
        {
            double result = op switch
            {
                '+' => a + b,
                '-' => a - b,
                '*' => a * b,
                '/' when b == 0 => throw new DivideByZeroException(),
                '/' => a / b,
                '%' when b == 0 => throw new DivideByZeroException(),
                '%' => a % b,
                _ => throw new InvalidOperationException("Phép toán không hợp lệ!")
            };
            Console.WriteLine($"Kết quả: {result:F2}");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Lỗi: Không thể chia cho 0!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi: {ex.Message}");
        }
    }

    // Bài tập 2: Giải phương trình bậc 2
    static void RunQuadraticEquation()
    {
        Console.Write("Nhập a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Nhập b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Nhập c: ");
        double c = double.Parse(Console.ReadLine());

        if (a == 0)
        {
            if (b == 0)
            {
                if (c == 0) Console.WriteLine("Phương trình có vô số nghiệm.");
                else Console.WriteLine("Phương trình vô nghiệm.");
            }
            else
            {
                double x = -c / b;
                Console.WriteLine($"Nghiệm bậc nhất: x = {x:F2}");
            }
        }
        else
        {
            double delta = b * b - 4 * a * c;
            if (delta > 0)
            {
                double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                Console.WriteLine($"x1 = {x1:F2}, x2 = {x2:F2}");
            }
            else if (delta == 0)
            {
                double x = -b / (2 * a);
                Console.WriteLine($"Nghiệm kép x = {x:F2}");
            }
            else
            {
                Console.WriteLine("Vô nghiệm.");
            }
        }
    }

    // Bài tập 3: Kiểm tra số nguyên tố, số hoàn hảo và Fibonacci
    static void RunNumberCheck()
    {
        Console.Write("Nhập số nguyên dương N: ");
        int N = int.Parse(Console.ReadLine());

        if (IsPerfectNumber(N))
            Console.WriteLine($"{N} là Số hoàn hảo!");
        else
            Console.WriteLine($"{N} KHÔNG là Số hoàn hảo.");

        if (IsPrime(N))
            Console.WriteLine($"{N} là Số nguyên tố.");
        else
            Console.WriteLine($"{N} KHÔNG là Số nguyên tố.");

        Console.Write($"Dãy Fibonacci {N} số: ");
        PrintFibonacci(N);
    }

    static bool IsPrime(int n)
    {
        if (n < 2) return false;
        for (int i = 2; i <= Math.Sqrt(n); i++)
            if (n % i == 0) return false;
        return true;
    }

    static bool IsPerfectNumber(int n)
    {
        if (n <= 1) return false;
        int sum = 0;
        for (int i = 1; i < n; i++)
            if (n % i == 0) sum += i;
        return sum == n;
    }

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
}