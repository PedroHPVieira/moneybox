using MoneyboxTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyboxTest.Controllers
{
    public class TransactionController : Controller
    {
        // It gets a specific transaction. It receives a id as a parameter.
        public ActionResult Index(int id)
        {
            return View();
        }

        //It'll get all the transactions in the database
        public ActionResult GetAllTransactions()
        {

        }

        //It'll delete a specific transaction where It'll receive a id as a parameter
        public ActionResult DeleteTransaction(int id)
        {

        }
        
        //It'll update the infos about the transaction. It receives a transaction object as a parameter.
        public ActionResult UpdateTransaction(Transaction transaction)
        { 

        }

        //It'll create a new transaction in the database and receives a transaction object as a parameter.
        public ActionResult CreateTransaction(Transaction transaction)
        {

        }
    }
}