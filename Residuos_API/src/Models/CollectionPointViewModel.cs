using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclingManagementAPI.Models
{
    public class CollectionPointViewModel
    {
        public int Id { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public int CurrentWasteAmount { get; set; }
    }
}
