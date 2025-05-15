using SQLite;
using System;

namespace MentalHealthApp.Models
{
    public class ActivityLog
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string ActivityType { get; set; } = string.Empty;
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime? EndTime { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}
