namespace CourseworkTask.Models;

public class Subject
{
    public Subject(int personalNumber, Coordinates coordinates, int weight)
    {
        PersonalNumber = personalNumber;
        Weight = weight;
        Coordinates = coordinates;
    }

    public int PersonalNumber { get; }
    public int Weight { get; }

    public Coordinates Coordinates { get; }
}