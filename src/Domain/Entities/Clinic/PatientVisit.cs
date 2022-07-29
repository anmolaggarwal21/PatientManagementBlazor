using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManger.Domain.Contracts;
using WarehouseManger.Domain.Enums;

namespace WarehouseManger.Domain.Entities.Clinic
{

    public class PatientVisit :  AuditableEntity<int>
    {
        public Guid? PatientVisitId { get; set; }

        [Required]
        public DateTime? DateOfVisit { get; set; }

        [Required]
        public AdmissionType admission { get; set; }

        public int? PatientDetailsId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public int DoctorDetailsId { get; set; }

        public string? Treatment { get; set; }

        [Required]
        public PaymentType PaymentType { get; set; }

        public DateTime? DateOfDischarge { get; set; }



        public virtual Patient Patient { get; set; }

        public virtual DoctorDetails DoctorDetails { get; set; }
    }
}
