namespace TaskRunner.Interfaces.GeneralDataTypesFillers;

public interface IEnumValueFiller
{
    TEnum Fill<TEnum>(string message) where TEnum : struct, Enum;
}