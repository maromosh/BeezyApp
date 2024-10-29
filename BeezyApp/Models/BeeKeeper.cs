using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeezyApp.Models
{
    public class BeeKeeper : User
    {
        public int BeeKeeperId { get; set; }

        public int BeekeeperRadius { get; set; }

        public string BeekeeperKind { get; set; } = null!;

        public bool BeekeeperIsActive { get; set; }

        public BeeKeeper() { }

       }
}
