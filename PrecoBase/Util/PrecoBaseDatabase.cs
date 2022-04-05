namespace PrecoBase.Util
{
    public class PrecoBaseDatabase : IPrecoBaseDatabase
    {
       public string PrecoBaseCollectionName { get; set; }
       public string ConnectionString { get; set; }
       public string DatabaseName { get; set; }
    }
}
