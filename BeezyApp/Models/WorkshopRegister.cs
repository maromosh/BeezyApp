using BeezyApp.Models;

namespace BeezyApp.Models
{
    public class WorkshopRegister
    {
        public int WorkshopRegisters { get; set; }

        public int? WorkshopId { get; set; }

        public int UserId { get; set; }

        public bool WorkshopRegistersIsPaid { get; set; }

        public WorkshopRegister() { }
       
    }
}
