using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NESReportsDTO
{
    /// <summary>
    /// AV Report Common Structure Report
    /// </summary>
    public class AVReportDTO
    {
        public List<Column> columns { get; set; }

        public dynamic data { get; set; }

        [System.ComponentModel.DefaultValue("per(%)")]
        public string sorting { get; set; }

        public List<Column> footerTotalColumns { get; set; }
    
    }


    public class Column
    {
        public string name { get; set; }
        public string align { get; set; }
    }
}

