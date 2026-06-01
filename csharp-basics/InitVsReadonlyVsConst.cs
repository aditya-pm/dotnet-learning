// ConstDemo();
// ReadonlyDemo();
// InitDemo();


// =====================================================
// OVERVIEW
// =====================================================

/*

Question: "When is a value allowed to be assigned?"

const
↓
Compile Time

readonly
↓
Construction Time

init
↓
Object Creation Time


CHEAT SHEET
-----------
const
- Field only
- Compile-time constant
- Assigned immediately
- Same value for everyone

readonly
- Field only
- Assigned in declaration or constructor
- Different objects can have different values

init
- Property only
- Assigned during object creation
- Common in records and DTOs

*/


// =====================================================
// 1. CONST
// =====================================================

void ConstDemo()
{
    Console.WriteLine(MathConstants.DaysInWeek);
}

/*

const: Value must be known at compile time.

Example:
public const int DaysInWeek = 7;

Compiler literally replaces:

MathConstants.DaysInWeek
with:
7

Valid:
const int MaxPlayers = 100;
const string AppName = "GameStore";

Invalid:
const DateTime Today = DateTime.Now;
const Guid Id = Guid.NewGuid();

because those values are only known at runtime.

Use const when:
- Value never changes
- Value is known at compile time

Examples:
Pi approximations
Days in a week
Months in a year
Application constants

*/


// =====================================================
// 2. READONLY
// =====================================================

void ReadonlyDemo()
{
    Server s1 = new(8080);
    Server s2 = new(5000);

    Console.WriteLine(s1.Port);
    Console.WriteLine(s2.Port);
}

/*

readonly

Can be assigned:
- At declaration
- Inside constructor

Example:

public readonly int Port;

public Server(int port)
{
    Port = port;
}


Unlike const:

Different objects can have different values.
Server s1 = new(8080);
Server s2 = new(5000);


Most common usage:

private readonly ILogger _logger;
private readonly HttpClient _client;


Important:
readonly protects the FIELD.
It does NOT make the object immutable.

Example:
private readonly List<string> _names = new();

Allowed:
_names.Add("Alice");


Not Allowed:
_names = new List<string>();

Meaning:
The field must continue pointing to the same object.

*/


// =====================================================
// 3. INIT
// =====================================================

void InitDemo()
{
    User user = new()
    {
        Name = "Alice",
        Age = 22
    };

    Console.WriteLine(user.Name);
}

/*
init: Applies to properties.

Example:
public string Name { get; init; }

Can assign:
new User
{
    Name = "Alice"
}

Cannot assign later:
user.Name = "Bob"; // Error


Why init exists:
Without init:
public string Name { get; }

You must use a constructor.

With init:

You get object initializer syntax
while still preventing modification
after creation.

Common in:
- Records
- DTOs
- ASP.NET Core
- JSON serialization


Example DTO:

public record GameDto
{
    public string Name { get; init; }
    public decimal Price { get; init; }
}

*/


// =====================================================
// COMPARISON
// =====================================================

/*

const
When can it be assigned?: Immediately only

Example:
const int Value = 10;

--------------------------------------------------

readonly
- When can it be assigned?
- Declaration or constructor

Example:

public readonly int Value;

public Example(int value)
{
    Value = value;
}

--------------------------------------------------

init
- When can it be assigned?
- Object creation

Example:

new User
{
    Name = "Alice"
}

--------------------------------------------------

WHEN TO USE WHAT?

const
Use when:
- Value is known at compile time
- Value never changes

Examples:
- Days in week
- Months in year
- Mathematical constants


readonly
Use when:
- Internal field
- Dependency
- Constructor-initialized state

Examples:
private readonly ILogger _logger;
private readonly HttpClient _client;
private readonly List<Game> _games;


init
Use when:
- Public data model
- DTO
- Record
- Configuration object

Examples:

public string Name { get; init; }

record GameDto(
    int Id,
    string Name,
    decimal Price
);

*/


// =====================================================
// TYPES
// =====================================================

static class MathConstants
{
    public const int DaysInWeek = 7;
}

class Server
{
    public readonly int Port;

    public Server(int port)
    {
        Port = port;
    }
}

class User
{
    public string Name { get; init; } = "";
    public int Age { get; init; }
}