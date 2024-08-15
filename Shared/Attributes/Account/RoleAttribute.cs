namespace Shared.Attributes.Account;

public class RoleAttribute : Attribute
{
    public string Role { get; set; } = "Visitor";
}