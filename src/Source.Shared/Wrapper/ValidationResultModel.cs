namespace Source.Shared.Wrapper;

public class ValidationResultModel
{
    public IList<ErrorModel> Errors { get; }

    public ValidationResultModel()
    {
        Errors = new List<ErrorModel>();
    }

    public ValidationResultModel(IList<ErrorModel> errors)
    {
        Errors = errors;
    }

    public ValidationResultModel(ErrorModel error)
    {
        Errors = new List<ErrorModel>() { error };
    }

    public bool HasError
    {
        get { return Errors != null && Errors.Count() > 0; }
    }
}
