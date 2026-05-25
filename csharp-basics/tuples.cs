// BasicCreation();
// NamedVsUnnamed();
// TupleAssignment();
// MutabilityDemo();
// ArithmeticWithTuples();
// Deconstruction();
// ReturnFromMethod();
// EqualityDemo();
// RealWorldUseCase();


// 1. BASIC CREATION
void BasicCreation()
{
    var point = (1, 2);

    Console.WriteLine(point);
    Console.WriteLine(point.Item1);
    Console.WriteLine(point.Item2);
}

/*
Unnamed tuple:
- Item1, Item2 are default names
- This is ValueTuple<int, int>
*/


// 2. NAMED VS UNNAMED
void NamedVsUnnamed()
{
    var a = (1, 2);

    var b = (X: 1, Y: 2);

    Console.WriteLine(a.Item1);
    Console.WriteLine(b.X);
}

/*
Names are compile-time only.
Runtime storage is positional (ValueTuple fields).
*/


// 3. TUPLE ASSIGNMENT
void TupleAssignment()
{
    var point = (X: 1, Y: 2);

    var other = (A: 10, B: 20);

    other = point;

    Console.WriteLine(other);
}

/*
Tuples are compatible if:
- same number of elements
- same types in order

Names do NOT matter.
*/


// 4. MUTABILITY (IMPORTANT - ValueTuple behavior)
void MutabilityDemo()
{
    var point = (X: 1, Y: 2);

    point.X = 5; // ✔ allowed (ValueTuple is mutable struct)

    Console.WriteLine(point);

    point.X += 5; // ✔ also allowed

    Console.WriteLine(point);
}

/*
IMPORTANT CORRECTION:

C# modern tuples = ValueTuple

- They ARE mutable
- Fields like X, Y can be changed directly
- This is NOT the same as System.Tuple (which is immutable)
*/


// 5. ARITHMETIC WITH TUPLES
void ArithmeticWithTuples()
{
    var point = (X: 3, Y: 4);

    double slope = point.Y != 0
        ? (double)point.X / point.Y
        : double.NaN;

    Console.WriteLine($"Slope: {slope}");
}

/*
Tuples are just data containers.
You use their values in expressions.
*/


// 6. DECONSTRUCTION (VERY IMPORTANT)
void Deconstruction()
{
    var point = (X: 10, Y: 20);

    var (x, y) = point;

    Console.WriteLine(x);
    Console.WriteLine(y);
}

/*
Break tuple into variables.
Very commonly used in real code.
*/


// 7. RETURN FROM METHOD (REAL USE CASE)
(int Min, int Max) GetMinMax()
{
    return (5, 100);
}

void ReturnFromMethod()
{
    var result = GetMinMax();

    Console.WriteLine(result.Min);
    Console.WriteLine(result.Max);
}

/*
Most important real-world use of tuples:
return multiple values from a method
*/


// 8. EQUALITY
void EqualityDemo()
{
    var a = (1, 2);
    var b = (1, 2);
    var c = (2, 3);

    Console.WriteLine(a == b); // True
    Console.WriteLine(a == c); // False
}

/*
Tuple equality:
- compares values
- order matters
*/


// 9. REAL WORLD USE CASE
void RealWorldUseCase()
{
    var user = GetUser();

    Console.WriteLine($"Name: {user.Name}, Age: {user.Age}");

    var (name, age) = GetUser();

    Console.WriteLine(name);
    Console.WriteLine(age);
}

(string Name, int Age) GetUser()
{
    return ("Alice", 25);
}

/*
Tuples are great for:
- temporary data
- quick returns
- lightweight grouping

NOT for:
- complex domain models
- long-term data structures
*/