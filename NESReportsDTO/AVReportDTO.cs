using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NESReportsDTO
{
    public class AVReportDTO
    {
        public List<string> columns { get; set; }
        public dynamic data { get; set; }
        [System.ComponentModel.DefaultValue("per(%)")]
        public string sorting { get; set; }
        public List<string> footerTotalColumns { get; set; }

    }

}

