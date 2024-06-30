using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UploadToSheets.DBContext;
using UploadToSheets.DTOS;
using UploadToSheets.Models;

namespace UploadToSheets.Services
{
    public class CSVConverterClass
    {
        readonly string path = @"C:\Users\artel\Desktop\OpenOrderTest.csv";
        private DataTable table;
        public CSVConverterClass() 
        {
           table=ReadTsvToDataTable();
        }
        public DataTable ReadTsvToDataTable()
        {
            DataTable dataTable = new DataTable();

            using (var reader = new StreamReader(path))
            {
                string headerLine = reader.ReadLine();
                if (headerLine != null)
                {
                    string[] headers = headerLine.Split('\t');
                    foreach (var header in headers)
                    {
                        dataTable.Columns.Add(header.Trim('"'));
                    }

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] fields = line.Split('\t');
                        for (int i = 0; i < fields.Length; i++)
                        {
                            fields[i] = fields[i].Trim('"');
                        }
                        DataRow row = dataTable.NewRow();
                        row.ItemArray = fields;
                        dataTable.Rows.Add(row);
                    }
                }
            }
            return dataTable;

        }
        public async void UploadToDb()
        {
            table = ReadTsvToDataTable();
            using (var context = new ApplicationDbContext())
            {

                foreach (DataRow row in table.Rows)
                {
                    string orderId = row[1].ToString();
                    var existingCustomer = context.CustomerInfos
                    .FirstOrDefault(c => c.OrderId == orderId);
                    if(existingCustomer == null) {
                        var customer = new CustomerInfo
                        {
                            OrderId = row[1].ToString(),
                            ChannelReference = row[2].ToString(),
                            CustomerName = row[0].ToString(),
                        };
                        context.CustomerInfos.Add(customer);
                    }

                    var existingOrder= context.Histories
                    .FirstOrDefault(c => c.Orderid == orderId);

                    if(existingOrder == null)
                    {
                        int qty;
                        if (Int32.TryParse(row[4].ToString(), out qty))
                        {
                            string sku = row[3].ToString();
                            if (qty > 1 && (Regex.IsMatch(sku, @"^L\d+.*$") || Regex.IsMatch(sku, @"^C\d+.*$")))
                            {
                                for (int i = 0; i < qty; i++)
                                {
                                    var order = new History
                                    {
                                        Orderid = row[1].ToString(),
                                        Sku = row[3].ToString(),
                                        Qty = "1",
                                        Channel = row[5].ToString(),

                                    };
                                    context.Histories.Add(order);
                                }
                            }
                            else
                            {
                                var order = new History
                                {
                                    Orderid = row[1].ToString(),
                                    Sku = row[3].ToString(),
                                    Qty = row[4].ToString(),
                                    Channel = row[5].ToString(),

                                };
                                context.Histories.Add(order);
                            }
                        }
                    }

                  
                }

                context.SaveChanges();
            }
        }
    }
}
