namespace CourseworkTask.Models;

public class Coordinates
{
    public int X { get; init; }
    
    public int Y { get; init; }

    public override string ToString()
    {
        return $"{{{X};{Y}}}";
    }

    public static double operator -(Coordinates a, Coordinates b)
    {
        return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
    }
}