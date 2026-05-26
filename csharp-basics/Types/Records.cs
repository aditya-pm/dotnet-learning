// BasicRecordDemo();
// ValueEqualityDemo();
ImmutabilityDemo();
// WithExpressionDemo();
// RecordClassVsClassDemo();
// RecordStructDemo();
// MethodDemo();


// =====================================================
// 1. BASIC RECORD
// =====================================================

void BasicRecordDemo()
{
    Person person = new("Alice", 22);

    Console.WriteLine(person.Name);
    Console.WriteLine(person.Age);
    Console.WriteLine(person);
}

/*
- record is short for: record class
- Reference type
- Primary constructor syntax:
  record Person(string Name, int Age)

Compiler creates:
- Properties
- Constructor
- ToString()
- Equality behavior
*/


// =====================================================
// 2. VALUE EQUALITY
// =====================================================

void ValueEqualityDemo()
{
    Person2 p1 = new("Alice", 22);
    Person2 p2 = new("Alice", 22);

    Console.WriteLine(p1 == p2);
}

/*
Record equality: compares values
Output:
True

Class equality: compares references
Default output:
False
*/


// =====================================================
// 3. IMMUTABILITY
// =====================================================

void ImmutabilityDemo()
{
    Person3 person = new("Alice", 22);

    Console.WriteLine(person.Name);
    // person.Name = "Bob";  // Init-only property or indexer 'Person3.Name' can only be assigned in an object initializer, or on 'this' or 'base' in an instance constructor or an 'init' accessor.
}

/*
Primary constructor record:
- Properties become:
  - init only
  Can assign: object creation
  - Cannot assign: later

Approximate idea:

public string Name
{
    get;
    init;
}
*/


// =====================================================
// 4. WITH EXPRESSION
// =====================================================

void WithExpressionDemo()
{
    Point point1 = new(5, 10);

    Point point2 = point1 with
    {
        Y = 20
    };


    Console.WriteLine(point1);
    Console.WriteLine(point2);
}

/*
with
- Copies object
- Changes selected values
- Original unchanged
*/


// =====================================================
// 5. RECORD VS CLASS
// =====================================================

void RecordClassVsClassDemo()
{
    UserClass u1 = new("Alice");
    UserClass u2 = new("Alice");
    Console.WriteLine(u1 == u2);

    UserRecord r1 = new("Alice");
    UserRecord r2 = new("Alice");
    Console.WriteLine(r1 == r2);
}

/*
Class: Reference equality
Output: False

Record: Value equality
Output: True
*/


// =====================================================
// 6. RECORD STRUCT
// =====================================================

void RecordStructDemo()
{
    Coordinate c1 = new(1, 2);
    Coordinate c2 = c1;

    c2.X = 50;

    Console.WriteLine(c1.X);
    Console.WriteLine(c2.X);
}

/*
- record struct: Value type
- Struct semantics + record features:
- value equality
- ToString()
- primary constructor
- convenience syntax
*/


// =====================================================
// 7. METHODS
// =====================================================

void MethodDemo()
{
    Rectangle rect = new(5, 4);
    Console.WriteLine(rect.Area());
}

/*
Records can contain:
- Methods
- Properties
- Constructors

Like classes
*/


// =====================================================
// TYPES
// =====================================================

record Person(string Name, int Age);


record Person2(string Name, int Age);


record Person3(string Name, int Age);


record Point(int X, int Y);


class UserClass
{
    public string Name;

    public UserClass(string name)
    {
        Name = name;
    }
}


record UserRecord(string Name);


record struct Coordinate(int X, int Y);


record Rectangle(int Width, int Height)
{
    public int Area()
    {
        return Width * Height;
    }
}