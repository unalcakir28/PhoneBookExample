using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Business
{
    public interface IMQService
    {
        public void SendNewReportRequest(int reportId);
    }
}
