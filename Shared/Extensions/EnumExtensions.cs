using System.ComponentModel.DataAnnotations;

namespace Shared.Extensions;

public static class EnumExtensions
{
    public static T? GetAttributeOfType<T>(this Enum value) where T : Attribute => 
        (T?)value?.GetType()?.GetMember(value.ToString())?[0]?.GetCustomAttributes(typeof(T), false)?[0];

    public static string? GetDisplayName(this Enum value) => value.GetAttributeOfType<DisplayAttribute>()?.Name;

    public static string? GetDisplayShortName(this Enum value) => value.GetAttributeOfType<DisplayAttribute>()?.ShortName;

    public static string? GetDisplayDescription(this Enum value) => value.GetAttributeOfType<DisplayAttribute>()?.Description;
    
    public static Type? GetDisplayResourcesType(this Enum value) => value.GetAttributeOfType<DisplayAttribute>()?.ResourceType;
}