using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadToSheets.Models
{
    public class WindowsKeyModel
    {
        public WindowsKeyModel(DateOnly? date, string agent, string serviceTag, string windowsKey, bool? isActivated, string sku, string cpu, string windowsVersion)
        {
            this.Date = date;
            this.Agent = agent;
            this.ServiceTag = serviceTag;
            this.WindowsKey = windowsKey;
            this.IsActivated = isActivated;
            this.SKU = sku;
            this.CPU = cpu;
            this.WindowsVersion = windowsVersion;
        }

        public DateOnly? Date { get; }
        public string Agent { get; }
        public string ServiceTag { get; }
        public string WindowsKey { get; }
        public bool? IsActivated { get; }
        public string SKU { get; }
        public string CPU { get; }
        public string WindowsVersion { get; }
    }
}
