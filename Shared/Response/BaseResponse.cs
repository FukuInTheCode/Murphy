namespace Shared.Response;

public class BaseResponse<T>(int statusCode, T content)
{
    public int StatusCode { get; set; } = statusCode;
    public T Content { get; set; } = content;
}