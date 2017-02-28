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
            this.Positions = new HashSet<Position>();
        }

        public Skill(string name)
        {
            this.Name = name;
            this.IsDeleted = false;
        }

        [Key]
        public int SkillId { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Position> Positions { get; set; }
    }
}
