using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManagement.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? RecurringId { get; set; }

        public Transaction()

        {

        }

        public Transaction(int id, int userId, int categoryId, decimal amount, DateTime transactionDate, string description, DateTime createdAt, DateTime updatedAt, int? recurringId)
        {
            Id = id;

            UserId = userId;
            CategoryId = categoryId;
            Amount = amount;
            TransactionDate = transactionDate;
            Description = description;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            RecurringId = recurringId;
        }
    }
}
