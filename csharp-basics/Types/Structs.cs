// BasicStructDemo();
// CopyBehaviorDemo();
// ConstructorDemo();
// PropertyDemo();
// MethodDemo();
// ClassVsStructDemo();
// MutabilityDemo();
// ReadOnlyStructDemo();


// =====================================================
// 1. BASIC STRUCT
// =====================================================

void BasicStructDemo()
{
    Point point = new();

    point.X = 5;
    point.Y = 10;

    Console.WriteLine(point.X);
    Console.WriteLine(point.Y);
}

/*
Struct:
- Custom value type
- Similar to class

Difference:
- Struct = value type
- Class = reference type
- Structs copied on assignment, classes copy references

Can contain:
- Fields
- Methods
- Constructors
- Properties
*/


// =====================================================
// 2. COPY BEHAVIOR
// =====================================================

void CopyBehaviorDemo()
{
    Point2 p1 = new();
    p1.X = 10;

    Point2 p2 = p1;
    p2.X = 50;

    Console.WriteLine(p1.X);
    Console.WriteLine(p2.X);
}

/*
Structs copy values
p2 = p1
- Creates copy
- Independent objects (values)

Output:
10
50
*/


// =====================================================
// 3. CONSTRUCTORS
// =====================================================

void ConstructorDemo()
{
    Point3 point = new(5, 10);

    Console.WriteLine(point.X);
    Console.WriteLine(point.Y);
}

/*
Struct constructors work similar to classes
Must initialize all fields
*/


// =====================================================
// 4. PROPERTIES
// =====================================================

void PropertyDemo()
{
    Point4 point = new();

    point.X = 10;
    point.Y = 20;

    Console.WriteLine(point.Sum);
}

/*
Properties work normally
Structs support:
- get
- set
- computed properties
*/


// =====================================================
// 5. METHODS
// =====================================================

void MethodDemo()
{
    Point5 point = new(3, 4);
    Console.WriteLine(point.DistanceFromOrigin());
}

/*
Structs support methods like classes
*/


// =====================================================
// 6. CLASS VS STRUCT
// =====================================================

void ClassVsStructDemo()
{
    PositionStruct s1 = new();
    s1.X = 5;

    PositionStruct s2 = s1;
    s2.X = 100;

    Console.WriteLine(s1.X);
    Console.WriteLine(s2.X);

    PositionClass c1 = new();
    c1.X = 5;

    PositionClass c2 = c1;
    c2.X = 100;

    Console.WriteLine(c1.X);
    Console.WriteLine(c2.X);
}

/*
Struct:
- Copy semantics
- Output:
    5
    100

Class:
- Reference semantics
- Output:
    100
    100
*/


// =====================================================
// 7. MUTABILITY
// =====================================================

void MutabilityDemo()
{
    Point6 point = new(5, 10);
    point.X = 50;

    Console.WriteLine(point.X);
}

/*
- Structs are mutable unless designed otherwise
- Can modify fields like classes
- Mutable structs can be surprising, .NET often prefers immutable structs
*/


// =====================================================
// 8. READONLY STRUCT
// =====================================================

void ReadOnlyStructDemo()
{
    ImmutablePoint point = new(5, 10);

    Console.WriteLine(point.X);
    // point.X = 20;
}

/*
readonly struct
- Applies readonly to entire struct

Compiler guarantees:
- Instance methods cannot modify struct state

Example:

public void Move()
{
    X++; // compile error
}


Benefits:

1. Compiler guarantees:
   Prevents accidental mutation

2. Optimization opportunities:
   Structs copy frequently
   Compiler can avoid some defensive copies

3. Design intent
   Communicates:
   "This value type should not change after creation"

Note:
- If properties already only have getters:

  public int X { get; }

  public int Y { get; }

  Struct may already behave immutably

  readonly struct mainly adds:
    - compiler guarantees
    - optimization opportunities
    - clearer intent
*/


// =====================================================
// TYPES
// =====================================================

struct Point
{
    public int X;

    public int Y;
}


struct Point2
{
    public int X;
}


struct Point3
{
    public int X;
    public int Y;


    public Point3(int x, int y)
    {
        X = x;
        Y = y;
    }
}


struct Point4
{
    public int X
    {
        get;
        set;
    }

    public int Y
    {
        get;
        set;
    }


    public int Sum
    {
        get
        {
            return X + Y;
        }
    }
}


struct Point5
{
    public int X;
    public int Y;

    public Point5(int x, int y)
    {
        X = x;
        Y = y;
    }


    public double DistanceFromOrigin()
    {
        return Math.Sqrt(X * X + Y * Y);
    }
}


struct PositionStruct
{
    public int X;
}


class PositionClass
{
    public int X;
}


struct Point6
{
    public int X;
    public int Y;

    public Point6(int x, int y)
    {
        X = x;
        Y = y;
    }
}


readonly struct ImmutablePoint
{
    public int X
    {
        get;
    }

    public int Y
    {
        get;
    }


    public ImmutablePoint(int x, int y)
    {
        X = x;
        Y = y;
    }
}