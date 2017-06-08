using System;
using System.ComponentModel.DataAnnotations;

namespace Moneybox.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The transaction date is required.")]
        public DateTime TransactionDate { get; set; }

        [MaxLength(300, ErrorMessage = "The maximum size of the Description is 300.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Transaction Amount is required.")]
        public decimal TransactionAmount { get; set; }

        [Required(ErrorMessage = "The Currency code is required.")]
        public string CurrencyCode { get; set; }

        [MaxLength(100, ErrorMessage ="The maximum size of the Merchant is 100.")]
        public string Merchant { get; set; }      
    }
}