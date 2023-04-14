namespace DayanaWeb.Server.EntityFramework.Common;

//defined for reflection
public interface IBaseEntity
{
}
public abstract class BaseEntity<T> : IBaseEntity
{
    public T Id { get; set; }

    // last changes datetime
    // map this shiit in your every create and update
    public DateTime ModifiedDate { get; set; }
    public DateTime CreateDate { get; set; }
}

// this is defualt for id 
//you see default id type is long
// but if need to have diffrent type
// just depend yor entity directly to ----> BaseEntity<T>
public abstract class BaseEntity : BaseEntity<long>
{
}