using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba6DB.Models
{
    public class RefMedicationTypes
    {
        [Key]
        public int MedicationTypeCode { get; set; }
        public string MedicationTypeName { get; set; }
        public string MedicationTypeDescription { get; set; }

    }
}
