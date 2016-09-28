namespace DTOs.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Skill
    {
        [Key]
        public int SkillId { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
