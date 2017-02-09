namespace DTOs.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Skill
    {
        public Skill()
        {
            this.Users = new HashSet<User>();
        }

        [Key]
        public int SkillId { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
