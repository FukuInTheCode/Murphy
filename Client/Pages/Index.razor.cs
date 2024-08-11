using System;
using System.Threading.Tasks;
using Client.Repository.Interface;
using Microsoft.AspNetCore.Components;
using MongoDB.Bson;
using Shared.Model.Users;

namespace Client.Pages;

// ReSharper disable once ClassNeverInstantiated.Global
public partial class Index : ComponentBase
{
    [Inject] public required IUsersRepository UsersRepository { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var tmp = await UsersRepository.Register("admin4", "admin4");
        Console.WriteLine("Result: " +  tmp.ToJson());
        await base.OnInitializedAsync();
    }
}