namespace DTOs.Models
{
    using global::Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Company
    {
        public Company()
        {
            this.Sectors = new HashSet<Sector>();
            this.Positions = new HashSet<Position>();
        }

        public Company(CompanyRegistration source)
        {
            this.Email = source.Email;
            this.CountryId = source.CountryId;
            this.Name = source.CompanyName;
            this.Password = source.Password;
        }

        public Company(CompanyRegistration source, Sector sector) : this(source)
        {
            this.Sectors = new HashSet<Sector>();
            this.Sectors.Add(sector);
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        
        public int? CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Sector> Sectors { get; set; }

        public virtual ICollection<Position> Positions { get; set; }
    }
}
