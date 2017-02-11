namespace DTOs.Models
{
    using global::Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Skill
    {
        public Skill()
        {
            this.Users = new HashSet<User>();
        }

        public Skill(SkillDtoWriteModel source)
        {
            this.Name = source.Name;
            this.IsDeleted = false;
        }

        [Key]
        public int SkillId { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
