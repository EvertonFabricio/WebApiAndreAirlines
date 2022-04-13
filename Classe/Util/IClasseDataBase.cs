namespace Classe.Util
{
    public interface IClasseDataBase
    {
        string ClasseCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
