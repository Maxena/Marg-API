namespace Domain.Entities.Shared;

public interface IEntity
{
}

public class BaseEntity : IEntity
{
    public BaseEntity()
    {
        // Id = typeof(T) is Guid ? Guid.NewGuid() : Id;
        InsertTime = DateTime.Now;
    }

    public Guid Id { get; set; }
    public DateTime InsertTime { get; set; }
    public string CreatorId { get; set; }
    public DateTime? UpdateTime { get; set; }
    public string ModifierId { get; set; }
}