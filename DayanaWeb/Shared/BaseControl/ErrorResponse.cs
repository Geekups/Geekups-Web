namespace DayanaWeb.Shared.BaseControl;

public class ErrorResponse
{
    public ErrorResponse(ErrorModel error, string message)
    {
        Code = error.Code;
        Title = error.Title;
        Message = message;
    }

    public int Code { get; }
    public string Title { get; }
    public string Message { get; }
}