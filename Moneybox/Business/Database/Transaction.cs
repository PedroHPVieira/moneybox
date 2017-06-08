namespace Business.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transaction")]
    public partial class Transaction
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Merchant { get; set; }

        public DateTime TransactionDate { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        public decimal TransactionAmount { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ModifiedDate { get; set; }

        [Required]
        [StringLength(10)]
        public string CurrencyCode { get; set; }
    }
}
