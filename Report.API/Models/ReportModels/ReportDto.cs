
using Report.Entity;

namespace Contact.API.Models.ContactModels
{
    public class ReportDto
    {
        public int Id { get; set; }

        public string RequestLocation { get; set; }

        public DateTime RequestDate { get; set; }

        public ReportStatus ReportStatus { get; set; }

        public string Value { get; set; }

    }
}
