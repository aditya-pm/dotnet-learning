challenge();

void challenge()
{
    int sum = 0;
    for (int num = 1; num < 21; num++)
        if (num % 3 == 0)
            sum += num;
    Console.WriteLine($"Sum of first 20 natural numbers that are divisible by 3: {sum}");
}
