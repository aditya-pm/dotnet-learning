Point p1 = new Point(1, 1);
var p2 = p1 with {Y = 10};
Console.WriteLine($"The two points are {p1} and {p2}");

double slopeResult = p2.Slope();
Console.WriteLine($"The slope of {p2} is {slopeResult}");


// public record Point(int X, int Y);
public record Point(int X, int Y)
{
    public double Slope() => (double)X / (double)Y;
}

/*
record = shortand for record class, hence record is a class with extra behaviour
there is also record struct, which is a struct with extra behaviour

*/