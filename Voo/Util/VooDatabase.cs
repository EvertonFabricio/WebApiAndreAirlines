namespace Voo.Util
{
    public class VooDatabase : IVooDatabase
    {
        public string VooCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
