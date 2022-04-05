namespace Aeroporto.Util
{
    public class AeroportoDatabase : IAeroportoDatabase
    {

        public string AeroportoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
