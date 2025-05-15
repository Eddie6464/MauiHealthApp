using SQLite;
using System;

namespace MentalHealthApp.Models
{
    public class ChatMessage
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string UserMessage { get; set; } = string.Empty;
        public string BotResponse { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
