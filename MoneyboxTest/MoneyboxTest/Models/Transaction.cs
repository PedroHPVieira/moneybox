using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyboxTest.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public decimal TransactionAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CurrencyCode { get; set; }
        public string Merchant { get; set; }

        public Transaction()
        {

        }
    }
}