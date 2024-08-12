using System.Net;
using Client.Repository.Interface;
using Client.Services;
using Microsoft.AspNetCore.Components;
using Shared.Enums;
using Shared.Model.Users;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Client.Pages.Auth;

public partial class LoginPage : ComponentBase
{
    #region Injects
    
    [Inject] private IAccountRepository AccountRepository { get; set; }
    [Inject] private AppData AppData { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }

    #endregion

    #region Parameter

    #endregion

    private string _username = string.Empty;
    private string _pwd = string.Empty;
    protected override Task OnInitializedAsync()
    {
        if (AppData.AccountInfo?.Id != null)
            NavigationManager?.NavigateTo("/");
        return base.OnInitializedAsync();
    }

    private async void SendRequest()
    {
        var response = await AccountRepository.Login(_username, _pwd);
        if (response.StatusCode != StatusCodes.Ok) return;
        AppData.AccountInfo = response.Content;
        NavigationManager.NavigateTo("/");
    }
}