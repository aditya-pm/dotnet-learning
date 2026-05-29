// BasicDisposableDemo();
// UsingStatementDemo();
// UsingDeclarationDemo();
// CustomDisposableDemo();


// =====================================================
// OVERVIEW
// =====================================================

/*
IDisposable
Purpose: Release resources immediately

Examples of resources:
- Files
- Database connections
- Network sockets
- Streams


Important:

Memory
↓
Garbage Collector

Resources
↓
Dispose()


- Garbage Collector frees memory
- Garbage Collector does NOT guarantee immediate release of resources
- Dispose() does
*/


// =====================================================
// 1. BASIC IDISPOSABLE
// =====================================================

void BasicDisposableDemo()
{
    FileStream stream = File.OpenRead("data.txt");
    Console.WriteLine(stream.Length);
    stream.Dispose();
}

/*
IDisposable
Interface for objects that own resources

Method:
Dispose()

Purpose:
Release resources immediately

Manual cleanup:
stream.Dispose();

Works
But easy to forget
*/


// =====================================================
// 2. USING STATEMENT
// =====================================================

void UsingStatementDemo()
{
    using (FileStream stream = File.OpenRead("data.txt"))
    {
        Console.WriteLine(stream.Length);
    }
}

/*
using statement

Automatically calls:
Dispose()
when block ends


Roughly equivalent to:

FileStream stream = File.OpenRead("data.txt");

try
{
    ...
}
finally
{
    stream.Dispose();
}


Important:
Dispose() runs even if an exception occurs
*/


// =====================================================
// 3. USING DECLARATION
// =====================================================

void UsingDeclarationDemo()
{
    using FileStream stream = File.OpenRead("data.txt");
    Console.WriteLine(stream.Length);
}

/*
Modern syntax

Instead of:
using (...)
{
    ...
}


Can write:
using FileStream stream = File.OpenRead(...);


Dispose()
called automatically when CURRENT scope ends. In the example above, 
Dispose is called when we exit the method's scope.


using statement
using (...)
{
    ...
}
↓
Dispose at end of using block

using declaration
using Resource r = ...;
↓
Dispose at end of current scope
*/


// =====================================================
// 4. CUSTOM IDISPOSABLE
// =====================================================

void CustomDisposableDemo()
{
    using Resource resource = new();
    resource.Use();
}

/*
Any class can implement:
IDisposable

Then it can be used with:
using


Useful when class owns:

- Files
- Sockets
- Database connections
- Other disposable objects
*/


// =====================================================
// TYPES
// =====================================================

class Resource : IDisposable
{
    public void Use()
    {
        Console.WriteLine("Using resource");
    }

    public void Dispose()
    {
        Console.WriteLine("Resource cleaned up");
    }
}


/*
Without using:

FileStream stream =
    File.OpenRead("data.txt");

...

stream.Dispose();


You must remember cleanup


With using:

using FileStream stream =
    File.OpenRead("data.txt");

...


Compiler guarantees: Dispose()


Rule:
If type implements IDisposable
↓
Consider using: using


Common examples:
- FileStream
- StreamReader
- StreamWriter
- SqlConnection
- HttpResponseMessage
*/