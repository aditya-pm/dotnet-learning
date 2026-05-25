List<string> names = ["<name>", "Ana", "Felipe"];

foreach (string name in names)
{
    Console.WriteLine($"Hello {name.ToUpper()}");
}
Console.WriteLine();


// List.Add() and List.Remove()
names.Add("Maria");
names.Add("Bill");
names.Remove("Ana");
foreach (var name in names)
{
    Console.WriteLine($"Hello {name.ToLower()}");
}
Console.WriteLine();

// List indexing
Console.WriteLine($"Name in index position 0 is {names[0]}");
Console.WriteLine($"Name in index position 1 is {names[1]}");
Console.WriteLine();

// List.Count
Console.WriteLine($"The list names has {names.Count} names in it");
Console.WriteLine();

// IndexOf
var index = names.IndexOf("Felipe");
if (index == -1)
{
    Console.WriteLine($"When an item is not found, IndexOf returns {index}");
}
else
{
    Console.WriteLine($"The name {names[index]} is at index {index}");
}

index = names.IndexOf("Not Found");
if (index == -1)
{
    Console.WriteLine($"When an item is not found, IndexOf returns {index}");
}
else
{
    Console.WriteLine($"The name {names[index]} is at index {index}");
}
Console.WriteLine();


// Sorting
names.Sort();
foreach (var name in names)
{
    Console.WriteLine($"Hello {name.ToUpper()}!");
}
Console.WriteLine();


// Fibonacci challenge
void Fibonacci()
{
    List<int> sequence = [1, 1];
    for (int i = 2; i < 20; i++)
    {
        int previous = sequence[i - 1];
        int previous2 = sequence[i - 2];
        sequence.Add(previous + previous2);
    }

    foreach (int num in sequence)
    {
        Console.Write($"{num}, ");
    }
}

Fibonacci();