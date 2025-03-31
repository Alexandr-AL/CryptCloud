namespace CryptCloud.Models
{
    public class Disk
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double TotalSpaceInMegaBytes { get; set; }
        public double FreeSpaceInMegaBytes { get; set; }
        public double UsedSpaceInMegaBytes { get; set; }
        
    }
}
