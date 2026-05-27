// BasicTryCatchDemo();
// MultipleCatchDemo();
// FinallyDemo();
// ThrowDemo();
// CustomExceptionDemo();
// ExceptionHierarchyDemo();
// StackUnwindingDemo();
RethrowDemo();
// ExceptionFilterDemo();


// =====================================================
// 1. BASIC TRY CATCH
// =====================================================

void BasicTryCatchDemo()
{
    try
    {
        int a = 10;
        int b = 0;

        Console.WriteLine(a / b);
    }
    catch (DivideByZeroException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

/*
Exception: Runtime error object

Example:
DivideByZeroException

Flow:
try
↓
Exception happens
↓
Jump to matching catch, program continues
*/


// =====================================================
// 2. MULTIPLE CATCH BLOCKS
// =====================================================

void MultipleCatchDemo()
{
    try
    {
        string? text = null;
        Console.WriteLine(text.Length);
    }
    catch (NullReferenceException ex)
    {
        Console.WriteLine("Null problem");
    }
    catch (Exception ex)
    {
        Console.WriteLine("General problem");
    }
}

/*
- Specific catches first
- General catches later

Exception: Base class for most exceptions
*/


// =====================================================
// 3. FINALLY
// =====================================================

void FinallyDemo()
{
    try
    {
        Console.WriteLine("Try");
    }
    finally
    {
        Console.WriteLine("Cleanup");
    }
}

/*
finally: Always executes
Useful: 
- File cleanup
- Database cleanup
- Network cleanup
*/


// =====================================================
// 4. THROW
// =====================================================

void ThrowDemo()
{
    try
    {
        ValidateAge(-5);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

/*
throw: Create exception manually
Useful: 
- Invalid state
- Bad arguments
- Business rules
*/


// =====================================================
// 5. CUSTOM EXCEPTION
// =====================================================

void CustomExceptionDemo()
{
    try
    {
        Withdraw(5000);
    }
    catch (InsufficientFundsException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

/*
Custom exceptions: Represent domain problems

Example:
- Banking
- Inventory
- Authentication
*/


// =====================================================
// 6. EXCEPTION HIERARCHY
// =====================================================

void ExceptionHierarchyDemo()
{
    try
    {
        throw new DivideByZeroException();
    }
    catch (ArithmeticException)
    {
        Console.WriteLine("Arithmetic");
    }
}

/*
Exception hierarchy:

Exception
    ↓
SystemException
    ↓
ArithmeticException
    ↓
DivideByZeroException

Can catch parent types
*/


// =====================================================
// 7. STACK UNWINDING
// =====================================================

void StackUnwindingDemo()
{
    try
    {
        MethodA();
    }
    catch
    {
        Console.WriteLine("Handled");
    }
}

/*
Call stack:
MethodA()
↓
MethodB()
↓
MethodC()
↓
Exception

- Stack unwinds upward until handler found
*/


// =====================================================
// 8. RETHROW
// =====================================================

void RethrowDemo()
{
    try
    {
        MethodX();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.StackTrace);
    }
}

/*
Sometimes exception is caught, but current code cannot handle it
Then, we need to send exceptin upward

Example:
MethodA()
    ↓
MethodB()
    ↓
MethodC()
    ↓
Exception occurs

MethodB catches exception

Decides:
"I cannot handle this"
Send upward

Option 1:
throw;

Meaning:
"Continue throwing ORIGINAL exception"
Original throw location preserved

Example:
MethodC()
{
    throw new Exception("Boom");
}

MethodB()
{
    try
    {
        MethodC();
    }
    catch
    {
        throw;
    }
}

Stack trace roughly:
MethodC()
    ↓
MethodB()
    ↓
MethodA()

Useful for debugging: Can see where problem ACTUALLY started


Option 2:
throw ex;

Meaning:
"Throw exception AGAIN from HERE"

Example:
MethodB()
{
    try
    {
        MethodC();
    }
    catch (Exception ex)
    {
        throw ex;
    }
}

Stack trace roughly:
MethodB()
    ↓
MethodA()

MethodC disappears

Debugger now thinks: Exception started in MethodB, actual origin lost


Rule:
throw;
- Preserve original error information

throw ex;
- Loses original throw location
- Usually avoid


NOTE:
- In Java:
  throw ex;
  preserves original stack trace
  Same exception object re-thrown

- In C#:
  throw;
  preserves original stack trace
  throw ex;
  resets stack trace
  Makes exception appear to originate from current location

- In C++:
  throw;
  re-throws current exception preserving original exception
  throw ex;
  throws exception object again
  Can create copy / slicing issues
  Not equivalent to C# throw ex;
*/
    

// =====================================================
// 9. EXCEPTION FILTER
// =====================================================

void ExceptionFilterDemo()
{
    try
    {
        throw new Exception("Database");
    }
    catch (Exception ex)
        when (ex.Message.Contains("Database"))
    {
        Console.WriteLine("Database issue");
    }
}

/*
when:
- Extra condition
- Catch only matching exceptions
*/


// =====================================================
// TYPES
// =====================================================

void ValidateAge(int age)
{
    if (age < 0)
    {
        throw new ArgumentException(
            "Age cannot be negative");
    }
}


void Withdraw(int amount)
{
    int balance = 1000;

    if (amount > balance)
    {
        throw new InsufficientFundsException(
            "Not enough money");
    }
}


void MethodA()
{
    MethodB();
}


void MethodB()
{
    MethodC();
}


void MethodC()
{
    throw new Exception("Boom");
}


void MethodX()
{
    MethodY();
}


void MethodY()
{
    try
    {
        MethodZ();
    }
    catch
    {
        throw;
    }
}


void MethodZ()
{
    throw new Exception("Boom");
}


class InsufficientFundsException
    : Exception
{
    public InsufficientFundsException(
        string message)
        : base(message)
    {

    }
}
