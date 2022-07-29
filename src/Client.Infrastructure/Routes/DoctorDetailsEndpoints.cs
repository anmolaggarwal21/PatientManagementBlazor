using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManger.Client.Infrastructure.Routes
{
    public  class DoctorDetailsEndpoints
    {
        public static string ExportFiltered(string searchString)
        {
            return $"{Export}?searchString={searchString}";
        }

        public static string Export = "api/v1/doctordetails/export";

        public static string GetAll = "api/v1/doctordetails";
        public static string Delete = "api/v1/doctordetails";
        public static string Save = "api/v1/doctordetails";
        public static string GetCount = "api/v1/doctordetails/count";
    }
}
