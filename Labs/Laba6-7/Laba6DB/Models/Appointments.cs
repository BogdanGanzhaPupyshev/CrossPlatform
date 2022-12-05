using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Laba6DB.Models
{
    public class Appointments
    {
        [Key]
        public int AppointmentId { get; set; }
        public int? PatientId { get; set; }
        public int? StaffId { get; set; }
        public DateTime DateOfAppointment { get; set; }
        public string Details { get;set; }

        [ForeignKey("PatientId")]
        public virtual Patients Patients { get; set; }

        [ForeignKey("StaffId")]
        public virtual Staff Staff { get; set; }
    }
}
