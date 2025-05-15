using SQLite;
using System;

namespace MentalHealthApp.Models
{
    public class StretchingExercise
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string MuscleGroup { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
