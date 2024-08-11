using Shared.Enums;

namespace Shared.Response;

public class BaseResponse<T>(StatusCodes statusCode, T content)
{
    public StatusCodes StatusCode { get; set; } = statusCode;
    public T Content { get; set; } = content;
}