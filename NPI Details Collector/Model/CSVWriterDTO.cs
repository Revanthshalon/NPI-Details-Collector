using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPI_Details_Collector.Model
{
    internal class CSVWriterDTO
    {
        public long UWID { get; set; }
        public long NPI { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Status { get; set; }
        public string? Taxonomy { get; set; }
    }
}
