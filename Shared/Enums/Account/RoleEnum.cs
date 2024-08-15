using System.ComponentModel.DataAnnotations;
using Shared.Attributes.Account;
using Shared.Constantes.Account;
using Shared.Ressources;

namespace Shared.Enums.Account;

public enum RoleEnum
{
    [Display(Name = "Visitor", ResourceType = typeof(TextRessources))]
    [Role(Role = RoleConstantes.VisitorRole)]
    Visitor,
    [Display(Name = "LocalModerator", ResourceType = typeof(TextRessources))]
    [Role(Role = RoleConstantes.LocalModeratorRole)]
    LocalModerator,
    [Display(Name = "LocalAdministrator", ResourceType = typeof(TextRessources))]
    [Role(Role = RoleConstantes.LocalAdministratorRole)]
    LocalAdministrator,
    [Display(Name = "Moderator", ResourceType = typeof(TextRessources))]
    [Role(Role = RoleConstantes.ModeratorRole)]
    Moderator,
    [Display(Name = "Administrator", ResourceType = typeof(TextRessources))]
    [Role(Role = RoleConstantes.AdministratorRole)]
    Administrator,
    [Display(Name = "Founder", ResourceType = typeof(TextRessources))]
    [Role(Role = RoleConstantes.FounderRole)]
    Founder
}