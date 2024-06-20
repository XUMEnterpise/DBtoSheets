using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadToSheets.Models
{
    public class HistoryModel
    {
        public HistoryModel(int id, string orderId, string sKU, int qTY, string channel, DateOnly? date, bool isTested, string testedBy, string testStatus, string packedBy, DateTime? packedDate, string assignedNumber)
        {
            this.id = id;
            OrderId = orderId;
            SKU = sKU;
            QTY = qTY;
            Channel = channel;
            Date = date;
            IsTested = isTested;
            TestedBy = testedBy;
            TestStatus = testStatus;
            PackedBy = packedBy;
            PackedDate = packedDate;
            AssignedNumber = assignedNumber;
        }

        public int id { get; }
        public string OrderId { get; private set; }
        public string SKU { get; private set; }
        public int QTY { get; private set; }
        public string Channel { get; private set; }
        public DateOnly? Date { get; private set; }
        public bool IsTested { get; private set; }
        public string TestedBy { get; private set; }
        public string TestStatus { get; private set; }
        public string PackedBy { get; private set; }
        public DateTime? PackedDate { get; private set; }
        public string AssignedNumber { get; private set; }

    }
}
