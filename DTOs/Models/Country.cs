using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Models
{
    public class Country
    {
        [Column("id")]
        public int CountryId { get; set; }

        [Column("name")]
        public string Name { get; set; } // Fucked up shit -> SHOULD BE REMOVED

        [StringLength(5)]
        [Column("iso")]
        public string Iso { get; set; }

        [StringLength(5)]
        [Column("iso3")]
        public string Iso3 { get; set; }

        [Column("numcode")]
        public int? NumCode { get; set; }   

        [Column("nicename")]
        public string NiceName { get; set; }

        [Column("phonecode")]
        public int PhoneCode { get; set; }
    }
}
