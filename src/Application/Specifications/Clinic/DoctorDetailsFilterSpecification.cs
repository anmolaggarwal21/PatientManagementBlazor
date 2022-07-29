using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManger.Application.Specifications.Base;
using WarehouseManger.Domain.Entities.Clinic;

namespace WarehouseManger.Application.Specifications.Clinic
{
  

    public class DoctorDetailsFilterSpecification : HeroSpecification<DoctorDetails>
    {
        public DoctorDetailsFilterSpecification(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                Criteria = p => p.DoctorName.Contains(searchString) || p.Department.Contains(searchString);
            }
            else
            {
                Criteria = p => true;
            }
        }
    }
}
