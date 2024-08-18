using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Client.Repository;
using Client.Repository.Interface;
using Client.Services;
using Microsoft.AspNetCore.Components;
using MongoDB.Bson;
using Shared.Enums.Applications;
using Shared.Extensions;
using Shared.Model.Users;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Client.Pages;

// ReSharper disable once ClassNeverInstantiated.Global
public partial class Index : ComponentBase
{
    #region Inject
    
    [Inject] private IAccountRepository AccountRepository { get; set; }
    
    [Inject] private AppData AppData { get; set; }
    
    [Inject] private NavigationManager NavigationManager { get; set; }
    
    #endregion

    private void AccessApp(string? url) => NavigationManager.NavigateTo(url ?? "/");
}