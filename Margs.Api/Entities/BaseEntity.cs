namespace Margs.Api.Entities;

public interface IEntity
{
}

public class BaseEntity<T> : IEntity
{
    public T? Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}