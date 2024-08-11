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
    
    [Inject] private IUsersRepository UsersRepository { get; set; }
    [Inject] private AppData AppData { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }

    #endregion

    #region Parameter

    #endregion

    private string _username = string.Empty;
    private string _pwd = string.Empty;
    protected override Task OnInitializedAsync()
    {
        if (AppData?.User?.Id != null)
            NavigationManager?.NavigateTo("/");
        return base.OnInitializedAsync();
    }

    private async void SendRequest()
    {
        var response = await UsersRepository.Login(_username, _pwd);
        if (response.StatusCode != StatusCodes.Ok) return;
        AppData.User = response.Content;
        NavigationManager.NavigateTo("/");
    }
}