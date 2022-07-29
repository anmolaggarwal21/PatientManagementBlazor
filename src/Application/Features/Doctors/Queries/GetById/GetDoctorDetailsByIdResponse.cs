using System;

namespace WarehouseManger.Application.Features.Doctors.Queries.GetById
{
    public class GetDoctorDetailsByIdResponse
    {
        public int Id { get; set; }
        public Guid DoctorId { get; set; }

        public string? DoctorName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Department { get; set; }
    }
}