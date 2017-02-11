namespace DTOs.Models
{
    using global::Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Company
    {
        public Company()
        {
            this.Sectors = new HashSet<Sector>();
        }

        public Company(CompanyRegistration source)
        {
            this.Email = source.Email;
            this.Name = source.CompanyName;
            this.Password = source.Password;
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Sector> Sectors { get; set; }
    }
}
