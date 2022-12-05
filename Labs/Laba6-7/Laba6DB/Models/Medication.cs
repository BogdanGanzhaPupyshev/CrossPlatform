using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba6DB.Models
{
    public class Medication
    {
        [Key]
        public int MedicationId { get; set; }
        public int? MedicationTypeCode { get; set; }
        public double MedicationUnitCost { get; set; }
        public string MedicationName { get; set; }
        public string MedicationDescription { get; set; }
        public string Details { get; set; }

        [ForeignKey("MedicationTypeCode")]
        public virtual RefMedicationTypes MedicationTypes { get; set; }
    }
}
