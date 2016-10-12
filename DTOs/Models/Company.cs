namespace DTOs.Models
{
    using System.Collections.Generic;

    public class Company
    {
        public Company()
        {
            this.Sectors = new HashSet<Sector>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Sector> Sectors { get; set; }
    }
}
