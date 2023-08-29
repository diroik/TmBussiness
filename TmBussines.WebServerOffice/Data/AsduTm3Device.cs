namespace TmBussines.WebServerOffice.Data
{
    public class AsduTm3Device
    {
        public long Id { get; set; }
        public DateTime DateStamp { get; set; }
        public string? AsduPartNumber { get; set; }
        public string? Description { get; set; }
        public string? MkddPartNumber { get; set; }
        public long CoreId { get; set; }

    }
}
