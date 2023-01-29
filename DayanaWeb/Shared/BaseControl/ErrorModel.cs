namespace DayanaWeb.Shared.BaseControl;

public struct ErrorModel
{
    public ErrorModel(int code, string title, string message)
    {
        Code = code;
        Title = title;
        Message = message;
    }

    public readonly int Code;
    public readonly string Title;
    public string Message;

    public ErrorModel Ready()
    {
        var message = "";
        Message = message;
        return this;
    }
}