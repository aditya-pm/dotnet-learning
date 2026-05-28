// BasicLambdaDemo();
// ExpressionLambdaDemo();
// StatementLambdaDemo();
// FuncLambdaDemo();
// ActionLambdaDemo();
// PredicateLambdaDemo();
// LambdaParameterDemo();
// ClosureDemo();


// =====================================================
// 1. BASIC LAMBDA
// =====================================================

void BasicLambdaDemo()
{
    Operation operation = (a, b) => a + b;
    Console.WriteLine(operation(5, 3));
}

/*
Lambda expression: Shorter way to write anonymous methods

Instead of:
delegate(int a, int b)
{
    return a + b;
}

Can write: (a, b) => a + b

Syntax:
(parameters) => expression/body
*/


// =====================================================
// 2. EXPRESSION LAMBDA
// =====================================================

void ExpressionLambdaDemo()
{
    Func<int, int> square = x => x * x;
    Console.WriteLine(square(5));
}

/*
Expression lambda: Single expression
Value automatically returned

x => x * x

Equivalent:
x =>
{
    return x * x;
}
*/


// =====================================================
// 3. STATEMENT LAMBDA
// =====================================================

void StatementLambdaDemo()
{
    Func<int, int, int> operation =
        (a, b) =>
        {
            int result = a + b;
            return result;
        };

    Console.WriteLine(
        operation(5, 3));
}

/*
Statement lambda: Uses full code block
Needed when: Multiple statements
*/


// =====================================================
// 4. FUNC WITH LAMBDA
// =====================================================

void FuncLambdaDemo()
{
    Func<int, int, int> multiply = (a, b) => a * b;

    Console.WriteLine(multiply(4, 5));
}

/*
Func: Delegate with return value
Last type: Return type
*/


// =====================================================
// 5. ACTION WITH LAMBDA
// =====================================================

void ActionLambdaDemo()
{
    Action<string> printer = message => Console.WriteLine(message);
    printer("Hello");
}

/*
Action: Delegate returning void
No explicit return
*/


// =====================================================
// 6. PREDICATE WITH LAMBDA
// =====================================================

void PredicateLambdaDemo()
{
    Predicate<int> even = x => x % 2 == 0;

    Console.WriteLine(even(4));
    Console.WriteLine(even(5));
}

/*
Predicate<T>
Always returns bool

Very common in:
- Filtering
-LINQ
- Validation
*/


// =====================================================
// 7. LAMBDA PARAMETERS
// =====================================================

void LambdaParameterDemo()
{
    Func<int, int> doubleValue = x => x * 2;
    Console.WriteLine(doubleValue(10));
}

/*
Single parameter: Parentheses optional
x => x * 2

Multiple parameters:
(a, b) => a + b
*/


// =====================================================
// 8. CLOSURE / VARIABLE CAPTURE
// =====================================================

void ClosureDemo()
{
    int multiplier = 10;

    Func<int, int> multiply = x => x * multiplier;

    Console.WriteLine(multiply(5));

    multiplier = 20;

    Console.WriteLine(multiply(5));
}

/*
Lambda captures variables from surrounding scope
Called: Closure

Important: Captured variable itself is referenced

Example:
multiplier = 10
↓
multiply(5)
↓
50

multiplier = 20
↓
multiply(5)
↓
100
*/


// =====================================================
// TYPES
// =====================================================

delegate int Operation(
    int a,
    int b);