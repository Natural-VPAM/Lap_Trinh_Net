using System;

class Program
{
    static void Main()
    {
        Console.Write("Nhập số a: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Nhập số b: ");
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
}