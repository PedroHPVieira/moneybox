namespace Business.Database
{
    using System.Data.Entity;

    public partial class TransactionCodeFirstModel : DbContext
    {
        public TransactionCodeFirstModel()
            : base("name=TransactionCodeFirstModel")
        {
        }

        public virtual DbSet<Transaction> Transaction { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
