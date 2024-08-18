using Shared.Constantes;

namespace Shared.Attributes;

public class ColorAttribute : Attribute
{
    public string Primary { get; set; } = ColorConstantes.Black;

    public string Secondary { get; set; } = ColorConstantes.Black;
    
    public string Tertiary { get; set; } = ColorConstantes.Black;
}