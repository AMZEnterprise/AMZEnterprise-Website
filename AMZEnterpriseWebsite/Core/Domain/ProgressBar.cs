namespace AMZEnterpriseWebsite.Core.Domain
{
    public class ProgressBar : IEntity
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public int Percentage { get; set; }
        public int SortIndex { get; set; }
    }
}
