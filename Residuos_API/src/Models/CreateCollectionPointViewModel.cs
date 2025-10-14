namespace RecyclingManagementAPI.Models
{
    public class CreateCollectionPointViewModel
    {
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Capacity { get; set; }
    }
}
