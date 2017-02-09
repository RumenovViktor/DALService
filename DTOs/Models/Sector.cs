namespace DTOs.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Sector
    {
        public Sector()
        {
            this.Companies = new HashSet<Company>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
    }
}
