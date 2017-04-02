using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ArtPassWeb.Models
{
    public class RegistrantModel
    {
        [Key]
        public int RegistrantId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int HospitalId { get; set; }
        [ForeignKey("HospitalId")]
        public HospitalModel Hospital { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public int DaysStaying { get; set; }
        public string UnitAndRoomNumber { get; set; }
        [Required]
        public string Comments { get; set; }
    }
}
