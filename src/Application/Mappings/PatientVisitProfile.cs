using AutoMapper;
using WarehouseManger.Application.Features.PatientVisits.Commands.AddEdit;
using WarehouseManger.Domain.Entities.Clinic;

namespace WarehouseManger.Application.Mappings
{

    public class PatientVisitProfile : Profile
    {
        public PatientVisitProfile()
        {

            CreateMap<AddEditPatientVisitCommand, PatientVisit>().ReverseMap();
        }
    }
}
