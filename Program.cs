class Calculator
{
    public static void Add(int a, int b)
    {
        int result = a + b;
        Console.WriteLine($"The sum is: {result}");
    }

    public static void Mult(int a, int b)
    {
        int result = a * b;
        Console.WriteLine($"The product is: {result}");
    }
}

//class Program
//{
//    delegate void CalculatorDelegate(int a, int b);

//    static void Main(string[] args)
//    {
//        CalculatorDelegate calculator = Calculator.Add;
//        calculator(10, 6); // Output: The sum is: 15

//        calculator = Calculator.Mult;
//        calculator(10, 5); // Output: The product is: 50
//    }
//}

//class Program
//{
//    delegate void CalculatorDelegate(int a, int b);

//    static void Main(string[] args)
//    {
//        CalculatorDelegate calculator = Calculator.Add;
//        calculator += Calculator.Mult;
//        calculator(10, 5); // Output: The sum is: 15, The product is: 50
//    }
//}

class Programs
{
    delegate void AnonymousDelegate(int a, int b);

    static void Main(string[] args)
    {
        AnonymousDelegate calculator = delegate (int a, int b)
        {
            int result = a + b;
            Console.WriteLine($"The sum is: {result}");
        };

        calculator(10, 5); // Output: The sum is: 15
    }
}