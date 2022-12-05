using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba6DB.Models
{
    public class Patients
    {
        [Key]
        public int PatientID { get; set; }
        public int FirstName { get; set; }
        public int MiddleName { get; set; }
        public int LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Details { get; set; }
    }
}
