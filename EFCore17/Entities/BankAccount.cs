using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore17.Entities
{
    public class BankAccount
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
    
        public string AccountHolder { get; set; }
        public decimal CurrentBalance { get; set; }

        public List<GLTransaction> GLTransactions { get; set; } = new List<GLTransaction>();


        public void Deposit(decimal ammount)
        {
            if (ammount > 0)
            {
                CurrentBalance += ammount;
                GLTransactions.Add(new GLTransaction(ammount, "Deposit", DateTime.Now));

            }
        }


        public void WithDrow(decimal ammount)
        {
            if (ammount > 0 && CurrentBalance >= ammount) 
            {
                CurrentBalance -= ammount;
                GLTransactions.Add(new GLTransaction(-ammount , "WithDrow", DateTime.Now)) ;

            }
        }
        public override string ToString()
        {
            return $"{AccountId} => ({AccountHolder}) => ({CurrentBalance})";
        }
    }

}

