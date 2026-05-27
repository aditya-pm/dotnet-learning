// BasicInterfaceDemo();
// InterfacePolymorphismDemo();
// MultipleInterfacesDemo();
// InterfaceVsAbstractDemo();
// UnrelatedClassesDemo();
// ExplicitInterfaceDemo();
// InterfacePropertyDemo();


// =====================================================
// 1. BASIC INTERFACE
// =====================================================

void BasicInterfaceDemo()
{
    Bird bird = new();
    bird.Fly();
}

/*
Interface: Defines contract
"If class implements interface, it MUST provide behavior"

Syntax:
interface IFlyable

Convention:
Prefix interfaces with I

Examples:
IDisposable
IEnumerable<T>
IComparable<T>


C++ comparison:
Pure abstract class pattern:
class IFlyable
{
public:

    virtual void Fly() = 0;

    virtual ~IFlyable() = default;
};


C# formalizes this pattern


Java comparison:
interface Flyable
{
    void fly();
}

class Bird implements Flyable

Very similar concept


C#:

class Bird : IFlyable
*/


// =====================================================
// 2. INTERFACE POLYMORPHISM
// =====================================================

void InterfacePolymorphismDemo()
{
    IFlyable flyer1 = new Bird();
    IFlyable flyer2 = new Airplane();

    flyer1.Fly();
    flyer2.Fly();
}

/*
Polymorphism:
- Interface reference
            ↓
  Different implementations

- Actual object decides method executed 
- Runtime dispatch


IFlyable flyer = new Bird();

flyer.Fly();
    ↓
Bird.Fly()


Similar to:
Animal animal = new Dog();  
animal.MakeSound();
*/


// =====================================================
// 3. MULTIPLE INTERFACES
// =====================================================

void MultipleInterfacesDemo()
{
    Duck duck = new();
    duck.Fly();
    duck.Swim();
}

/*
Classes: single inheritance only
class Dog : Animal

NOT allowed:
class Dog : Animal, Vehicle


Interfaces: multiple allowed
class Duck :
    IFlyable,
    ISwimmable


Useful when object has multiple capabilities


Java comparison:
class Duck
    implements Flyable, Swimmable


C++ comparison:
class Duck :
    public IFlyable,
    public ISwimmable

C++ allows:
Multiple inheritance


C#:
Single class inheritance + Multiple interfaces
*/


// =====================================================
// 4. INTERFACE VS ABSTRACT CLASS
// =====================================================

void InterfaceVsAbstractDemo()
{
    Dog dog = new();

    dog.Eat();
    dog.MakeSound();
}

/*
Abstract class:
Shared implementation + Contract

Interface:
Contract / capability


Abstract class example:
Animal
 ↓
Dog

Dog IS-A Animal


Interface example:
Bird, Airplane
    ↓
IFlyable

Bird CAN Fly
Airplane CAN Fly


IS-A
↓
Inheritance

CAN-DO
↓
Interface


Use abstract class when:
- Shared fields
- Shared state
- Shared methods
- Constructors
- Specialized classes

Use interface when:
- Unrelated classes share behavior
- Multiple capabilities
- Behavior contract


Examples:
Animal
 ↓
Dog
(Correct inheritance)

Engine
 ↓
Car
(Bad inheritance)

Engine IS NOT A Car, should use composition


Java comparison:
abstract class Animal
{
    String name;

    void eat()
    {

    }

    abstract void makeSound();
}

- Very similar to C#

Java interface:
interface Flyable
{
    void fly();
}


Modern Java: default methods allowed
Modern C#: default interface methods allowed


C++ comparison:
Abstract class:

class Animal
{
public:

    virtual void MakeSound() = 0;

    void Eat()
    {

    }
};


Interface style:
class IFlyable
{
public:

    virtual void Fly() = 0;
};


Rule of thumb:
Need shared state?
    ↓
Abstract class

Need unrelated classes to share behavior?
    ↓
Interface
*/


// =====================================================
// 5. UNRELATED CLASSES
// =====================================================

void UnrelatedClassesDemo()
{
    IFlyable[] flyers =
    {
        new Bird(),
        new Airplane()
    };


    foreach (IFlyable flyer in flyers)
    {
        flyer.Fly();
    }
}

