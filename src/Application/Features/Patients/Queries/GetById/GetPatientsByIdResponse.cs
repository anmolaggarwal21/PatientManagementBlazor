using System;
using WarehouseManger.Domain.Enums;

namespace WarehouseManger.Application.Features.Patients.Queries.GetById
{
    public class GetPatientsByIdResponse
    {
        public int Id { get; set; }
        public string OPDId { get; set; }

        public string FirstName { get; set; }

       public string LastName { get; set; }

         public DateTime? DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public long PhoneNumber { get; set; }


        public string? EmailAddress { get; set; }

        public string? Address { get; set; }

    }
}