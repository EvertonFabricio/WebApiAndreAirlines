namespace PrecoBase.Util
{
    public interface IPrecoBaseDatabase
    {
        string PrecoBaseCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
