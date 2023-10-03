namespace YBS.Services.DataHandler.Requests.DockRequests
{
    public class DockUpdateRequest
    {
        public int ID { get; set; }
        public int CompanyID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public float Lattiude { get; set; }
        public float Longtiude { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}