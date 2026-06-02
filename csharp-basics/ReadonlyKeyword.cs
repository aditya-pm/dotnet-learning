// ReadonlyFieldDemo();
// ReadonlyStructDemo();
// ReadonlyStructMemberDemo();


// =====================================================
// OVERVIEW
// =====================================================

/*

The keyword "readonly" has multiple meanings in C#.
This is the source of most confusion.

Many developers first learn: readonly field

and assume every use of readonly means:
    "Can only be assigned in constructor"

This is NOT true.

The meaning depends on context.


CHEAT SHEET
-----------

readonly field
    ↓
Field can only be assigned:
- At declaration
- In constructor

readonly struct
    ↓
Struct instance cannot mutate state

readonly struct member
    ↓
Member promises not to mutate struct


IMPORTANT
- The same keyword is used for different purposes.
- Always ask: "What is readonly applied to?"
- because the meaning changes depending on whether it is applied to:
    - Field
    - Struct
    - Method
    - Property

*/


// =====================================================
// 1. READONLY FIELD
// =====================================================

void ReadonlyFieldDemo()
{
    Server s1 = new(8080);

    Console.WriteLine(s1.Port);

    // s1.Port = 5000; // Error
}

/*
Most common usage.

Example:
    private readonly ILogger _logger;

Meaning:
    The FIELD can only be assigned:
    - At declaration
    - In constructor

Example:

    public readonly int Port;

    public Server(int port)
    {
        Port = port;
    }


Unlike const:

Different objects can have different values.
    Server s1 = new(8080);
    Server s2 = new(5000);

----------------------------------------------------

IMPORTANT
readonly protects the FIELD,
not necessarily the object.

Example:
    private readonly List<string> _names = new();

Allowed:
    _names.Add("Alice");

Not Allowed:
    _names = new List<string>();

Meaning:
    The field must continue pointing
    to the same object.

*/


// =====================================================
// 2. READONLY STRUCT
// =====================================================

void ReadonlyStructDemo()
{
    Point p = new(10, 20);
    Console.WriteLine($"{p.X}, {p.Y}");
}

/*

Example:
    public readonly struct Point

Meaning:
    Instances of Point are immutable.

A readonly struct cannot mutate its state.

The compiler enforces this.

Mental Model:
    readonly struct
        ≈
    immutable value type

Example:

    public readonly struct Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

*/


// =====================================================
// 3. READONLY STRUCT MEMBER
// =====================================================

void ReadonlyStructMemberDemo()
{
    Distance d = new(3, 4);
    Console.WriteLine(d.Magnitude);
}

/*

This is the most confusing use.

Example:
    public readonly double Magnitude => ...

Many developers assume:
    readonly
        =
    constructor-only assignment

WRONG.
- Magnitude is not a field.
- Magnitude is a PROPERTY.

The property is already read-only because:
    There is no setter.

This:
    public readonly double Magnitude => ...

does NOT mean:
    "Magnitude can only be assigned in constructor"

Instead it means:
    "This property promises not to mutate the struct."

Equivalent mental model:
    C++ const member function

Example:
    public readonly int Value
    {
        get
        {
            return _value;
        }
    }

The readonly modifier applies to the generated
getter method, not to property storage.
*/


// =====================================================
// PROPERTY VS FIELD
// =====================================================

/*
FIELD
    public readonly int Value;

Meaning:
    Assigned only during initialization.

----------------------------------------------------

PROPERTY
    public int Value { get; }

Meaning:
    No setter exists.

----------------------------------------------------

PROPERTY
    public readonly int Value => _value;

Meaning:
    Getter cannot mutate struct state.

----------------------------------------------------

These are three different concepts.
*/


// =====================================================
// COMMON CONFUSION
// =====================================================

/*

Question:
    If I remove readonly here:
        public readonly double Magnitude => ...

can users assign to it?

Answer:
    NO.

Reason:
    There is no setter.

This:
    public double Magnitude => ...

is already read-only.

The readonly keyword is unrelated to assignability in this case.

It only affects whether the getter is allowed to mutate the struct.

*/



// =====================================================
// TYPES
// =====================================================

class Server
{
    public readonly int Port;

    public Server(int port)
    {
        Port = port;
    }
}

public readonly struct Point
{
    public int X { get; }
    public int Y { get; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}

public struct Distance
{
    private double _x;
    private double _y;

    public Distance(double x, double y)
    {
        _x = x;
        _y = y;
    }

    public readonly double Magnitude =>
        Math.Sqrt(_x * _x + _y * _y);
}

public struct Counter
{
    private int _value;

    public readonly int Value
    {
        get
        {
            return _value;

            // _value++; // Error
        }
    }
}