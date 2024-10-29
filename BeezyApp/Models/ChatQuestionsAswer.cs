using BeezyApp.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeezyApp.Models
{
    public class ChatQuestionsAswer
    {
        public int ChatQuestionsAswersId { get; set; }

        public int UserId { get; set; }

        public string ChatQuestionsAswersText { get; set; } = null!;

        public DateTime ChatQuestionsAswersTime { get; set; }

        public string? ChatQuestionsAswersPic { get; set; }

        public ChatQuestionsAswer (){}
       
    }
}
