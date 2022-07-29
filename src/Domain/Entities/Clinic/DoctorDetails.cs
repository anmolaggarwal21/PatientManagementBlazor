using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManger.Domain.Contracts;

namespace WarehouseManger.Domain.Entities.Clinic
{
    public class DoctorDetails : AuditableEntity<int>
    {
        
        public Guid DoctorId { get; set; }
        [Required]
        [MaxLength(100)]
        public string? DoctorName { get; set; }

        public DateTime? DateOfBirth { get; set; }
        [Required]
        [MaxLength(100)]
        public string Department { get; set; }
    }
}
