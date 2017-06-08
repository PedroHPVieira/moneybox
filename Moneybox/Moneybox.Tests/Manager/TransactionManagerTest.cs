using Business;
using Business.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Moneybox.Tests.Manager
{
    [TestClass]
    public class TransactionManagerTest : IDisposable
    {
        private Mock<IAdapter> _adapter;
        public TransactionManagerTest()
        {
            _adapter = new Mock<IAdapter>();
        }

        [TestMethod]
        public void DeleteWithoutTransactionIdTest()
        {
            var manager = new TransactionManager(_adapter.Object);

            _adapter.Setup(t => t.GetTransaction(It.IsAny<int>())).Returns((Transaction)null);

            var result = manager.RemoveTransaction(10);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void DeleteTransactionTest()
        {
            var manager = new TransactionManager(_adapter.Object);

            _adapter.Setup(t => t.GetTransaction(It.IsAny<int>())).Returns(new Transaction() { });
            _adapter.Setup(t => t.DeleteTransaction(It.IsAny<int>())).Returns(true);

            var result = manager.RemoveTransaction(10);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void UpdateInvalidTransactionIdTest()
        {
            var manager = new TransactionManager(_adapter.Object);

            _adapter.Setup(t => t.GetTransaction(It.IsAny<int>())).Returns((Transaction)null);

            var result = manager.ModifyTransaction(new Transaction()
            {
                Id = 10,
                Description = "Description test",
                TransactionAmount = 20,
                CurrencyCode = "BR",
                Merchant = "Merchant test"
            });
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void UpdateTransactionTest()
        {
            var manager = new TransactionManager(_adapter.Object);

            _adapter.Setup(t => t.GetTransaction(It.IsAny<int>())).Returns(new Transaction());
            _adapter.Setup(t => t.UpdateTransaction(It.IsAny<Transaction>())).Returns(true);

            var result = manager.ModifyTransaction(new Transaction()
            {
                Id = 10,
                Description = "Description test",
                TransactionAmount = 20,
                CurrencyCode = "BR",
                Merchant = "Merchant test"
            });
            Assert.AreEqual(true, result);
        }

        public void Dispose()
        {
            _adapter.VerifyAll();
        }
    }
}
