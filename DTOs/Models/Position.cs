namespace DTOs.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Position
    {
        public Position()
        {
            this.RequiredSkills = new HashSet<Skill>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string PositionName { get; set; }

        [Required]
        public string Description { get; set; }

        public long CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public virtual ICollection<Skill> RequiredSkills { get; set; }
    }
}
