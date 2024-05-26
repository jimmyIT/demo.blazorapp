namespace Source.Shared.Wrapper;

public interface IWrapperResult
{
    List<ErrorModel>? Errors { get; set; }
    bool Succeeded { get; set; }
}

public interface IWrapperResult<out T> : IWrapperResult
{
    T Data { get; }
}