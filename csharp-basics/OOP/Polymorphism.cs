// MethodOverloadingDemo();
// MethodHidingDemo();
// VirtualOverrideDemo();
// RuntimeDispatchDemo();
// AbstractDemo();
// SealedOverrideDemo();


// =====================================================
// 1. METHOD OVERLOADING
// =====================================================

void MethodOverloadingDemo()
{
    Calculator calc = new();

    Console.WriteLine(calc.Add(5, 10));
    Console.WriteLine(calc.Add(2.5, 3.5));
}

/*
Compile-time polymorphism:
- Same method name, different parameters
- Compiler chooses method based on arguments
*/


// =====================================================
// 2. METHOD HIDING
// =====================================================

void MethodHidingDemo()
{
    Parent parent = new Child();
    parent.Show();

    Child child = new();
    child.Show();
}

/*
new keyword:
- Hides inherited member
- Creates another method
- Parent method still exists
- Child method also exists
- Method hiding uses: Compile-time dispatch


Example:
Parent parent = new Child();
parent.Show();

Calls: Parent.Show()

Reason:
Reference type decides
Reference type: Parent
Actual object: Child


Example:
Child child = new();
child.Show();

Calls: Child.Show()

Reference type: Child


Important:
new keyword NOT mandatory

Without:
public void Show()

Compiler warning:
- "Member hides inherited member"
- Behavior remains SAME


new only:
- removes warning
- makes intent explicit
- tells compiler: "Yes, hiding is intentional"


Difference from overriding:
Method hiding:
Reference type decides

Parent parent = new Child();
parent.Show();
    ↓
Parent.Show()


Method overriding:
Actual object decides

Parent parent = new Child();
parent.Show();
    ↓
Child.Show()


Overriding requires:
- virtual
- override


Example:
class Parent
{
    public virtual void Show()
    {

    }
}


class Child : Parent
{
    public override void Show()
    {

    }
}


Method hiding: Compile-time dispatch
Method overriding: Runtime dispatch

Method hiding: Creates another method
Method overriding: Replaces inherited behavior polymorphically


Compare C++:
Non-virtual:
Parent* p = new Child();

p->Show();
    ↓
Parent

Virtual:
virtual void Show();
↓
Child
*/


// =====================================================
// 3. VIRTUAL + OVERRIDE
// =====================================================

void VirtualOverrideDemo()
{
    Animal animal = new Dog();
    animal.Show();
}

/*
virtual: Allows overriding
override: Replaces parent behavior

- Runtime decides which method executes
- True polymorphism
*/


// =====================================================
// 4. RUNTIME DISPATCH
// =====================================================

void RuntimeDispatchDemo()
{
    Animal[] animals = {new Dog(), new Cat()};

    foreach (Animal animal in animals)
    {
        animal.MakeSound();
    }
}

/*
Runtime dispatch: Actual object decides

Dog object
    ↓
Dog.MakeSound()

Cat object
    ↓
Cat.MakeSound()
*/


// =====================================================
// 5. ABSTRACT
// =====================================================

void AbstractDemo()
{
    Shape shape = new Circle();
    shape.Draw();
}

/*
- abstract class cannot instantiate
- Forces derived classes to implement behavior
*/


// =====================================================
// 6. SEALED OVERRIDE
// =====================================================

void SealedOverrideDemo()
{
    Animal2 animal = new Dog2();
    animal.Show();
}

/*
sealed override stops further overriding
*/


// =====================================================
// TYPES
// =====================================================

class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }


    public double Add(double a, double b)
    {
        return a + b;
    }
}


class Parent
{
    public void Show()
    {
        Console.WriteLine("Parent");
    }
}


class Child : Parent
{
    public new void Show()
    {
        Console.WriteLine("Child");
    }
}


class Animal
{
    public virtual void Show()
    {
        Console.WriteLine("Animal");
    }


    public virtual void MakeSound()
    {
        Console.WriteLine("Animal sound");
    }
}


class Dog : Animal
{
    public override void Show()
    {
        Console.WriteLine("Dog");
    }


    public override void MakeSound()
    {
        Console.WriteLine("Woof");
    }
}


class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Meow");
    }
}


abstract class Shape
{
    public abstract void Draw();
}


class Circle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing circle");
    }
}


class Animal2
{
    public virtual void Show()
    {
        Console.WriteLine("Animal");
    }
}


class Dog2 : Animal2
{
    public sealed override void Show()
    {
        Console.WriteLine("Dog");
    }
}