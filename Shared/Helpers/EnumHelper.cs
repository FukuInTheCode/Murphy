namespace Shared.Helpers;

public static class EnumHelper
{
    public static IEnumerable<T> GetValuesOfType<T>() => Enum.GetValues(typeof(T)).Cast<T>();

    public static Array GetValuesArrayOfType<T>() => Enum.GetValues(typeof(T));
}