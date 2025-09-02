namespace TG.ECommerce.Shared.SeedWork.Entity;

public interface ISoftDeletion
{
    public DateTime CreatedOn { get; }
    public DateTime? UpdatedOn { get; }
    public DateTime? DeletedOn { get; }
}