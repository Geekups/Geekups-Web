using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayanaWeb.Shared.EntityFramework.Common;

public class BaseDto<T>
{
    public T Id { get; set; }
    public DateTime ModifiedDate { get; set; }
    public DateTime CreateDate { get; set; }
}
public abstract class BaseDto : BaseDto<long>
{
}