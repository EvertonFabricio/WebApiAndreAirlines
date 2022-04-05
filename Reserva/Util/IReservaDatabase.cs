namespace Reserva.Util
{
    public interface IReservaDatabase
    {
        string ReservaCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
