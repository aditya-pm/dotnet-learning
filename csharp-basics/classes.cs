// BASIC CLASS + OBJECT CREATION

/*
Class:
- Blueprint/template for creating objects

Object:
- Actual instance created from a class

new:
- Allocates memory
- Creates object
- Calls constructor
*/

Car myCar = new Car();
Console.WriteLine(myCar);  // by default Car.ToString() evaluates to the typename (Car)

// ----------------------------------------------------------------------------
// FIELDS

/*
Field:
- Variable inside class

Each object gets its own copy.

Object 1:
Brand = Honda
Speed = 80

Object 2:
Brand = Toyota
Speed = 100
*/

Car2 hondaCar = new Car2();
hondaCar.Brand = "Honda";
hondaCar.Speed = 80;
Console.WriteLine(hondaCar.Brand);
Console.WriteLine(hondaCar.Speed);

class Car
{
    
}

class Car2
{
    public string Brand = "";
    public int Speed;
}