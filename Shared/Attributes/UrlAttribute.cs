namespace Shared.Attributes;

public class UrlAttribute : Attribute
{
    private const string DefaultUrl = "/";

    public string Primary { get; set; } = DefaultUrl;
    
    public string Secondary { get; set; } = DefaultUrl;

    public string Tertiary { get; set; } = DefaultUrl;
}