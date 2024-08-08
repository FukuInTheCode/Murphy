using Client.Repository.Interface;
using Microsoft.AspNetCore.Components;
using MongoDB.Bson;

namespace Client.Pages;

// ReSharper disable once ClassNeverInstantiated.Global
public partial class Index : ComponentBase
{
    [Inject] public required IUsersRepository UsersRepository { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var tmp = await UsersRepository.GetUsers();
        Console.WriteLine("Result: " +  tmp.ToJson());
        await base.OnInitializedAsync();
    }
}