using CourseworkTask.Enums;

namespace CourseworkTask.Models;

public class Bases
{
    private Base _baseA;
    private Base _baseB;

    public Bases(Base baseA, Base baseB)
    {
        _baseA = baseA;
        _baseB = baseB;
    }

    public Base this[BaseType baseType] => baseType == BaseType.A ? _baseA : _baseB;
}