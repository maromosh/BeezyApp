using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeezyApp.Models
{
    public class ChatBeekeeper
    {
        public int ChatBeekeepers { get; set; }

        public int BeeKeeperId { get; set; }

        public string ChatBeekeepersText { get; set; } = null!;

        public DateTime ChatBeekeepersTime { get; set; }

        public string? ChatBeekeepersPic { get; set; }

        public ChatBeekeeper() {}

    }
}
