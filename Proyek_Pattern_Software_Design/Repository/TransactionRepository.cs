using Proyek_Pattern_Software_Design.Connection;
using Proyek_Pattern_Software_Design.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Proyek_Pattern_Software_Design.Repository
{
    public class TransactionRepository
    {
        Database1Entities db = DatabaseConnection.getInstance().getDB();
        CartRepository cartRepository = new CartRepository();
        JewelRepository jewelRepository = new JewelRepository();
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
            return db.TransactionHeaders
                 .Include("TransactionDetails")
                 .Where(t => t.TransactionStatus == "Done")
                 .ToList();

        }
        public void createTransaction(int userID, string paymentMethod)
        {
            TransactionHeader header = new TransactionHeader();
            header.UserID = userID;
            header.PaymentMethod = paymentMethod;
            header.TransactionDate = DateTime.Now;
            header.TransactionStatus = "Payment Pending";
            db.TransactionHeaders.Add(header);
            db.SaveChanges();

            var cartItems = cartRepository.GetCart(userID);

            foreach (var item in cartItems)
            {
                TransactionDetail detail = new TransactionDetail();
                detail.TransactionHeader = header;
                detail.JewelID = Convert.ToInt32(item.JewelID);
                detail.Quantity = item.Quantity;
                db.TransactionDetails.Add(detail);
                db.SaveChanges();
            }
        }
        public List<TransactionHeader> getTransactionByUserId(int userId)
        {
            return db.TransactionHeaders
                .Include("TransactionDetails")
                .Where(t => t.UserID == userId)
                .ToList();
        }   
        public List<TransactionDetailModel> getTransactionDetailByTransactionId(int transactionId)
        {
            List<TransactionDetailModel> transactionDetails = db.TransactionDetails
                                    .Where(td => td.TransactionID == transactionId)
                                    .Select(td => new TransactionDetailModel
                                    {
                                        TransactionID = td.TransactionID,
                                        JewelName = td.MsJewel.JewelName, 
                                        Quantity =(int)td.Quantity
                                    })
                                    .ToList();
            return transactionDetails;
        }
    }
}