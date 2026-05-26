// StaticFieldDemo();
// StaticMethodDemo();
// SharedStateDemo();
// StaticConstructorDemo();
// StaticClassDemo();
// InstanceVsStaticDemo();


// =====================================================
// 1. STATIC FIELD
// =====================================================

void StaticFieldDemo()
{
    Player p1 = new();
    Player p2 = new();

    Console.WriteLine(Player.PlayerCount);  // 2
}

/*
static field: 
- Belongs to class itself, NOT object
- One shared copy
- All objects see same value
*/


// =====================================================
// 2. STATIC METHOD
// =====================================================

void StaticMethodDemo()
{
    double result = Calculator.Add(10, 20);

    Console.WriteLine(result);
}

/*
static method: 
- Call using class name
- No object required

Example:
- Math.Sqrt()
- Console.WriteLine()
*/


// =====================================================
// 3. SHARED STATE
// =====================================================

void SharedStateDemo()
{
    Counter c1 = new();
    Counter c2 = new();

    c1.Increment();
    c2.Increment();

    Console.WriteLine(Counter.Count);
}

/*
- static field shared across ALL objects
- Only one copy exists
*/


// =====================================================
// 4. STATIC CONSTRUCTOR
// =====================================================

void StaticConstructorDemo()
{
    Console.WriteLine(Database.Version);
}

/*
static constructor: 
- Runs automatically
- Only once
- Before first use
- No access modifier
- No parameters
*/


// =====================================================
// 5. STATIC CLASS
// =====================================================

void StaticClassDemo()
{
    Console.WriteLine(Utility.Double(5));

    // Utility util = new(); 
}

/*
static class: 
- Cannot create object
- Only static members allowed

Good for:
- helper methods
- utility functionality
*/


// =====================================================
// 6. INSTANCE VS STATIC
// =====================================================

void InstanceVsStaticDemo()
{
    Animal dog = new();

    dog.Name = "Dog";
    Console.WriteLine(dog.Name);

    Console.WriteLine(Animal.Kingdom);
}

/*
Instance member:
- Belongs to object
- Every object gets own copy

Static member:
- Belongs to class
- Shared globally
*/


// =====================================================
// TYPES
// =====================================================

class Player
{
    public static int PlayerCount;

    public Player()
    {
        PlayerCount++;
    }
}


static class Calculator
{
    public static double Add(double a, double b)
    {
        return a + b;
    }
}


class Counter
{
    public static int Count;


    public void Increment()
    {
        Count++;
    }
}


class Database
{
    public static string Version;


    static Database()
    {
        Version = "1.0";
    }
}


static class Utility
{
    public static int Double(int x)
    {
        return x * 2;
    }
}


class Animal
{
    public string Name = "";

    public static string Kingdom = "Animalia";
}