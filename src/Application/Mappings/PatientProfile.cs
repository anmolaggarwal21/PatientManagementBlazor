using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManger.Application.Features.Patients.Commands.AddEdit;
using WarehouseManger.Application.Features.Patients.Queries.GetAllPaged;
using WarehouseManger.Application.Features.Patients.Queries.GetById;
using WarehouseManger.Domain.Entities.Clinic;

namespace WarehouseManger.Application.Mappings
{
    

    public class PatientProfile : Profile
    {
        public PatientProfile()
        {

            CreateMap<AddEditPatientCommand, Patient>().ReverseMap();
            CreateMap<GetPatientsByIdResponse, Patient>().ReverseMap();
            
        }
    }
}
