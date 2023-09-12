namespace TestFluentValidation.Domain.Base;

public interface IEntity<T>
    where T : IEquatable<T>
{
    T Id { get; set; }
    DateTimeOffset CreatedDate { get; set; }
    DateTimeOffset? UpdatedDate { get; set; }

    int CreatedBy { get; set; }
    int? UpdatedBy { get; set; }
    bool IsDeleted { get; set; }

}

public interface IEntity : IEntity<int>
{

}