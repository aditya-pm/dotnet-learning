// BasicObjectInitializerDemo();
// ConstructorAndInitializerDemo();
// TargetTypedNewDemo();
// InitPropertyDemo();
// CollectionInitializerDemo();
// AnonymousTypeDemo();


// =====================================================
// 1. BASIC OBJECT INITIALIZER
// =====================================================

void BasicObjectInitializerDemo()
{
    User user = new()
    {
        Name = "Alice",
        Age = 22
    };

    Console.WriteLine(user.Name);
    Console.WriteLine(user.Age);
}

/*
Object initializer:
Create object + Assign properties

Syntax:
new Type()
{
    Property = value
}

Equivalent:
User user = new User();
user.Name = "Alice";
user.Age = 22;


1. Constructor runs
2. Property assignments run
3. Object ready
*/


// =====================================================
// 2. CONSTRUCTOR + OBJECT INITIALIZER
// =====================================================

void ConstructorAndInitializerDemo()
{
    Product product = new("Laptop")
    {
        Price = 50000
    };

    Console.WriteLine(product.Name);
    Console.WriteLine(product.Price);
}

/*
Constructor runs FIRST then object initializer

Equivalent:
Product p = new Product("Laptop");
p.Price = 50000;
*/


// =====================================================
// 3. TARGET TYPED NEW
// =====================================================

void TargetTypedNewDemo()
{
    User user = new()
    {
        Name = "Bob",
        Age = 25
    };

    Console.WriteLine(user.Name);
}

/*
Target typed new:
Compiler infers type

Instead of:
User user = new User()

Can write:
User user = new()

Useful with: Object initializers
*/


// =====================================================
// 4. INIT PROPERTY
// =====================================================

void InitPropertyDemo()
{
    Player player = new()
    {
        Name = "Max"
    };

    Console.WriteLine(player.Name);
    // player.Name = "John";
}

/*
init: Allows assignment ONLY during initialization

Works:
new Player()
{
    Name = "Max"
}

Does NOT work:
player.Name = "John";

Useful for: Immutable objects
*/


// =====================================================
// 5. COLLECTION INITIALIZER
// =====================================================

void CollectionInitializerDemo()
{
    List<string> names =
    [
        "Alice",
        "Bob",
        "Charlie"
    ];

    foreach (string name in names)
    {
        Console.WriteLine(name);
    }
}

/*
Collection initializer

Equivalent:
List<string> names = new();
names.Add("Alice");
names.Add("Bob");
names.Add("Charlie");

Compiler converts to Add() calls
*/


// =====================================================
// 6. ANONYMOUS TYPE
// =====================================================

void AnonymousTypeDemo()
{
    var user =
        new
        {
            Name = "Alice",
            Age = 22
        };

    Console.WriteLine(user.Name);
}

/*
Anonymous type: Compiler creates class automatically

Useful: Temporary grouped data

Properties become:
- Read only
- Type name hidden

Equivalent idea:

class HiddenCompilerType
{
    public string Name { get; }

    public int Age { get; }
}
*/


// =====================================================
// TYPES
// =====================================================

class User
{
    public string Name
    {
        get;
        set;
    } = "";

    public int Age
    {
        get;
        set;
    }
}


class Product
{
    public string Name
    {
        get;
    }


    public int Price
    {
        get;
        set;
    }


    public Product(string name)
    {
        Name = name;
    }
}


class Player
{
    public string Name
    {
        get;
        init;
    } = "";
}