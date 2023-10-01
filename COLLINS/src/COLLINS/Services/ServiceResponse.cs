namespace COLLINS.Services
{
    public class ServiceResponse<T>
{
    public T Data { get; set; }
    public bool Success { get; set; } = true;
    public string Message { get; set; } = null;

    public static ServiceResponse<T> Ok(T data)
    {
        return new ServiceResponse<T> { Data = data, Success = true };
    }

    public static ServiceResponse<T> BadRequest(string message)
    {
        return new ServiceResponse<T> { Success = false, Message = message };
    }
}
}