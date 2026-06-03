// =====================================================
// THE => OPERATOR
// =====================================================

/*
The => operator appears in 3 common places:

1. Lambda Expressions
2. Expression-Bodied Methods
3. Expression-Bodied Properties

Although the syntax looks similar,
they are different language features.
*/


namespace LambdaOperatorDemo;

public class Program
{
    public static void Main()
    {
        LambdaExpressionDemo();

        Console.WriteLine();

        ExpressionBodiedMethodDemo();

        Console.WriteLine();

        ExpressionBodiedPropertyDemo();
    }

    // =====================================================
    // 1. LAMBDA EXPRESSIONS
    // =====================================================

    /*
    A lambda expression is an anonymous function.

    Syntax:

        parameter => expression

    Example:

        x => x * 2

    Equivalent to:

        int Double(int x)
        {
            return x * 2;
        }
    */

    static void LambdaExpressionDemo()
    {
        Console.WriteLine("=== Lambda Expressions ===");

        Func<int, int> doubleNumber = x => x * 2;

        Console.WriteLine(doubleNumber(5));
        Console.WriteLine(doubleNumber(10));
    }

    // =====================================================
    // 2. EXPRESSION-BODIED METHODS
    // =====================================================

    /*
    Method version:

        public int Square(int x) => x * x;

    Equivalent to:

        public int Square(int x)
        {
            return x * x;
        }

    Notice:
    - Has a method name
    - Has ()
    - Can take parameters
    */

    static int Square(int x) => x * x;

    static void ExpressionBodiedMethodDemo()
    {
        Console.WriteLine("=== Expression-Bodied Methods ===");

        Console.WriteLine(Square(5));
        Console.WriteLine(Square(10));
    }

    // =====================================================
    // 3. EXPRESSION-BODIED PROPERTIES
    // =====================================================

    /*
    Property version:

        public int Count => _count;

    Equivalent to:

        public int Count
        {
            get
            {
                return _count;
            }
        }

    Notice:
    - No ()
    - Accessed like a field
    - Actually a property
    */

    static void ExpressionBodiedPropertyDemo()
    {
        Console.WriteLine("=== Expression-Bodied Properties ===");

        Counter counter = new();

        Console.WriteLine(counter.Count);
    }
}

// =====================================================
// PROPERTY EXAMPLE CLASS
// =====================================================

public class Counter
{
    private int _count = 42;
    public int Count => _count;
}

/*
=====================================================
QUICK IDENTIFICATION
=====================================================

x => x * 2
    Lambda Expression

public int Square(int x) => x * x;
    Expression-Bodied Method

public int Count => _count;
    Expression-Bodied Property
*/