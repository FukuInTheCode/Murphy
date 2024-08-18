namespace Shared.Attributes;

public class IconAttribute : Attribute
{
    private const string DefaultIcon = "fa-m";

    public string Primary { get; set; } = DefaultIcon;
    
    public string Secondary { get; set; } = DefaultIcon;

    public string Tertiary { get; set; } = DefaultIcon;
}