namespace CourseworkTask.Models;

public class Base
{
    public Base(Coordinates coordinates)
    {
        Coordinates = coordinates;
    }

    public Coordinates Coordinates { get; init; }
}