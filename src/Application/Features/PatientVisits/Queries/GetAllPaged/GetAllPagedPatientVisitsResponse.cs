using System;
using WarehouseManger.Domain.Entities.Clinic;
using WarehouseManger.Domain.Enums;

namespace WarehouseManger.Application.Features.PatientVisits.Queries.GetAllPaged
{
    public class GetAllPagedPatientVisitsResponse
    {
        public int Id { get; set; }
        public Guid? PatientVisitId { get; set; }

       
        public DateTime? DateOfVisit { get; set; }

        
        public AdmissionType admission { get; set; }

        public int? PatientDetailsId { get; set; }

        
        public decimal Amount { get; set; }

        public int DoctorDetailsId { get; set; }

        public string? Treatment { get; set; }

       
        public PaymentType PaymentType { get; set; }

        public DateTime? DateOfDischarge { get; set; }



        public virtual Patient Patient { get; set; }

        public virtual DoctorDetails DoctorDetails { get; set; }
    }
}