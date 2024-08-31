using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManagement.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Category() { }

        public Category(int id, string name, string type, string description, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Name = name;
            Type = type;
            Description = description;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
            Type = null;
            Description = null;
            CreatedAt = DateTime.MinValue;
            UpdatedAt = DateTime.MinValue;
        }
    }

    
}
