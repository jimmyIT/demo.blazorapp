namespace Source.Shared.Wrapper;

public class WrapperResult : IWrapperResult
{
    public List<ErrorModel>? Errors { get; set; }
    public bool Succeeded { get; set; }

    public static IWrapperResult Fail()
        => new WrapperResult { Succeeded = false };

    public static IWrapperResult Fail(ErrorModel error)
        => new WrapperResult { Succeeded = false, Errors = new List<ErrorModel> { error } };

    public static IWrapperResult Fail(List<ErrorModel> errors)
        => new WrapperResult { Succeeded = false, Errors = errors };

    public static Task<IWrapperResult> FailAsync()
        => Task.FromResult(Fail());

    public static Task<IWrapperResult> FailAsync(ErrorModel error)
        => Task.FromResult(Fail(error));

    public static Task<IWrapperResult> FailAsync(List<ErrorModel> errors)
        => Task.FromResult(Fail(errors));

    public static IWrapperResult Success()
        => new WrapperResult { Succeeded = true };

    public static IWrapperResult Success(ErrorModel error)
        => new WrapperResult { Succeeded = true, Errors = new List<ErrorModel> { error } };

    public static Task<IWrapperResult> SuccessAsync()
        => Task.FromResult(Success());

    public static Task<IWrapperResult> SuccessAsync(ErrorModel error)
        => Task.FromResult(Success(error));
}

public class WrapperResult<T> : WrapperResult, IWrapperResult<T>
{
    public T Data { get; set; }

    public new static WrapperResult<T> Fail()
        => new WrapperResult<T> { Succeeded = false };

    public new static WrapperResult<T> Fail(ErrorModel error)
        => new WrapperResult<T> { Succeeded = false, Errors = new List<ErrorModel> { error } };

    public new static WrapperResult<T> Fail(List<ErrorModel> errors)
        => new WrapperResult<T> { Succeeded = false, Errors = errors };

    public new static Task<WrapperResult<T>> FailAsync()
        => Task.FromResult(Fail());

    public new static Task<WrapperResult<T>> FailAsync(ErrorModel error)
        => Task.FromResult(Fail(error));

    public new static Task<WrapperResult<T>> FailAsync(List<ErrorModel> errors)
        => Task.FromResult(Fail(errors));

    public new static WrapperResult<T> Success()
        => new WrapperResult<T> { Succeeded = true };

    public new static WrapperResult<T> Success(ErrorModel error)
        => new WrapperResult<T> { Succeeded = true, Errors = new List<ErrorModel> { error } };

    public static WrapperResult<T> Success(T data)
        => new WrapperResult<T> { Succeeded = true, Data = data };

    public static WrapperResult<T> Success(T data, ErrorModel error)
        => new WrapperResult<T> { Succeeded = true, Data = data, Errors = new List<ErrorModel> { error } };

    public static WrapperResult<T> Success(T data, List<ErrorModel> errors)
        => new WrapperResult<T> { Succeeded = true, Data = data, Errors = errors };

    public new static Task<WrapperResult<T>> SuccessAsync()
        => Task.FromResult(Success());

    public new static Task<WrapperResult<T>> SuccessAsync(ErrorModel error)
        => Task.FromResult(Success(error));

    public static Task<WrapperResult<T>> SuccessAsync(T data)
        => Task.FromResult(Success(data));

    public static Task<WrapperResult<T>> SuccessAsync(T data, ErrorModel error)
        => Task.FromResult(Success(data, error));
}