namespace Aeronave.Util
{
    public interface IAeronaveDatabase
    {
        string AeronaveCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}
