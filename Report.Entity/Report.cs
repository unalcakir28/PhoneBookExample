using Report.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
