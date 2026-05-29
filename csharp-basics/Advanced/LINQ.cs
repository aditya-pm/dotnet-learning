/* LINQ: Language Integrated Query
Purpose: Work with collections using a declarative style

Instead of: "How do I loop?"
Think: "What result do I want?"
*/

// WhereDemo();
// SelectDemo();
// OrderByDemo();
// FirstDemo();
// FirstOrDefaultDemo();
// AnyDemo();
// AllDemo();
// CountDemo();
// DistinctDemo();
// ChainingDemo();
// DeferredExecutionDemo();


// =====================================================
// 1. WHERE
// =====================================================

void WhereDemo()
{
    List<int> numbers = [1, 2, 3, 4, 5, 6];

    IEnumerable<int> evenNumbers = numbers.Where(x => x % 2 == 0);

    foreach (int number in evenNumbers)
    {
        Console.WriteLine(number);
    }
}

/*
Where: Filters elements
Lambda must return: bool

Example: x => x % 2 == 0

Meaning: Keep elements where condition is true

Output:
2
4
6
*/


// =====================================================
// 2. SELECT
// =====================================================

void SelectDemo()
{
    List<int> numbers = [1, 2, 3];

    IEnumerable<int> squares = numbers.Select(x => x * x);

    foreach (int square in squares)
    {
        Console.WriteLine(square);
    }
}

/*
Select: Transforms elements

Input: 1 2 3
Output: 1 4 9

One value in
↓
One value out
*/


// =====================================================
// 3. ORDERBY
// =====================================================

void OrderByDemo()
{
    List<int> numbers = [5, 1, 4, 2, 3];

    IEnumerable<int> sorted = numbers.OrderBy(x => x);

    foreach (int number in sorted)
    {
        Console.WriteLine(number);
    }
}

/*
OrderBy: Sort ascending
OrderByDescending: Sort descending
*/


// =====================================================
// 4. FIRST
// =====================================================

void FirstDemo()
{
    List<int> numbers = [10, 20, 30];

    int value = numbers.First();

    Console.WriteLine(value);
}

/*
First: Returns first element

Throws exception if collection empty
*/


// =====================================================
// 5. FIRSTORDEFAULT
// =====================================================

void FirstOrDefaultDemo()
{
    List<int> numbers = [];

    int value = numbers.FirstOrDefault();

    Console.WriteLine(value);
}

/*
FirstOrDefault: Returns first element

If empty: Returns default value
int: 0
string: null
*/


// =====================================================
// 6. ANY
// =====================================================

void AnyDemo()
{
    List<int> numbers = new() { 1, 3, 5, 8 };
    bool hasEven = numbers.Any(x => x % 2 == 0);
    Console.WriteLine(hasEven);
}

/*
Any: Does at least one element match condition?
*/
    

// =====================================================
// 7. ALL
// =====================================================

void AllDemo()
{
    List<int> numbers = new() { 2, 4, 6 };
    bool allEven = numbers.All(x => x % 2 == 0);
    Console.WriteLine(allEven);
}

/*
All: Do all elements match condition?
*/


// =====================================================
// 8. COUNT
// =====================================================

void CountDemo()
{
    List<int> numbers = new() { 1, 2, 3, 4, 5 };
    int count = numbers.Count();
    Console.WriteLine(count);
}

/*
Count: Number of elements
*/


// =====================================================
// 9. DISTINCT
// =====================================================

void DistinctDemo()
{
    List<int> numbers = new() { 1, 1, 2, 2, 3, 3 };

    IEnumerable<int> unique = numbers.Distinct();

    foreach (int value in unique)
    {
        Console.WriteLine(value);
    }
}

/*
Distinct: Removes duplicates
*/


// =====================================================
// 10. CHAINING
// =====================================================

void ChainingDemo()
{
    List<int> numbers = new() { 1, 2, 3, 4, 5, 6 };

    IEnumerable<int> result =
        numbers
            .Where(x => x % 2 == 0)
            .Select(x => x * 10)
            .OrderBy(x => x);

    foreach (int value in result)
    {
        Console.WriteLine(value);
    }
}

/*
LINQ methods can chain

Pipeline:
Filter
↓
Transform
↓
Sort
*/


// =====================================================
// 11. DEFERRED EXECUTION
// =====================================================

void DeferredExecutionDemo()
{
    List<int> numbers = [1, 2, 3];

    IEnumerable<int> query = numbers.Where(x => x > 1);

    numbers.Add(10);

    foreach (int value in query)
    {
        Console.WriteLine(value);
    }
}

/*
Important:
LINQ often does NOT execute immediately

Query created:
numbers.Where(...)

No filtering yet

Execution happens when:
- foreach
- ToList()
- ToArray()
- Count()
etc.

Output:
2
3
10

10 appears because query
executed later
*/