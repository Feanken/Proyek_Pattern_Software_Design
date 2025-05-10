using Proyek_Pattern_Software_Design.Connection;
using Proyek_Pattern_Software_Design.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyek_Pattern_Software_Design.Repository
{
    public class TransactionRepository
    {
        Database1Entities db = DatabaseConnection.getInstance().getDB();
        public List<TransactionHeader> GetUnfinishedOrders()
        {
            return db.TransactionHeaders
                     .Where(t => t.TransactionStatus != "Done" && t.TransactionStatus != "Rejected")
                     .ToList();
        }

        public bool UpdateTransactionStatus(int transactionId, string newStatus)
        {
            TransactionHeader transaction = db.TransactionHeaders.Where(t => t.TransactionID == transactionId).FirstOrDefault();
            if (transaction == null) return false;

            transaction.TransactionStatus = newStatus;
            db.SaveChanges();
            return true;
        }
        public List<TransactionHeader> getTransaction()
        {
            //return db.TransactionHeaders
            //     .Include("TransactionDetails") 
            //     .Where(t => t.TransactionStatus == "Done")
            //     .ToList();
            return db.TransactionHeaders.ToList();
        }
    }
}