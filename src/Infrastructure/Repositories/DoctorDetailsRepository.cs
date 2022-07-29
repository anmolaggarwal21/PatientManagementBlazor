using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManger.Application.Interfaces.Repositories;
using WarehouseManger.Domain.Entities.Clinic;

namespace WarehouseManger.Infrastructure.Repositories
{
    

    public class DoctorDetailsRepository : IDoctorDetailsRepository
    {
        private readonly IRepositoryAsync<DoctorDetails, int> _repository;

        public DoctorDetailsRepository(IRepositoryAsync<DoctorDetails, int> repository)
        {
            _repository = repository;
        }
    }
}
