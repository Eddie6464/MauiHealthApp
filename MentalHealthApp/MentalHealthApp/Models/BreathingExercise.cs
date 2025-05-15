using SQLite;
using System;

namespace MentalHealthApp.Models
{
    public class BreathingExercise
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Steps { get; set; } = string.Empty;
        public int DurationMinutes { get; set; }
    }
}
