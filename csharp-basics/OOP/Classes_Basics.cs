// ObjectCreation();
// FieldsDemo();
// MethodsDemo();
// ConstructorDemo();
// ConstructorOverloadingDemo();
// ThisKeywordDemo();
// ObjectStateDemo();
// ReferenceTypeDemo();
// ToStringDemo();


// =====================================================
// 1. OBJECT CREATION
// =====================================================

void ObjectCreation()
{
    Car car = new();
    Console.WriteLine(car);
}

/*
Class:
- Blueprint/template for objects

Object:
- Instance created from class

new:
1. Allocates memory
2. Creates object
3. Runs constructor

Console.WriteLine(object) internally calls: object.ToString()
Default behavior: Print typename
*/


// =====================================================
// 2. FIELDS
// =====================================================

void FieldsDemo()
{
    Car2 honda = new();

    honda.Brand = "Honda";
    honda.Speed = 80;

    Console.WriteLine(honda.Brand);
    Console.WriteLine(honda.Speed);
}

/*
Field:
- Variable inside class
- Stores object state/data
-Each object gets its own copy
*/


// =====================================================
// 3. METHODS
// =====================================================

void MethodsDemo()
{
    Car3 car = new();

    Console.WriteLine(car.Speed);
    car.Accelerate();
    Console.WriteLine(car.Speed);
    car.Brake();
    Console.WriteLine(car.Speed);
}

/*
Method:
- Function inside class
- Defines behavior
- Methods can directly access fields
*/


// =====================================================
// 4. CONSTRUCTORS
// =====================================================

void ConstructorDemo()
{
    Car4 car = new("Honda", 80);

    Console.WriteLine(car.Brand);
    Console.WriteLine(car.Speed);
}

/*
Constructor: Special method

Rules:
1. Same name as class
2. No return type
3. Automatically runs when object created
*/


// =====================================================
// 5. CONSTRUCTOR OVERLOADING
// =====================================================

void ConstructorOverloadingDemo()
{
    Car5 car1 = new();
    Car5 car2 = new("Honda");
    Car5 car3 = new("Toyota", 100);

    Console.WriteLine(car1.Brand);
    Console.WriteLine(car2.Brand);
    Console.WriteLine(car3.Brand);
}

/*
Constructor overloading: Multiple constructors, Different parameter lists
*/


// =====================================================
// 6. THIS KEYWORD
// =====================================================

void ThisKeywordDemo()
{
    Car6 car = new("Honda", 120);

    Console.WriteLine(car.Brand);
    Console.WriteLine(car.Speed);
}

/*
this: refers to current object

Useful when parameter
names match field names
*/


// =====================================================
// 7. OBJECT STATE
// =====================================================

void ObjectStateDemo()
{
    Car7 car1 = new();
    Car7 car2 = new();

    car1.Speed = 80;
    car2.Speed = 120;

    Console.WriteLine(car1.Speed);
    Console.WriteLine(car2.Speed);
}

/*
Each object has independent state
Object fields belong to that object
*/


// =====================================================
// 8. REFERENCE TYPES
// =====================================================

void ReferenceTypeDemo()
{
    Car8 car1 = new();
    car1.Speed = 100;

    Car8 car2 = car1;
    car2.Speed = 200;

    Console.WriteLine(car1.Speed);
    Console.WriteLine(car2.Speed);
}

/*
Classes are reference types, car1 and car2 refer to same object
*/


// =====================================================
// 9. TOSTRING
// =====================================================

void ToStringDemo()
{
    Car9 car = new("Honda", 80);
    Console.WriteLine(car);
}

/*
- Can customize object printing
 -Override ToString()
*/


// =====================================================
// TYPES
// =====================================================

class Car
{

}


class Car2
{
    public string Brand = "";
    public int Speed;
}


class Car3
{
    public int Speed;

    public void Accelerate()
    {
        Speed += 10;
    }

    public void Brake()
    {
        Speed -= 5;
    }
}


class Car4
{
    public string Brand;
    public int Speed;

    public Car4(string brand, int speed)
    {
        Brand = brand;
        Speed = speed;
    }
}


class Car5
{
    public string Brand;
    public int Speed;

    public Car5()
    {
        Brand = "Unknown";
        Speed = 0;
    }

    public Car5(string brand)
    {
        Brand = brand;
        Speed = 0;
    }

    public Car5(string brand, int speed)
    {
        Brand = brand;
        Speed = speed;
    }
}


class Car6
{
    public string Brand;
    public int Speed;

    public Car6(string Brand, int Speed)
    {
        this.Brand = Brand;
        this.Speed = Speed;
    }
}


class Car7
{
    public int Speed;
}


class Car8
{
    public int Speed;
}


class Car9
{
    public string Brand;
    public int Speed;

    public Car9(string brand, int speed)
    {
        Brand = brand;
        Speed = speed;
    }

    public override string ToString()
    {
        return $"Brand={Brand}, Speed={Speed}";
    }
}