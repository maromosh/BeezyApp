using BeezyApp.Models;
using System.ComponentModel.DataAnnotations;

namespace BeezyApp.Models
{
    public class ChatPic
    {
        public int ChatPicId { get; set; }

        public int? ChatQuestionsAswersId { get; set; }

        public string? ChatPicEx { get; set; }

        public ChatPic() { }
        
    }
}
