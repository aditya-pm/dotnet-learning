// WhyGenericsDemo();
// GenericClassDemo();
// GenericMethodDemo();
// MultipleTypeParametersDemo();
// ConstraintsDemo();
// StructConstraintDemo();
// ClassConstraintDemo();
// NewConstraintDemo();
GenericInterfaceDemo();


// =====================================================
// 1. WHY GENERICS
// =====================================================

void WhyGenericsDemo()
{
    IntBox intBox = new();
    intBox.Value = 10;
    Console.WriteLine(intBox.Value);

    StringBox stringBox = new();
    stringBox.Value = "Hello";
    Console.WriteLine(stringBox.Value);
}

/*
Without generics: Duplicate code
IntBox
StringBox
DoubleBox
Etc

Generics:
Write once, reuse for many types
*/


// =====================================================
// 2. GENERIC CLASS
// =====================================================

void GenericClassDemo()
{
    Box<int> age = new();
    age.Value = 22;

    Box<string> name = new();
    name.Value = "Alice";

    Console.WriteLine(age.Value);
    Console.WriteLine(name.Value);
}

/*
T: Placeholder type

Box<T>
Means:
"Box works with any type"

Examples:
- Box<int>
- Box<string>
- Box<double>
*/


// =====================================================
// 3. GENERIC METHOD
// =====================================================

void GenericMethodDemo()
{
    Print<int>(5);
    Print<string>("Hello");
}

/*
Methods can also be generic:
T inferred automatically

Can write: Print(5)
Compiler infers: T = int
*/


// =====================================================
// 4. MULTIPLE TYPE PARAMETERS
// =====================================================

void MultipleTypeParametersDemo()
{
    Pair<string, int> user =
        new("Alice", 22);


    Console.WriteLine(user.First);
    Console.WriteLine(user.Second);
}

/*
Multiple generic parameters

Real example
Dictionary<TKey, TValue>
*/


// =====================================================
// 5. CONSTRAINTS
// =====================================================

void ConstraintsDemo()
{
    PrintName(
        new Person
        {
            Name = "Alice"
        });
}

/*
Constraint: Limits allowed types
where T : Interface

Compiler guarantees:
T supports interface methods
*/


// =====================================================
// 6. STRUCT CONSTRAINT
// =====================================================

void StructConstraintDemo()
{
    PrintStruct(5);
    PrintStruct(DateTime.Now);
}

/*
where T : struct
Only value types allowed
*/


// =====================================================
// 7. CLASS CONSTRAINT
// =====================================================

void ClassConstraintDemo()
{
    PrintReference("Hello");
}

/*
where T : class
Reference types only
*/


// =====================================================
// 8. NEW() CONSTRAINT
// =====================================================

void NewConstraintDemo()
{
    Player player = Create<Player>();
    Console.WriteLine(player);
}

/*
where T : new()
Constraint: T must have public parameterless constructor


Example:
T Create<T>()
    where T : new()
{
    return new T();
}


Question: Why needed?
Without constraint:
T Create<T>()
{
    return new T();
}

Compiler error
Reason: Compiler only knows: T = some unknown type

Could be:
Player
Monster
Database
Anything

What if type does NOT have:
Type()

Example:
class Monster
{
    public Monster(int hp)
    {

    }
}

Monster m = new Monster();

Compile error
Monster requires: Monster(int hp)

Compiler cannot guarantee: new T() works

new() constraint tells compiler: "Only allow T types
that support: new T()"

Example:
class Player
{

}

Compiler provides:
public Player()
{

}

Allowed:
Create<Player>()

Example:
class Monster
{
    public Monster(int hp)
    {

    }
}

NOT allowed:
Create<Monster>()

Reason:
Monster lacks: public Monster()
*/


// =====================================================
// 9. GENERIC INTERFACE
// =====================================================

void GenericInterfaceDemo()
{
    Repository<User> repo = new();

    repo.Add(
        new User()
        {
            Name = "Bob"
        });
}

/*
Generic interfaces:

Examples:
IEnumerable<T>
ICollection<T>
IComparable<T>

Very common in .NET
*/


// =====================================================
// TYPES
// =====================================================

void Print<T>(T value)
{
    Console.WriteLine(value);
}


void PrintName<T>(T item)
    where T : IHasName
{
    Console.WriteLine(item.Name);
}


void PrintStruct<T>(T value)
    where T : struct
{
    Console.WriteLine(value);
}


void PrintReference<T>(T value)
    where T : class
{
    Console.WriteLine(value);
}


T Create<T>()
    where T : new()
{
    return new T();
}


class IntBox
{
    public int Value;
}


class StringBox
{
    public string Value = "";
}


class Box<T>
{
    public T Value
    {
        get;
        set;
    }
}


class Pair<T1, T2>
{
    public T1 First
    {
        get;
        set;
    }

    public T2 Second
    {
        get;
        set;
    }


    public Pair(T1 first, T2 second)
    {
        First = first;
        Second = second;
    }
}


interface IHasName
{
    string Name
    {
        get;
    }
}


class Person : IHasName
{
    public string Name
    {
        get;
        set;
    }
}


class Player
{

}


interface IRepository<T>
{
    void Add(T item);
}


class Repository<T> :
    IRepository<T>
{
    public void Add(T item)
    {
        Console.WriteLine(item);
    }
}


class User
{
    public string Name
    {
        get;
        set;
    }
}