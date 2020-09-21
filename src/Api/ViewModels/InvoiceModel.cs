using System;
using System.Collections.Generic;

namespace Api.ViewModels
{
    /// <summary>
    /// A View Model for SalesOrderItemModel
    /// </summary>
    public class InvoiceModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int CustomerId { get; set; }
        public List<SalesOrderItemModel> LineItems { get; set; }
    }    
}