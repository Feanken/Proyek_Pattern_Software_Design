using Proyek_Pattern_Software_Design.Model;
using Proyek_Pattern_Software_Design.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyek_Pattern_Software_Design.Handler
{
	public class TransactionHandler
    {
        TransactionRepository transactionRepository = new TransactionRepository();
        CartRepository cartRepository = new CartRepository();

        public TransactionHandler()
        {
        }
        public List<TransactionHeader> getAllTransactions()
        {
            return transactionRepository.GetUnfinishedOrders();
        }
        public bool updateTransactionStatus(int transactionId, string newStatus)
        {
            return transactionRepository.UpdateTransactionStatus(transactionId, newStatus);
        }

        public List<TransactionHeader> getTransaction()
        {
            return transactionRepository.getTransaction();
        }

        public void createTransaction(int userID, string paymentMethod)
        {
            transactionRepository.createTransaction(userID, paymentMethod);
        }
        public List<TransactionHeader> getTransactionsByUserId(int userId)
        {
            return transactionRepository.getTransactionByUserId(userId);
        }
        public List<TransactionDetailModel> getTransactionDetailByTransactionId(int transactionId)
        {
            return transactionRepository.getTransactionDetailByTransactionId(transactionId);
        }
    }
}