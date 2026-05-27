// BasicDelegateDemo();
// DelegateVariableDemo();
// DelegateParameterDemo();
MulticastDelegateDemo();
// ActionDemo();
// FuncDemo();
// PredicateDemo();
// AnonymousMethodDemo();


// =====================================================
// 1. BASIC DELEGATE
// =====================================================

void BasicDelegateDemo()
{
    Operation operation = Add;
    int result = operation(5, 3);
    Console.WriteLine(result);
}

/*
Delegate: Type that stores methods

Variable that
↓
Stores function


Syntax:
delegate ReturnType Name(parameters);


Example:
delegate int Operation(int a, int b);


Means:
"Operation can store methods that: take int, int and return int"
*/


// =====================================================
// 2. DELEGATE VARIABLE
// =====================================================

void DelegateVariableDemo()
{
    Operation operation;

    operation = Add;

    Console.WriteLine(operation(10, 5));

    operation = Subtract;

    Console.WriteLine(operation(10, 5));
}

/*
Delegate variable: Can point to different methods

Requirement: Method signature must match delegate
*/


// =====================================================
// 3. PASSING METHOD AS PARAMETER
// =====================================================

void DelegateParameterDemo()
{
    Process(10, 5, Add);
    Process(10, 5, Subtract);
}

/*
Delegates allow: Passing behavior
Instead of: Hardcoding logic

Can pass method like data
*/


// =====================================================
// 4. MULTICAST DELEGATE
// =====================================================

void MulticastDelegateDemo()
{
    Message message;

    message = Hello;
    message += Goodbye;

    message();

    Console.WriteLine();

    message -= Hello;

    message();
}

/*
Delegate can store: Multiple methods

+= : Add method
-= : Remove method

Invocation: Runs all methods in order
*/


// =====================================================
// 5. ACTION
// =====================================================

void ActionDemo()
{
    Action<string> printer =
        PrintMessage;

    printer("Hello");
}

/*
Action: Built in delegate
Returns: void

Action<string>
Means: Method accepts string
*/


// =====================================================
// 6. FUNC
// =====================================================

void FuncDemo()
{
    Func<int, int, int> operation =
        Multiply;

    Console.WriteLine(
        operation(4, 5));
}

/*
Func: Built in delegate
Last type: Return type

Func<int, int, int>
Means:
(int, int)
↓
int
*/


// =====================================================
// 7. PREDICATE
// =====================================================

void PredicateDemo()
{
    Predicate<int> even =
        IsEven;

    Console.WriteLine(
        even(4));

    Console.WriteLine(
        even(5));
}

/*
Predicate<T>: Built in delegate
Always returns: bool
Used often:
- Filtering
- Validation
- Conditions
*/


// =====================================================
// 8. ANONYMOUS METHOD
// =====================================================

void AnonymousMethodDemo()
{
    Operation operation =
        delegate(int a, int b)
        {
            return a * b;
        };

    Console.WriteLine(
        operation(4, 5));
}

/*
Anonymous method: Method without name
Useful: Short logic
Later: Lambdas improve this
*/


// =====================================================
// TYPES
// =====================================================

int Add(
    int a,
    int b)
{
    return a + b;
}


int Subtract(
    int a,
    int b)
{
    return a - b;
}


int Multiply(
    int a,
    int b)
{
    return a * b;
}


void Process(
    int a,
    int b,
    Operation operation)
{
    Console.WriteLine(
        operation(a, b));
}


void Hello()
{
    Console.WriteLine("Hello");
}


void Goodbye()
{
    Console.WriteLine("Goodbye");
}


void PrintMessage(
    string message)
{
    Console.WriteLine(message);
}


bool IsEven(
    int value)
{
    return value % 2 == 0;
}


delegate int Operation(
    int a,
    int b);

delegate void Message();