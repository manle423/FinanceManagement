using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManagement.Models
{
    public enum eFrequency
    {
        Monthly,
        Yearly
    }

    public class RecurringTransaction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public eFrequency Frequency { get; set; } 
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public RecurringTransaction()
        {

        }

        public RecurringTransaction(
            int id, 
            int userId, 
            int categoryId,
            string categoryName,
            decimal amount, 
            DateTime startDate, 
            DateTime endDate,
            eFrequency frequency,
            string description, 
            DateTime createdAt, 
            DateTime updatedAt)
        {
            Id = id;
            UserId = userId;
            CategoryId = categoryId;
            CategoryName = categoryName;
            Amount = amount;
            StartDate = startDate;
            EndDate = endDate;
            Frequency = frequency;
            Description = description;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }

}
