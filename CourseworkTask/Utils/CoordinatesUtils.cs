using CourseworkTask.Models;

namespace CourseworkTask.Utils;

internal static class CoordinatesUtils
{
    public static Coordinates GenerateRandomCoordinates()
    {
        var random = new Random();

        return new Coordinates
        {
            X = random.Next(0, 10),
            Y = random.Next(0, 10),
        };
    }

    public static Coordinates Generate(int x, int y)
    {
        return new Coordinates
        {
            X = x,
            Y = y,
        };
    }
}