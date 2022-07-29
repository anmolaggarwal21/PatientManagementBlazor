using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManger.Application.Features.Doctors.Queries.GetAll
{

    public class GetAllDoctorDetailsResponse
    {
        public int Id { get; set; }
        public Guid DoctorId { get; set; }

        public string? DoctorName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Department { get; set; }
    }
    
}
