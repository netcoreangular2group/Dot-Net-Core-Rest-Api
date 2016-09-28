namespace KPI.Infrastructure
{
    public interface IEntityWithTypedId<TId>
    {
        TId Id { get; }
    }
}
