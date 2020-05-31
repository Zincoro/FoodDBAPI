using System;
using System.Collections.Generic;

namespace FoodAPI.Models
{
    public partial class UserTable
    {
        public UserTable()
        {
            SavedFoodTable = new HashSet<SavedFoodTable>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Pword { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }

        public virtual ICollection<SavedFoodTable> SavedFoodTable { get; set; }
    }
}
