using SQLite;
using System;

namespace MentalHealthApp.Models
{
    public class EmotionRecord
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Emotion { get; set; } = string.Empty;
        public string Activities { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
