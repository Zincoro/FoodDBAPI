using System;
using System.Collections.Generic;

namespace FoodAPI.Models
{
    public partial class SavedFoodTable
    {
        public int SavedFoodId { get; set; }
        public string Uri { get; set; }
        public int? Uid { get; set; }

        public virtual UserTable U { get; set; }
    }
}
