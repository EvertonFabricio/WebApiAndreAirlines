namespace Passageiro.Util
{
    public class PassageiroDatabase : IPassageiroDatabase
    {
        public string PassageiroCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
