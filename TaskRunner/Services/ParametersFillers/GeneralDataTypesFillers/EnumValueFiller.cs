using System.Text;
using TaskRunner.Extensions;
using TaskRunner.Interfaces.GeneralDataTypesFillers;

namespace TaskRunner.Services.ParametersFillers.GeneralDataTypesFillers;

public class EnumValueFiller : IEnumValueFiller
{
    private const string EnumValuesDisplayTemplate = "{0}. {1}";

    public TEnum Fill<TEnum>(string message)
        where TEnum: struct, Enum
    {
        Console.Write(GetEnumValues<TEnum>());
        Console.Write(message);
        var readValue = Console.ReadLine();
        if (!EnumExtensions.IsKeyValid<TEnum>(readValue, out var enumValue))
        {
            throw new Exception("Invalid input.");
        }

        return enumValue;
    }

    private string GetEnumValues<TEnum>()
        where TEnum: struct, Enum
    {
        var builder = new StringBuilder();
        Enum.GetValues<TEnum>().ToList().ForEach(
            type => builder.AppendLine(string.Format(EnumValuesDisplayTemplate, Convert.ToInt32(type), type)));

        return builder.ToString();
    }
}