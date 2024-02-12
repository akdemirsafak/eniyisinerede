namespace Reservation.API.Mongo;

public interface IDatabaseSettings
{
    public string CollectionName { get; set; }
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}
