namespace TmBussines.WebServerOffice.Data
{
    public class AsduTm3Core
    {
        public long Id { get; set; }
        public DateTime DateStamp { get; set; }
        public long SerialNumber { get; set; }
        public string? Mac1char { get; set; }
        public string? Mac2char { get; set; }
        public long Mac1int { get; set; }
        public long Mac2int { get; set; }
        public string? Description { get; set; }

    }
}
