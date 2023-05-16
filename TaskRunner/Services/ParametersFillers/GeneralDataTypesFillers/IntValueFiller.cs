using TaskRunner.Interfaces.GeneralDataTypesFillers;

namespace TaskRunner.Services.ParametersFillers.GeneralDataTypesFillers;

public class IntValueFiller : IIntValueFiller
{
    public int Fill(string message)
    {
        Console.Write(message);
        var readValue = Console.ReadLine();
        if (string.IsNullOrEmpty(readValue) ||
            !int.TryParse(readValue, out var intValue))
        {
            throw new Exception("Invalid input.");
        }

        return intValue;
    }
}