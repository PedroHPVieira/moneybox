using Business.Database;
using System.Collections.Generic;

namespace Business
{
    public class TransactionManager
    {
        private IAdapter _adapter;

        public TransactionManager()
        {
            _adapter = new Adapter();
        }

        public TransactionManager(IAdapter adapter)
        {
            _adapter = adapter;
        }

        public int InsertTransaction(Transaction transaction)
        {
            return _adapter.CreateTransaction(transaction);
        }

        public bool RemoveTransaction(int id)
        {
            var tran = _adapter.GetTransaction(id);

            if (tran != null)
                return _adapter.DeleteTransaction(id);

            return false;
        }

        public bool ModifyTransaction(Transaction transaction)
        {
            var tran = _adapter.GetTransaction(transaction.Id);

            if (tran != null)
                return _adapter.UpdateTransaction(transaction);

            return false;
        }

        public Transaction Get(int id)
        {
            return _adapter.GetTransaction(id);
        }

        public List<Transaction> GetAll()
        {
            return _adapter.GetAllTransactions();
        }
    }
}
