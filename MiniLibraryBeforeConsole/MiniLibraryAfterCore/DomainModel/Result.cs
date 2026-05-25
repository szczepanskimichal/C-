namespace MiniLibraryAfterCore.DomainModel;

public class Result<T>
{
    public bool IsSuccess { get; }
    public string? ErrorMessage { get; }
    public T? Value { get; }
    
    public Result(T value)
    {
        IsSuccess = true;
        Value = value;
    }
    
    public Result(string errorMessage)
    {
        IsSuccess = false;
        ErrorMessage = errorMessage;
    }
    public static Result<T> Success(T value) => new Result<T>(value);
    public static Result<T> Failure(string errorMessage) => new Result<T>(errorMessage);
}