using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManger.Client.Infrastructure.Routes
{
  

    internal class PatientVisitsEndpoints
    {
        public static string GetAllPaged(int pageNumber, int pageSize, string searchString, string[] orderBy, int patientId)
        {
            var url = $"api/v1/patientvisit/{patientId}?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
            if (orderBy?.Any() == true)
            {
                foreach (var orderByPart in orderBy)
                {
                    url += $"{orderByPart},";
                }
                url = url[..^1]; // loose training ,
            }
            return url;
        }

        public static string GetCount = "api/v1/patientvisit/count";

        public static string ExportFiltered(int patientId)
        {
            return $"{Export}/{patientId}";
        }

        public static string ExportFiltered( int patientId, string searchString )
        {
            return $"{Export}/{patientId}?searchString={searchString}";
        }

        public static string Save = "api/v1/patientvisit";
        public static string Delete = "api/v1/patientvisit";
        public static string Export = "api/v1/patientvisit/export";
    }
}
