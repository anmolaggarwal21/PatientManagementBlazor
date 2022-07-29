using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManger.Application.Features.Brands.Queries.GetAll;
using WarehouseManger.Application.Features.Brands.Queries.GetById;
using WarehouseManger.Application.Features.Doctors.Commands.AddEdit;
using WarehouseManger.Application.Features.Doctors.Queries.GetAll;
using WarehouseManger.Application.Features.Doctors.Queries.GetById;
using WarehouseManger.Domain.Entities.Clinic;

namespace WarehouseManger.Application.Mappings
{
    

    public class DoctorDetailsProfile : Profile
    {
        public DoctorDetailsProfile()
        {
            
           CreateMap<AddEditDoctorDetailsCommand, DoctorDetails>().ReverseMap();
            CreateMap<GetDoctorDetailsByIdResponse, DoctorDetails>().ReverseMap();
            CreateMap<GetAllDoctorDetailsResponse, DoctorDetails>().ReverseMap();
        }
    }
}
