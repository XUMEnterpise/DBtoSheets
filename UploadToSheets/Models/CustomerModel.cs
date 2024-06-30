using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadToSheets.Models
{
    public class CustomerModel
    {
        public CustomerModel(int iD, string orderId, string name, string channelRefferenc)
        {
            ID = iD;
            OrderId = orderId;
            Name = name;
            ChannelRefferenc = channelRefferenc;
        }

        public int ID { get; private set; }
        public string OrderId { get; private set; }
        public string Name { get; private set; }
        public string  ChannelRefferenc { get; private set; }

    }
}
