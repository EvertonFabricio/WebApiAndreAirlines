namespace Reserva.Util
{
    public class ReservaDatabase : IReservaDatabase
    {
        public string ReservaCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
