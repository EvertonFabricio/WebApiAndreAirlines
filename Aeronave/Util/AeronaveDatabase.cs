namespace Aeronave.Util
{
    public class AeronaveDatabase : IAeronaveDatabase
    {
        public string AeronaveCollectionName { get; set ; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
