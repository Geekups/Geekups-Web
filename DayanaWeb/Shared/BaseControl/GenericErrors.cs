using DayanaWeb.Shared.EntityFramework.Common;

namespace DayanaWeb.Shared.BaseControl;

public static class GenericErrors<TEntity> where TEntity : class, IBaseEntity
{
    public static ErrorModel InvalidVariableError(string variableName) => new(
      code: 666,
      title: $"{nameof(TEntity)} Error",
      message: $"Invalid property : '{variableName.ToLower()}' in -> object: '{nameof(TEntity)}' error");

    public static ErrorModel NotFoundError(string variableName) => new(
     code: 69,
     title: $"{nameof(TEntity)} Error",
     message: $"object: '{nameof(TEntity)}' -> with this '{variableName.ToLower()}' -> not found");

    public static ErrorModel CustomError(string causeOfError, string variableName = "unknown") => new(
    code: 85,
    title: $"{nameof(TEntity)} Error",
    message: $"object: '{nameof(TEntity)}' | '{variableName.ToLower()}' property error | \n {causeOfError.ToLower()}");

    public static ErrorModel IntervalError(int min, int max, string variableName) => new(
   code: 13,
   title: $"{nameof(TEntity)} Error",
   message: $"object: '{nameof(TEntity)}' | '{variableName.ToLower()}' property error | \n ");

    public static ErrorModel DuplicateError(string variableName) => new(
 code: 2022,
 title: $"{nameof(TEntity)} Error",
 message: $"object: '{nameof(TEntity)}' | with this '{variableName.ToLower()}' already exists | \n ");
}

public static class CustomError<T>
{
    public static ErrorModel NullRefError() => new(
    code: 13,
    title: $"{nameof(T)} Error",
    message: $"object: '{nameof(T)}' | Is Null | \n ");
}