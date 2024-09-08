using System;

namespace FinanceManagement.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CategoryName { get; set; }
        
        public decimal TotalSpent { get; set; }
        public decimal RemainingBudget { get; set; }
        public decimal BudgetProgressPercentage { get; set; }
        public string BudgetStatus { get; set; }

        public Budget() { }

        public Budget(int id, int userId, int categoryId, decimal amount, DateTime startDate, DateTime endDate, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            UserId = userId;
            CategoryId = categoryId;
            Amount = amount;
            StartDate = startDate;
            EndDate = endDate;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public Budget(int id, int userId, int categoryId, decimal amount)
        {
            Id = id;
            UserId = userId;
            CategoryId = categoryId;
            Amount = amount;
            StartDate = DateTime.MinValue;
            EndDate = DateTime.MinValue;
            CreatedAt = DateTime.MinValue;
            UpdatedAt = DateTime.MinValue;
        }

        public string ToString()
        {
            return this.CategoryName + " - " + this.Amount + " - " + this.EndDate;
        }
    }
}
