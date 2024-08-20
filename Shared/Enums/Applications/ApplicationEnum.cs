using System.ComponentModel.DataAnnotations;
using Shared.Attributes;
using Shared.Constantes;
using Shared.Ressources;

namespace Shared.Enums.Applications;
// caca
// c'est Emma
public enum ApplicationEnum
{
    [Display(Name = "View", ResourceType = typeof(TextRessources))]
    [Color(Primary = ColorConstantes.Sapphire, Secondary = ColorConstantes.CelticBlue)]
    [Icon(Primary = "fa-eye")]
    [Attributes.Url(Primary = "/view")]
    ViewApplication,
    [Display(Name = "Organize", ResourceType = typeof(TextRessources))]
    [Color(Primary = ColorConstantes.ChineseRed, Secondary = ColorConstantes.CedarChest)]
    [Icon(Primary = "fa-table-columns")]
    [Attributes.Url(Primary = "/organize")]
    OrganizeApplication,
    [Display(Name = "Refereeing", ResourceType = typeof(TextRessources))]
    [Color(Primary = ColorConstantes.WageningenGreen, Secondary = ColorConstantes.LimeGreen)]
    [Icon(Primary = "fa-stopwatch")]
    [Attributes.Url(Primary = "/referee")]
    RefereeingApplication,
    [Display(Name = "Stats", ResourceType = typeof(TextRessources))]
    [Color(Primary = ColorConstantes.Turquoise, Secondary = ColorConstantes.Verdigris)]
    [Icon(Primary = "fa-chart-line")]
    [Attributes.Url(Primary = "/stats")]
    StatsApplications,
    [Display(Name = "Settings", ResourceType = typeof(TextRessources))]
    [Color(Primary = ColorConstantes.Black)]
    [Icon(Primary = "fa-gear")]
    [Attributes.Url(Primary = "/settings")]
    SettingsApplication
}