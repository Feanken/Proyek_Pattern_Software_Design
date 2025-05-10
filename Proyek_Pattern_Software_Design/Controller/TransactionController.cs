using Proyek_Pattern_Software_Design.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyek_Pattern_Software_Design.Handler;

namespace Proyek_Pattern_Software_Design.Controller
{
    public class TransactionController
    {
        TransactionHandler transactionHandler = new TransactionHandler();
        public TransactionController() { }

        public List<TransactionHeader> getAllTransactions()
        {
            return transactionHandler.getAllTransactions();
        }
        public bool UpdateTransactionStatus(int transactionId, string newStatus)
        {
            return transactionHandler.updateTransactionStatus(transactionId, newStatus);
        }
        public List<TransactionHeader> getTransaction()
        {
            return transactionHandler.getTransaction();
        }

        public void createTransaction(int userID, string paymentMethod)
        {
            transactionHandler.createTransaction(userID, paymentMethod);
        }
    }
}