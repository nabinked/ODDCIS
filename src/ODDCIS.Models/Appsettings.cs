namespace ODDCIS.Models
{
    public class Appsettings
    {
        public string OwlFilePath { get; set; }

        public Query QuerySettings { get; set; }
    }
    public class Query
    {
        public string Folder { get; set; }
        public string Query1 { get; set; }
    }
}