namespace DTOs.Models
{
    using global::Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Experience
    {
        public Experience() { }

        public Experience(ExperienceViewModel source)
        {
            this.PositionDiscription = source.Description;
            this.FromDate = source.StartDate.Value;
            this.ToDate = source.EndDate;
            this.PositionName = source.Position;
        }

        [Key]
        public int ExperienceId { get; set; }

        public string PositionName { get; set; }

        public string PositionDiscription { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
