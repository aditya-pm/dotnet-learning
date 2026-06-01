// BasicRecordDemo();
// ValueEqualityDemo();
// ImmutabilityDemo();
// WithExpressionDemo();
// RecordStructDemo();
// PositionalVsNominalDemo();
// DeconstructionDemo();
// RecordBodyDemo();


// =====================================================
// RECORDS IN THE TYPE SYSTEM
// =====================================================

/*
Types
│
├── Reference Types
│   ├── class
│   └── record class
│
└── Value Types
    ├── struct
    └── record struct


The most important distinction is:

Reference Semantics
vs
Value Semantics


-----------------------------------------------------
CLASS
-----------------------------------------------------

class Person

Reference Type

Assignment copies the reference:

Person p1 = new("Alice");
Person p2 = p1;

Both variables point to the same object.

Changing through one variable
affects the same object.


-----------------------------------------------------
STRUCT
-----------------------------------------------------

struct Point

Value Type

Assignment copies the value:

Point p1 = new(1, 2);
Point p2 = p1;

p2 becomes an independent copy.

Changing p2 does not affect p1.


-----------------------------------------------------
RECORDS
-----------------------------------------------------

Records do NOT change:

- Reference semantics
- Value semantics

Records ADD:

- Value equality
- Better ToString()
- with expressions
- Deconstruction
- Less boilerplate


-----------------------------------------------------
CLASS
-----------------------------------------------------

class Person

Assignment:
Copies reference

Equality:
Reference equality


-----------------------------------------------------
RECORD CLASS
-----------------------------------------------------

record Person

Assignment:
Copies reference

Equality:
Value equality


-----------------------------------------------------
STRUCT
-----------------------------------------------------

struct Point

Assignment:
Copies value

Equality:
No automatic ==


-----------------------------------------------------
RECORD STRUCT
-----------------------------------------------------

record struct Point

Assignment:
Copies value

Equality:
Value equality


CHEAT SHEET

Type            Assignment         Equality
------------------------------------------------
class           Reference          Reference
record class    Reference          Value
struct          Value              Manual
record struct   Value              Value


For ASP.NET Core:

Most common:
- record class (DTOs)

Occasional:
- class (Entities, Services)

Rare:
- record struct

Very rare:
- struct
*/


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
record is shorthand for: record class

Example:
record Person(string Name, int Age);

Compiler generates:
- Constructor
- Properties
- Equals()
- GetHashCode()
- ToString()
- Deconstruct()
- == and !=

Records are primarily designed
for data-centric types.
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
Output: True

Records compare values.

For normal classes:

Person p1 = new("Alice");
Person p2 = new("Alice");

p1 == p2

would be False because classes compare references.
*/


// =====================================================
// 3. IMMUTABILITY
// =====================================================

void ImmutabilityDemo()
{
    Person3 person = new("Alice", 22);

    Console.WriteLine(person.Name);

    // person.Name = "Bob";
}

/*
Positional records generate
init-only properties.

Equivalent idea:

public string Name
{
    get;
    init;
}

Can assign:
- During object creation

Cannot assign:
- Later

Note:

Records are NOT inherently immutable.

This is valid:

record Person
{
    public string Name { get; set; }
}
*/


// =====================================================
// 4. WITH EXPRESSIONS
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
with expression:
- Creates a copy
- Changes selected members

Original unchanged

Output:
Point { X = 5, Y = 10 }
Point { X = 5, Y = 20 }

Useful for immutable objects.
*/


// =====================================================
// 5. RECORD STRUCT
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
record struct: Value Type

Assignment copies the value.
Output:
1
50

c1 and c2 are independent copies.

This is called: Value Semantics

record struct also provides:
- Value equality
- ToString()
- with expressions
- Deconstruction
*/
    

// =====================================================
// 6. POSITIONAL VS NOMINAL RECORDS
// =====================================================

void PositionalVsNominalDemo()
{
    PersonPositional p1 = new("Alice", 22);

    PersonNominal p2 = new()
    {
        Name = "Alice",
        Age = 22
    };

    Console.WriteLine(p1);
    Console.WriteLine(p2);
}

/*
POSITIONAL RECORD
record Person(string Name, int Age);

Compiler generates:
- Constructor
- Properties
- Equality members
- ToString()
- Deconstruct()

Very common for DTOs.


NOMINAL RECORD
record Person
{
    public string Name { get; init; }
    public int Age { get; init; }
}

You define members yourself.

Useful when you need:
- Validation attributes
- Custom constructors
- Additional properties
- More complex logic
*/


// =====================================================
// 7. DECONSTRUCTION
// =====================================================

void DeconstructionDemo()
{
    Person person = new("Alice", 22);

    var (name, age) = person;

    Console.WriteLine(name);
    Console.WriteLine(age);
}

/*
Positional records automatically generate: Deconstruct()

Allows:
var (name, age) = person;

Output:
Alice
22
*/


// =====================================================
// 8. RECORD BODY
// =====================================================

void RecordBodyDemo()
{
    Product product = new("Laptop", 1000);

    Console.WriteLine(product.DisplayName);
}

/*
Records are still classes.

They can contain:
- Methods
- Properties
- Constructors
- Fields
- Static members

A record is not limited to storing data.
*/


// =====================================================
// 9. POSITIONAL RECORD EXPANSION
// =====================================================

/*
This:

record Person(string Name, int Age);

is approximately:

record Person
{
    public string Name { get; init; }
    public int Age { get; init; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    Compiler also generates:

    - Equals()
    - GetHashCode()
    - ToString()
    - Deconstruct()
    - == and !=
}

Positional records are mostly
syntax sugar that removes a lot
of boilerplate.
*/


// =====================================================
// TYPES
// =====================================================

record Person(string Name, int Age);

record Person2(string Name, int Age);

record Person3(string Name, int Age);

record Point(int X, int Y);

record struct Coordinate(int X, int Y);

record PersonPositional(string Name, int Age);

record PersonNominal
{
    public string Name { get; init; } = "";
    public int Age { get; init; }
}

record Product(string Name, decimal Price)
{
    public string DisplayName
        => $"{Name} - ${Price}";
}