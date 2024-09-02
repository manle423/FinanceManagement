using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManagement.Models
{
    internal class Goal
    {
        public int Id {  get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}

        public Goal() { }
        public Goal(int id, int userId, string name, decimal targetAmount, decimal currentAmount, DateTime deadline, string description, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            UserId = userId;
            Name = name;
            TargetAmount = targetAmount;
            CurrentAmount = currentAmount;
            Deadline = deadline;
            Description = description;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
