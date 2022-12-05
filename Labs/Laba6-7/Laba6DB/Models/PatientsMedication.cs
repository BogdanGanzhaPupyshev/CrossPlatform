using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba6DB.Models
{
    public class PatientsMedication
    {
        [Key]
        public int PatientMedicationId { get; set; }
        public int MedicationId { get; set; }
        public int PatientId { get; set; }
        public DateTime DateTimeAdministered { get; set; }
        public string Dosage { get; set; }
        public string Comments  { get; set; }
        public string Details { get;set; }

        [ForeignKey("MedicationId")]
        public virtual Medication Medication { get; set; }

        [ForeignKey("PatientId")]
        public virtual Patients Patients { get; set; }
    }
}
