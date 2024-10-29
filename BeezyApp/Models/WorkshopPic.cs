using BeezyApp.Models;
using System.ComponentModel.DataAnnotations;

namespace BeezyApp.Models
{
    public class WorkshopPic
    {
        public int WorkshopPicId { get; set; }

        public int? WorkshopId { get; set; }

        public string? WorkshopPicEx { get; set; }

        public WorkshopPic() { }
        
    }
}
