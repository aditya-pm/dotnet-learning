// BasicInheritanceDemo();
// ConstructorInheritanceDemo();
// ProtectedDemo();
// BaseKeywordDemo();
// IsAConceptDemo();


// =====================================================
// 1. BASIC INHERITANCE
// =====================================================

void BasicInheritanceDemo()
{
    Dog dog = new();

    dog.Name = "Buddy";

    dog.Eat();
    dog.Bark();
}

/*
Inheritance: create specialized class from existing class

Syntax:
class Dog : Animal

Dog inherits:
- Fields
- Properties
- Methods
from Animal
*/


// =====================================================
// 2. CONSTRUCTOR INHERITANCE
// =====================================================

void ConstructorInheritanceDemo()
{
    Dog2 dog = new("Max");

    Console.WriteLine(dog.Name);
}

/*
Base constructor runs first, then derived constructor

Syntax:
: base(...)

Calls parent/base class constructor

Example:

class Dog : Animal
{
    public Dog(string name)
        : base(name)
    {

    }
}


Conceptually similar to:
Java: super(...)
C++: Parent(...)

Example:

class Dog : public Animal
{
public:

    Dog(string name)
        : Animal(name)
    {

    }
}


Important: This is NOT C++ member initializer list

C++:

Car(int speed)
    : speed(speed)

initializes member variables


C#:

public Dog(string name)
    : base(name)

calls constructor only


Constructor chaining:
base(...)
- parent constructor

this(...)
- another constructor in same class


Common error:
If parent has NO parameterless constructor:

class Animal
{
    public Animal(string name)
    {

    }
}

This fails:
class Dog : Animal
{
    public Dog()
    {

    }
}

Compile error:
Animal does not contain constructor that takes 0 arguments

Reason:
Compiler automatically tries:
base()


If parent requires parameters:

Must explicitly call:

public Dog()
    : base("Buddy")
{

}


Construction order:
1. Parent constructor runs
2. Child constructor runs

Child constructor body NEVER runs first

Reason:
Parent part of object must exist before child part can be created

Compare:

C++:
Must use parent constructor in member initializer list

Dog()
    : Animal("Buddy")
{

}

This DOES NOT work:
Dog()
{
    Animal("Buddy");
}

Creates temporary object
Does NOT initialize parent


Java:
Dog()
{
    super("Buddy");
}

Important: super(...) MUST be first statement

This fails:
Dog()
{
    Console.WriteLine("Hello");

    super("Buddy");
}

Compiler error

Java internally ensures:
    Parent constructor runs
            ↓
    Parent finishes
            ↓
    Child constructor continues


Rule:
Child constructor MUST ensure parent constructor executes first
*/


// =====================================================
// 3. PROTECTED
// =====================================================

void ProtectedDemo()
{
    Dog3 dog = new();

    dog.SetEnergy(100);
    dog.ShowEnergy();
}

/*
protected

Accessible:
- current class
- derived classes

Not accessible outside
*/


// =====================================================
// 4. BASE KEYWORD
// =====================================================

void BaseKeywordDemo()
{
    Dog4 dog = new();

    dog.Show();
}

/*
base:
- Access base class member
- Useful when overriding or extending behavior
*/


// =====================================================
// 5. IS-A RELATIONSHIP
// =====================================================

void IsAConceptDemo()
{
    Dog dog = new();

    Console.WriteLine(dog is Animal);
}

/*
Inheritance models:
IS-A relationship
- Dog IS-A Animal
- Cat IS-A Animal

Bad example:
- Engine : Car
Engine is NOT a Car, should be composition
*/


// =====================================================
// TYPES
// =====================================================

class Animal
{
    public string Name = "";

    public void Eat()
    {
        Console.WriteLine("Eating");
    }
}


class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine("Woof");
    }
}


class Animal2
{
    public string Name;

    public Animal2(string name)
    {
        Name = name;
    }
}


class Dog2 : Animal2
{
    public Dog2(string name)
        : base(name)
    {

    }
}


class Animal3
{
    protected int Energy;

    public void SetEnergy(int energy)
    {
        Energy = energy;
    }
}


class Dog3 : Animal3
{
    public void ShowEnergy()
    {
        Console.WriteLine(Energy);
    }
}


class Animal4
{
    public string Name = "Animal";
}


class Dog4 : Animal4
{
    public void Show()
    {
        Console.WriteLine(base.Name);
    }
}