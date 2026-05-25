IntegersBasics();
IntegerDivision();
OperatorPrecedence();
RemainderOperator();
IntegerRangeAndOverflow();
CheckedOverflow();

DoubleBasics();
FloatingPointPrecision();
DoubleVsDecimal();

TypeConversions();
CastingExamples();

MathFunctions();
RadiusChallenge();

RandomNumbers();

FormattingNumbers();


// 1. INTEGER BASICS
void IntegersBasics()
{
    int a = 10;
    int b = 3;

    Console.WriteLine($"a = {a}");
    Console.WriteLine($"b = {b}");

    Console.WriteLine($"Addition: {a + b}");
    Console.WriteLine($"Subtraction: {a - b}");
    Console.WriteLine($"Multiplication: {a * b}");
    Console.WriteLine($"Division: {a / b}");
}

/*
IMPORTANT:
Integer division truncates decimals.

10 / 3 becomes 3
NOT 3.333...
*/


// 2. INTEGER DIVISION
void IntegerDivision()
{
    Console.WriteLine(5 / 2);
    Console.WriteLine(5.0 / 2);
    Console.WriteLine((double)5 / 2);
    Console.WriteLine(5 / 2.0);
}

/*
OUTPUT:
2
2.5
2.5
2.5

RULE:
If BOTH operands are int -> integer division
If ONE operand is double -> floating point division
*/


// 3. OPERATOR PRECEDENCE
void OperatorPrecedence()
{
    int result1 = 5 + 4 * 2;
    int result2 = (5 + 4) * 2;

    Console.WriteLine(result1);
    Console.WriteLine(result2);
}

/*
Multiplication happens before addition.

5 + 4 * 2
= 5 + 8
= 13

(5 + 4) * 2
= 9 * 2
= 18
*/


// 4. REMAINDER / MODULO OPERATOR
void RemainderOperator()
{
    Console.WriteLine(10 % 3);
    Console.WriteLine(20 % 6);
    Console.WriteLine(25 % 5);
}

/*
% gives remainder.

10 % 3 = 1
20 % 6 = 2
25 % 5 = 0
*/


// 5. INTEGER RANGE AND OVERFLOW
void IntegerRangeAndOverflow()
{
    Console.WriteLine(int.MinValue);
    Console.WriteLine(int.MaxValue);

    // Compile time overflow, error thrown.
    // int overflow = int.MaxValue + 1;
    // Console.WriteLine(overflow);

    // Run-time overflow, no error is thrown.
    int x = int.MaxValue;
    x++;
    Console.WriteLine(x);
    
}

/*
Overflow wraps around.

2147483647 + 1
becomes
-2147483648
*/


// 6. CHECKED OVERFLOW
void CheckedOverflow()
{
    checked
    {
        int x = int.MaxValue;

        x++;

        Console.WriteLine(x);
    }
}

/*
This throws exception instead of silently overflowing.
*/


// 7. DOUBLE BASICS
void DoubleBasics()
{
    double a = 5;
    double b = 2;

    Console.WriteLine(a / b);

    Console.WriteLine(double.MinValue);
    Console.WriteLine(double.MaxValue);
}

/*
double:
- supports decimals
- huge range
- limited precision
*/


// 8. FLOATING POINT PRECISION ISSUES
void FloatingPointPrecision()
{
    double third = 1.0 / 3.0;

    Console.WriteLine(third);

    double x = 0.1 + 0.2;

    Console.WriteLine(x);

    Console.WriteLine(x == 0.3);
}

/*
IMPORTANT:

Computers store doubles in binary.

Some decimal numbers cannot be represented exactly.

So:
0.1 + 0.2
becomes:
0.30000000000000004

Therefore:
x == 0.3
is false
*/


// 9. DOUBLE VS DECIMAL
void DoubleVsDecimal()
{
    double a = 1.0 / 3.0;

    decimal b = 1.0M / 3.0M;

    Console.WriteLine(a);

    Console.WriteLine(b);
}

/*
decimal:
- smaller range
- much better decimal precision
- commonly used for money

M suffix tells compiler:
"This is decimal"
*/


// 10. TYPE CONVERSIONS
void TypeConversions()
{
    int a = 5;

    double b = a;

    Console.WriteLine(b);
}

/*
Implicit conversion:
int -> double

Safe because no data loss.
*/


// 11. CASTING EXAMPLES
void CastingExamples()
{
    double x = 5.9;

    int y = (int)x;

    Console.WriteLine(y);
}

/*
Explicit cast required.

Decimal part gets TRUNCATED.

5.9 becomes 5
*/


// 12. MATH FUNCTIONS
void MathFunctions()
{
    Console.WriteLine(Math.Sqrt(25));
    Console.WriteLine(Math.Pow(2, 3));
    Console.WriteLine(Math.Abs(-10));
    Console.WriteLine(Math.Round(3.6));
    Console.WriteLine(Math.Floor(3.9));
    Console.WriteLine(Math.Ceiling(3.1));
    Console.WriteLine(Math.Max(10, 20));
    Console.WriteLine(Math.Min(10, 20));
}

/*
Useful math methods.
*/



// 13. AREA OF CIRCLE CHALLENGE
void RadiusChallenge()
{
    double radius = 2.5;

    double area = Math.PI * radius * radius;

    Console.WriteLine(area);
}

/*
Formula:
pi * r * r
*/


// 14. RANDOM NUMBERS
void RandomNumbers()
{
    Random random = new();

    int number = random.Next(1, 11);

    Console.WriteLine(number);
}

/*
Upper bound is EXCLUSIVE.

1, 11
means:
1 to 10
*/


// 15. FORMATTING NUMBERS
void FormattingNumbers()
{
    double price = 12.3456789;

    Console.WriteLine(price);
    Console.WriteLine(price.ToString("F2"));
    Console.WriteLine(price.ToString("F4"));
    Console.WriteLine(price.ToString("C"));
}

/*
F2 -> 2 decimal places
F4 -> 4 decimal places
C  -> currency format
*/