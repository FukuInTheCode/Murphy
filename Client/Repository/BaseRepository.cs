using System.Diagnostics.CodeAnalysis;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using MongoDB.Bson;
using Shared.Response;

namespace Client.Repository;

public class BaseRepository(HttpClient client)
{
    #region Requests

    protected async Task<BaseResponse<TResult>> Get<TResult>(string url) where TResult : new()
    {
        try
        {
            var response = await client.GetAsync(url);
            var responseBody = await response.Content.ReadAsStringAsync();
            if (typeof(TResult) == typeof(string))
                return new BaseResponse<TResult>((int)response.StatusCode, (TResult)(object)responseBody);
            var result = JsonConvert.DeserializeObject<TResult>(responseBody);
            return new BaseResponse<TResult>((int)response.StatusCode, result ?? new TResult());
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
            return new BaseResponse<TResult>(500, new TResult());
        }
    }

    protected async Task<BaseResponse<TResult>> Post<TParam, TResult>(string url, TParam param) where TResult : new()
    {
        try
        {
            var jsonPayload = JsonConvert.SerializeObject(param);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResult>(responseBody);
            return new BaseResponse<TResult>((int)response.StatusCode, result ?? new TResult());
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
            return new BaseResponse<TResult>(500, new TResult());
        }
    }
    
    protected async Task<BaseResponse<T>> Post<T>(string url, T param) where T : new() => await Post<T, T>(url, param);

    protected async Task<BaseResponse<TResult>> Put<TParam, TResult>(string url, TParam param) where TResult : new()
    {
        try
        {
            var jsonPayload = JsonConvert.SerializeObject(param);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(url, content);
            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResult>(responseBody);
            return new BaseResponse<TResult>((int)response.StatusCode, result ?? new TResult());
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
            return new BaseResponse<TResult>(500, new TResult());
        }
    }

    protected async Task<BaseResponse<TResult>> Delete<TResult>(string url) where TResult : new()
    {
        try
        {
            var response = await client.DeleteAsync(url);
            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResult>(responseBody);
            return new BaseResponse<TResult>((int)response.StatusCode, result ?? new TResult());
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
            return new BaseResponse<TResult>(500, new TResult());
        }
    }
    
    #endregion

    #region Utils

    public static string? EnsureSeparator(string? url) => 
        !string.IsNullOrEmpty(url) ?  (url.EndsWith("/") ? url : url + "/") : "";


    public string GetUrlFromParam<T>(string? baseUrl, [NotNull] T p1) =>
        EnsureSeparator(baseUrl) + p1!.ToString();
    
    public string GetUrlFromParam<T1, T2>(string? baseUrl, [NotNull] T1 p1, [NotNull] T2 p2) =>
        EnsureSeparator(GetUrlFromParam(baseUrl, p1)) + p2!.ToString();

    
    public string GetUrlFromParam<T1, T2, T3>(string? baseUrl, [NotNull] T1 p1, [NotNull] T2 p2, [NotNull] T3 p3) =>
        EnsureSeparator(GetUrlFromParam(baseUrl, p1, p2)) + p3!.ToString();

    public T GetContent<T>(BaseResponse<T> response) => response.Content;

    public int GetStatusCode<T>(BaseResponse<T> response) => response.StatusCode;


    #endregion
}