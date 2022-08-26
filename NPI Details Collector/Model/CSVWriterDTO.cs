using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPI_Details_Collector.Model
{
    internal class CSVWriterDTO
    {
            public long UserWaveId { get; set; }
            public long NPI { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public DateTime CertificateLastUpdatedDate { get; set; }
            public string? Status { get; set; }
            public string? PracticeAddress { get; set; }
            public string? StreetAddress { get; set; }
            public string? City { get; set; }
            public string? State { get; set; }
            public long? PostalCode { get; set; }
            public string? Contact { get; set; }
            public string? Taxonomy { get; set; }
    }
}
