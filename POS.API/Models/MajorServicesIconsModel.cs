namespace POS.Models
{

    public partial class MajorServicesIconsModel
    {
        public int IconId { get; set; }
        public string IconName { get; set; }
        public int ServiceId { get; set; }
        public bool IsActive { get; set; }
        public int OrderId { get; set; }
        public string FolderPath { get; set; }
    }
}

