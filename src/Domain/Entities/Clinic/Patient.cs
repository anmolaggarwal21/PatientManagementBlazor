using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WarehouseManger.Domain.Contracts;
using WarehouseManger.Domain.Enums;

namespace WarehouseManger.Domain.Entities.Clinic
{

    public class Patient : AuditableEntity<int>
    {
        public Guid PatientId { get; set; }

        public string OPDId { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        [MaxLength(100, ErrorMessage = "Maximum Character can be 100")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        [MaxLength(100, ErrorMessage = "Maximum Character can be 100")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of Birth is Required")]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [RangeAttribute(1000000000, 9999999999, ErrorMessage = "Must be of exactly of 10 digits ")]
        public long PhoneNumber { get; set; }


        public string? EmailAddress { get; set; }

        public string? Address { get; set; }

        public virtual List<PatientVisit>? PatientVisitsHistory { get; set; }



    }
}
