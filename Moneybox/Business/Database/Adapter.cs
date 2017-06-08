using Business.Database;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace Business
{
    public interface IAdapter
    {
        Transaction GetTransaction(int id);
        List<Transaction> GetAllTransactions();
        int CreateTransaction(Transaction transaction);
        bool UpdateTransaction(Transaction transaction);
        bool DeleteTransaction(int id);
    }

    public class Adapter : IAdapter
    {
        public Transaction GetTransaction(int id)
        {
            using (var context = new TransactionCodeFirstModel())
            {
                Transaction tran = context.Transaction.Where(c => c.Id == id).FirstOrDefault();

                if (tran != null)
                    return tran;

                return null;
            }
        }

        public List<Transaction> GetAllTransactions()
        {
            using (var context = new TransactionCodeFirstModel())
            {
                List<Transaction> lstTrans = context.Transaction.ToList();

                if (lstTrans.Count > 0)
                    return lstTrans;

                return null;
            }
        }

        public int CreateTransaction(Transaction transaction)
        {
            try
            {
                using (var context = new TransactionCodeFirstModel())
                {
                    Transaction tran = new Transaction();
                    tran.TransactionDate = transaction.TransactionDate;
                    tran.Description = transaction.Description;
                    tran.TransactionAmount = transaction.TransactionAmount;
                    tran.CreatedDate = DateTime.UtcNow;
                    tran.ModifiedDate = DateTime.UtcNow;
                    tran.CurrencyCode = transaction.CurrencyCode;
                    tran.Merchant = transaction.Merchant;

                    context.Transaction.Add(tran);
                    context.SaveChanges();

                    return tran.Id;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public bool UpdateTransaction(Transaction transaction)
        {
            try
            {
                using (var context = new TransactionCodeFirstModel())
                {
                    Transaction tran = context.Transaction.Where(c => c.Id == transaction.Id).FirstOrDefault();

                    tran.Description = transaction.Description;
                    tran.TransactionAmount = transaction.TransactionAmount;
                    tran.ModifiedDate = DateTime.UtcNow;
                    tran.CurrencyCode = transaction.CurrencyCode;
                    tran.Merchant = transaction.Merchant;

                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteTransaction(int id)
        {
            try
            {
                using (var context = new TransactionCodeFirstModel())
                {
                    Transaction tran = context.Transaction.Where(c => c.Id == id).FirstOrDefault();
                    context.Transaction.Remove(tran);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
