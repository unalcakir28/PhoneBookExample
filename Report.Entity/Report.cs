using Report.Entity.Base;

namespace Report.Entity
{
    public class Report : EntityBase, IEntity
    {
        public string RequestLocation { get; set; }
        public DateTime RequestDate { get; set; }
        public ReportStatus ReportStatus { get; set; }
        public string? Value { get; set; }
    }
}
