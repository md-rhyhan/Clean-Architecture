namespace TestFluentValidation.Domain.Base;

public abstract class BaseEntity : MasterEntity
{
    public BaseEntity()
    {
        this.CreatedBy = 1;
        this.CreatedDate = DateTimeOffset.UtcNow;
        this.IsDeleted = false;
    }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
    public int CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }
    public bool IsDeleted { get; set; }
}
