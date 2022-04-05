namespace Voo.Util
{
    public interface IVooDatabase
    {
        string VooCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
