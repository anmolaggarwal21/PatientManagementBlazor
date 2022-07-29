namespace WarehouseManger.Application.Requests.Clinic
{
    public class GetAllPagedPatientsRequest : PagedRequest
    {
        public string SearchString { get; set; }
    }
}