/*
Bird and Airplane not related, no shared parent

Interface enables: Common behavior without inheritance

Real point of interfaces: Capability sharing without forcing hierarchy
*/


// =====================================================
// 6. EXPLICIT INTERFACE IMPLEMENTATION
// =====================================================

void ExplicitInterfaceDemo()
{
    Person person = new();
    IWorker worker = person;
    worker.Work();
    // person.Work(); // Error
}

/*
Explicit implementation:
void IWorker.Work()
{

}

Only accessible through interface reference

Useful when:
Multiple interfaces contain same method names

Java comparison: No equivalent


Java:
public void work()
{

}

Always directly accessible

Explicit interface implementation mostly C# specific feature
*/


// =====================================================
// 7. INTERFACE PROPERTIES
// =====================================================

void InterfacePropertyDemo()
{
    Person2 person = new();
    person.Name = "Alice";
    Console.WriteLine(person.Name);

    Product product = new("Laptop");

    Consoe.WriteLine(product.Name);
}

/*
Interfaces can define:
- Methods
- Properties
- Events
- Indexers

Interface property: Defines contract NOT storage


Example:

interface IHasName
{
    string Name
    {
        get;
    }
}


Meaning:
"Implementing type must provide readable Name property"

Implementation:

class Person : IHasName
{
    public string Name
    {
        get;
        set;
    }
}


Allowed:
Interface:
- string Name { get; }

Implementation:
- string Name { get; }
- string Name { get; set; }
- string Name { get; init; }

Reason:
Interface requires: Readable property
Implementation provides: Equal or more capability


NOT allowed:
Interface:
- string Name { get; set; }

Implementation:
- string Name { get; }

Compiler error: 
Interface required: Readable + writable
Implementation only provides: Readable


Init only contract:
Interface:
string Name
{
    get;
    init;
}

Allowed:
string Name
{
    get;
    init;
}

NOT allowed:
string Name
{
    get;
    set;
}

Reason:
Interface promised: Initialization only
set allows: Mutation anytime


Implementation must satisfy
interface contract


Implementation may use:
1. Manual property:
private string name = "";

public string Name
{
    get
    {
        return name;
    }

    set
    {
        name = value;
    }
}

2. Auto property:
public string Name
{
    get;
    set;
}

3. Computed property:
public string Name
{
    get
    {
        return firstName + " " + lastName;
    }
}


Interface requires behavior NOT implementation


C++ comparison:
C++ usually uses methods:
class IHasName
{
public:

    virtual string GetName() = 0;
};


C# property syntax:
string Name { get; }


Java comparison:
Java traditionally uses:
String getName();


C# property:
person.Name
Cleaner property syntax


Mental model:
Interface property
    ↓
Contract


Class property
    ↓
Implementation
*/


// =====================================================
// TYPES
// =====================================================

interface IFlyable
{
    void Fly();
}


class Bird : IFlyable
{
    public void Fly()
    {
        Console.WriteLine("Bird flying");
    }
}


class Airplane : IFlyable
{
    public void Fly()
    {
        Console.WriteLine("Airplane flying");
    }
}


interface ISwimmable
{
    void Swim();
}


class Duck :
    IFlyable,
    ISwimmable
{
    public void Fly()
    {
        Console.WriteLine("Duck flying");
    }

    public void Swim()
    {
        Console.WriteLine("Duck swimming");
    }
}


abstract class Animal
{
    public string Name = "";

    public void Eat()
    {
        Console.WriteLine("Eating");
    }


    public abstract void MakeSound();
}


class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Woof");
    }
}


interface IWorker
{
    void Work();
}


class Person : IWorker
{
    void IWorker.Work()
    {
        Console.WriteLine("Working");
    }
}

interface IHasName2
{
    string Name
    {
        get;
    }
}


class Person2 : IHasName2
{
    public string Name
    {
        get;
        set;
    } = "";
}


class Product : IHasName2
{
    private readonly string name;

    public Product(string name)
    {
        this.name = name;
    }

    public string Name
    {
        get
        {
            return name;
        }
    }
}