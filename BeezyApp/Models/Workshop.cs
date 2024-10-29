using BeezyApp.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeezyApp.Models
{
    public class Workshop
    {
        public int WorkshopId { get; set; }

        public int BeeKeeperId { get; set; }

        public string WorkshopName { get; set; } = null!;

        public DateTime WorkshopDate { get; set; }

        public string WorkshopPrice { get; set; } = null!;

        public int WorkshopMaxReg { get; set; }

        public string WorkshopDescription { get; set; } = null!;

        public Workshop() { }
        
    }
}
