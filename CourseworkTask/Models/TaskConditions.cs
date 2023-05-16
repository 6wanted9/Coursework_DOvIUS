namespace CourseworkTask.Models;

public class TaskConditions
{
    public TaskConditions(Bases bases, List<Subject> subjects)
    {
        Bases = bases;
        Subjects = subjects;
    }
    public Bases Bases { get; }

    public List<Subject> Subjects { get; }
}