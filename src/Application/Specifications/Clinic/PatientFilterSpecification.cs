using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManger.Application.Specifications.Base;
using WarehouseManger.Domain.Entities.Clinic;

namespace WarehouseManger.Application.Specifications.Clinic
{
    


    public class PatientFilterSpecification : HeroSpecification<Patient>
    {
        public PatientFilterSpecification(string searchString)
        {
            //Includes.Add(a => a.Brand);
            if (!string.IsNullOrEmpty(searchString))
            {
                Criteria = p => p.OPDId != null && (p.FirstName.Contains(searchString) || p.LastName.Contains(searchString) || p.OPDId.Contains(searchString));
            }
            else
            {
                Criteria = p => p.OPDId != null;
            }
        }
    }
}
