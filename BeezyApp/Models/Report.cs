using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeezyApp.Models
{
    public class Report
    {
        public int ReportId { get; set; }

        public int UserId { get; set; }

        public int? BeeKeeperId { get; set; }

        public decimal? ReportLocation { get; set; }

        public string ReportDirectionsExplanation { get; set; } = null!;

       public string ReportUserNumber { get; set; } = null!;

        public string ReportExplanation { get; set; } = null!;

        public Report() { }
        
    }
}
