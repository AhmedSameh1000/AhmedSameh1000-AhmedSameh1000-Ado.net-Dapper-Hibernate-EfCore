using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore17.Entities
{
    public class GLTransaction
    {
        public GLTransaction(decimal amount, string notes, DateTime createdAt)
        {
            Amount = amount;
            Notes = notes;
            CreatedAt = createdAt;
        }

        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public int BankAccountId {  get; set; }
        public BankAccount BankAccount {  get; set; } 


    }
}
