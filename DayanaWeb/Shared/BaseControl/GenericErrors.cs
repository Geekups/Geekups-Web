using DayanaWeb.Shared.EntityFramework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DayanaWeb.Shared.BaseControl;

public static class GenericErrors<TEntity> where TEntity : class, IBaseEntity
{
    public static ErrorModel InvalidVariableError(string variableName) => new ErrorModel(
      code: 666,
      title: $"{nameof(TEntity)} Error",
      (Message: $"Invalid property : '{variableName.ToLower()}' in -> object: '{nameof(TEntity)}' error"));

    public static ErrorModel NotFoundError(string variableName) => new ErrorModel(
     code: 69,
     title: $"{nameof(TEntity)} Error",
     (Message: $"object: '{nameof(TEntity)}' -> with this '{variableName.ToLower()}' -> not found"));

    public static ErrorModel CustomError(string causeOfError, string? variableName = "unknown") => new ErrorModel(
    code: 85,
    title: $"{nameof(TEntity)} Error",
    (Message: $"object: '{nameof(TEntity)}' | '{variableName.ToLower()}' property error | \n {causeOfError.ToLower()}"));

    public static ErrorModel IntervalError(int min, int max, string variableName) => new ErrorModel(
   code: 13,
   title: $"{nameof(TEntity)} Error",
   (Message: $"object: '{nameof(TEntity)}' | '{variableName.ToLower()}' property error | \n "));

    public static ErrorModel DuplicateError(string variableName) => new ErrorModel(
 code: 2022,
 title: $"{nameof(TEntity)} Error",
 (Message: $"object: '{nameof(TEntity)}' | with this '{variableName.ToLower()}' already exists | \n "));
}
