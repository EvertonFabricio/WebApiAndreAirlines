namespace Aeroporto.Util
{
    public interface IAeroportoDatabase
    {
        string AeroportoCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
