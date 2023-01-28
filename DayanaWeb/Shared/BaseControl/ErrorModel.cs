namespace DayanaWeb.Shared.BaseControl;

public struct ErrorModel
{
    public ErrorModel(int code, string title, string[] messages)
    {
        Code = code;
        Title = title;

        Messages = new List<string>();
        Messages.AddRange(messages);
    }

    public readonly int Code;
    public readonly string Title;
    public List<string> Messages;

    public ErrorModel Ready()
    {
        var messages = new List<string>();
        messages.AddRange(messages);
        Messages = messages;
        return this;
    }
}