// ManualPropertyDemo();
// AutoPropertyDemo();
// ReadOnlyPropertyDemo();
// PrivateSetterDemo();
// ComputedPropertyDemo();
// ValidationDemo();


// =====================================================
// 1. MANUAL PROPERTIES
// =====================================================

void ManualPropertyDemo()
{
    Car car = new();

    car.Speed = 80;
    Console.WriteLine(car.Speed);
}

/*
Property:
- Controls access to data

get:
- Runs when reading property

set:
- Runs when assigning property

value:
- Special keyword inside setter
- Represents incoming value

Example:

car.Speed = 80;

Internally:

set
{
    speed = 80;
}

Console.WriteLine(car.Speed);

Internally:

get
{
    return speed;
}

Properties separate: Storage (field) from Access logic (property)
*/


// =====================================================
// 2. AUTO PROPERTIES
// =====================================================

void AutoPropertyDemo()
{
    Car2 car = new();

    car.Speed = 100;
    Console.WriteLine(car.Speed);
}

/*
Auto property:

- Compiler automatically creates hidden backing field
- Backing field = hidden storage variable

Code:

public int Speed { get; set; }

Mental model:

private int hiddenSpeed;

public int Speed
{
    get
    {
        return hiddenSpeed;
    }

    set
    {
        hiddenSpeed = value;
    }
}

(Not exact compiler output)

Useful approximation
*/


// =====================================================
// 3. READ ONLY PROPERTY
// =====================================================

void ReadOnlyPropertyDemo()
{
    Car3 car = new(120);

    Console.WriteLine(car.Speed);
    // car.Speed = 200;
}

/*
Getter only property:

public int Speed { get; }

Can assign:
- constructor
- inline initializer

Cannot assign:
- outside object

Example:

public int Speed { get; } = 100;


Compiler creates hidden backing field

Approximate idea:

private readonly int hiddenSpeed;

public int Speed
{
    get
    {
        return hiddenSpeed;
    }
}


Read only API

Looks similar to:

public readonly int Speed;


Difference:

readonly field:
- exposes storage directly
- harder to add logic later

Getter only property:
- exposes API layer
- implementation hidden
- can later add validation/logging/caching
without changing outside code


Example:

Version 1:

public int Speed { get; }


Later:

public int Speed
{
    get
    {
        Console.WriteLine("Reading speed");

        return speed;
    }
}

Outside code:

car.Speed

does not change

Properties preferred in modern C#
*/


// =====================================================
// 4. PRIVATE SETTER
// =====================================================

void PrivateSetterDemo()
{
    Car4 car = new();

    car.Accelerate();
    Console.WriteLine(car.Speed);
    // car.Speed = 1000;
}

/*
private set
- Readable outside object
- Writable only inside class

Good for: Object controls its own state
*/


// =====================================================
// 5. COMPUTED PROPERTY
// =====================================================

void ComputedPropertyDemo()
{
    Rectangle rect = new(5, 4);

    Console.WriteLine(rect.Area);
    rect.Width = 10;
    Console.WriteLine(rect.Area);
}

/*
Computed property:
- Value is NOT stored
- No hidden backing field exists
- Expression-bodied syntax: 
    public int Area => Width * Height;

    Equivalent:

    public int Area
    {
        get
        {
            return Width * Height;
        }
    }


Computed property IS still a getter

Difference:

Stored property:
- public int Speed { get; set; }
- Compiler creates hidden storage
- Approximate idea:
    private int hiddenSpeed;

    public int Speed
    {
        get
        {
            return hiddenSpeed;
        }

        set
        {
            hiddenSpeed = value;
        }
    }


Computed property:
public int Area
{
    get
    {
        return Width * Height;
    }
}

- Getter computes value
- Nothing stored
- Example:
    rect.Width = 5;
    rect.Height = 4;

    rect.Area

    Getter runs:
    5 * 4

    returns:
    20


    rect.Width = 10;
    rect.Area

    Getter runs again:
    10 * 4

    returns:
    40

- computed property calculates value every access
*/


// =====================================================
// 6. VALIDATION + ENCAPSULATION
// =====================================================

void ValidationDemo()
{
    Person person = new();

    person.Age = 25;
    Console.WriteLine(person.Age);

    person.Age = -50;
    Console.WriteLine(person.Age);
}

/*
Encapsulation:
- Hide internal details
- Protect object state
- Validation prevents invalid data
- Without validation:
    person.Age = -100;
    Could happen
- Object protects itself
*/


// =====================================================
// TYPES
// =====================================================

class Car
{
    private int speed;

    public int Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }
}


class Car2
{
    public int Speed { get; set; }
}


class Car3
{
    public int Speed
    {
        get;
    }

    public Car3(int speed)
    {
        Speed = speed;
    }
}


class Car4
{
    public int Speed
    {
        get;
        private set;
    }

    public void Accelerate()
    {
        Speed += 10;
    }
}


class Rectangle
{
    public int Width
    {
        get;
        set;
    }

    public int Height
    {
        get;
        set;
    }

    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public int Area => Width * Height;
}


class Person
{
    private int age;

    public int Age
    {
        get
        {
            return age;
        }

        set
        {
            if (value >= 0)
            {
                age = value;
            }
        }
    }
}