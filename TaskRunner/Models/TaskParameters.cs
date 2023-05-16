using TaskRunner.Enums;

namespace TaskRunner.Models;

public class TaskParameters
{
    public ExecutionType ExecutionType { get; init; }

    public DataGenerationType DataGenerationType { get; init; }

    public int? SubjectsAmount { get; set; }

    public int? MaxSubjectWeight { get; set; }
}