using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManger.Application.Requests.Clinic
{
   
    public class GetAllPagedPatientVisitRequest : PagedRequest
    {
        public string SearchString { get; set; }

        public int PatientId { get; set; }
    }
}

