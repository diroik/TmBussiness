namespace TmBussines.WebServerOffice.Data
{
    public class GsmM
    {
        public long Id { get; set; }
        public DateTime DateStamp { get; set; }
        public string? Imei { get; set; }
        public string? PartNumber { get; set; }
        public string? DeviceType { get; set; }
        public string? Description { get; set; }

    }
}
