using Business;
using Moneybox.Models;
using System.Web.Http;

namespace Moneybox.Controllers
{
    public class TransactionController : ApiController
    {
        // It gets a specific transaction. It receives a id as a parameter.
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var tranManager = new TransactionManager();
            var result = tranManager.Get(id);

            if (result != null)
                return Ok(result);

            return NotFound();
        }

        //It'll get all the transactions in the database
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var tranManager = new TransactionManager();
            var result = tranManager.GetAll();

            if (result != null && result.Count > 0)
                return Ok(result);

            return NotFound();
        }

        //It'll delete a specific transaction where It'll receive a id as a parameter
        [HttpDelete]
        public IHttpActionResult DeleteTransaction(int id)
        {
            var tranManager = new TransactionManager();
            var result = tranManager.RemoveTransaction(id);

            if (result)
                return Ok();

            return NotFound();
        }

        //It'll update the infos about the transaction. It receives a transaction object as a parameter.
        [HttpPut]
        public IHttpActionResult UpdateTransaction(TransactionModel transaction)
        {
            if (!ModelState.IsValid || transaction == null)
                return BadRequest();

            var tranManager = new TransactionManager();

            var result = tranManager.ModifyTransaction(new Business.Database.Transaction()
            {
                Id = transaction.Id,
                Description = transaction.Description,
                TransactionAmount = transaction.TransactionAmount,
                CurrencyCode = transaction.CurrencyCode,
                Merchant = transaction.Merchant
            });

            if (result)
                return Ok();

            return BadRequest();
        }

        //It'll create a new transaction in the database and receives a transaction object as a parameter.
        [HttpPost]
        public IHttpActionResult CreateTransaction(TransactionModel transaction)
        {
            if (!ModelState.IsValid || transaction == null)
                return BadRequest();

            var tranManager = new TransactionManager();
            var result = tranManager.InsertTransaction(new Business.Database.Transaction()
            {
                TransactionDate = transaction.TransactionDate,
                Description = transaction.Description,
                TransactionAmount = transaction.TransactionAmount,
                CurrencyCode = transaction.CurrencyCode,
                Merchant = transaction.Merchant
            });

            if (result > 0)
                return Ok(result);

            return BadRequest();
        }
    }
}