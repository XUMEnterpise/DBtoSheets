using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadToSheets.Models
{
    public  class ManifestModel
    {
        public ManifestModel(string prebuildId, string prebuildSKU, string orderId, string orderSku)
        {
            this.prebuildId = prebuildId;
            this.prebuildSKU = prebuildSKU;
            this.orderId = orderId;
            this.orderSku = orderSku;
        }

        public string prebuildId { get; }
        public string prebuildSKU { get; }
        public string orderId { get; }
        public string orderSku { get; }

    }
}
