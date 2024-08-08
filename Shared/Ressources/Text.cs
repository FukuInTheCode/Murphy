using System.Globalization;
using System.Resources;

namespace Shared.Ressources;

public static class Text
{
    private static readonly ResourceManager ResourceManager = new ("Shared.Ressources.TextRessources", typeof(Text).Assembly);

    public static string? GetString(string key, CultureInfo? culture = null)
    {
        culture ??= CultureInfo.CurrentUICulture;
        return ResourceManager.GetString(key, culture);
    }

    public static readonly string Murphy = GetString("Murphy")!;
    public static readonly string Login = GetString("Login")!;
    public static readonly string CreateAccount = GetString("CreateAccount")!;
    public static readonly string Password = GetString("Password")!;
    public static readonly string Username = GetString("Username")!;
}