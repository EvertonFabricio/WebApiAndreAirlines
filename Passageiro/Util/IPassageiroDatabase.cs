namespace Passageiro.Util
{
    public interface IPassageiroDatabase
    {
        string PassageiroCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
