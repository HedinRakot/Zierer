using CoreBase.Entities;
using ProfiCraftsman.Contracts;
using System;
using System.Collections.Generic;

namespace ProfiCraftsman.Contracts.Entities
{
    public partial class Invoices: IHasId<int>
        ,IRemovable
        ,ISystemFields
    {
        /// <summary>
        /// Table name
        /// </summary>
        public static readonly string EntityTableName = "dbo.Invoices";
        #region Fields
        /// <summary>
        /// Columns names
        /// </summary>
        public static class Fields
        {
            /// <summary>
            /// Column name 'Id' for property <see cref="Invoices.Id"/>
            /// </summary>
            public static readonly string Id = "Id";
            /// <summary>
            /// Column name 'OrderId' for property <see cref="Invoices.OrderId"/>
            /// </summary>
            public static readonly string OrderId = "OrderId";
            /// <summary>
            /// Column name 'InvoiceNumber' for property <see cref="Invoices.InvoiceNumber"/>
            /// </summary>
            public static readonly string InvoiceNumber = "InvoiceNumber";
            /// <summary>
            /// Column name 'PayDate' for property <see cref="Invoices.PayDate"/>
            /// </summary>
            public static readonly string PayDate = "PayDate";
            /// <summary>
            /// Column name 'WithTaxes' for property <see cref="Invoices.WithTaxes"/>
            /// </summary>
            public static readonly string WithTaxes = "WithTaxes";
            /// <summary>
            /// Column name 'ManualPrice' for property <see cref="Invoices.ManualPrice"/>
            /// </summary>
            public static readonly string ManualPrice = "ManualPrice";
            /// <summary>
            /// Column name 'TaxValue' for property <see cref="Invoices.TaxValue"/>
            /// </summary>
            public static readonly string TaxValue = "TaxValue";
            /// <summary>
            /// Column name 'Discount' for property <see cref="Invoices.Discount"/>
            /// </summary>
            public static readonly string Discount = "Discount";
            /// <summary>
            /// Column name 'BillTillDate' for property <see cref="Invoices.BillTillDate"/>
            /// </summary>
            public static readonly string BillTillDate = "BillTillDate";
            /// <summary>
            /// Column name 'CreateDate' for property <see cref="Invoices.CreateDate"/>
            /// </summary>
            public static readonly string CreateDate = "CreateDate";
            /// <summary>
            /// Column name 'ChangeDate' for property <see cref="Invoices.ChangeDate"/>
            /// </summary>
            public static readonly string ChangeDate = "ChangeDate";
            /// <summary>
            /// Column name 'DeleteDate' for property <see cref="Invoices.DeleteDate"/>
            /// </summary>
            public static readonly string DeleteDate = "DeleteDate";
            /// <summary>
            /// Column name 'IsSellInvoice' for property <see cref="Invoices.IsSellInvoice"/>
            /// </summary>
            public static readonly string IsSellInvoice = "IsSellInvoice";
            /// <summary>
            /// Column name 'ReminderCount' for property <see cref="Invoices.ReminderCount"/>
            /// </summary>
            public static readonly string ReminderCount = "ReminderCount";
            /// <summary>
            /// Column name 'DateVExportDate' for property <see cref="Invoices.DateVExportDate"/>
            /// </summary>
            public static readonly string DateVExportDate = "DateVExportDate";
            /// <summary>
            /// Column name 'DateVExportFile' for property <see cref="Invoices.DateVExportFile"/>
            /// </summary>
            public static readonly string DateVExportFile = "DateVExportFile";
            /// <summary>
            /// Column name 'PayInDays' for property <see cref="Invoices.PayInDays"/>
            /// </summary>
            public static readonly string PayInDays = "PayInDays";
            /// <summary>
            /// Column name 'PayPartOne' for property <see cref="Invoices.PayPartOne"/>
            /// </summary>
            public static readonly string PayPartOne = "PayPartOne";
            /// <summary>
            /// Column name 'PayPartTwo' for property <see cref="Invoices.PayPartTwo"/>
            /// </summary>
            public static readonly string PayPartTwo = "PayPartTwo";
            /// <summary>
            /// Column name 'PayPartTree' for property <see cref="Invoices.PayPartTree"/>
            /// </summary>
            public static readonly string PayPartTree = "PayPartTree";
            /// <summary>
            /// Column name 'LastReminderDate' for property <see cref="Invoices.LastReminderDate"/>
            /// </summary>
            public static readonly string LastReminderDate = "LastReminderDate";
          
        }
        #endregion
        public int Id{ get; set; }
        public int OrderId{ get; set; }
        public string InvoiceNumber{ get; set; }
        public DateTime? PayDate{ get; set; }
        public bool WithTaxes{ get; set; }
        public double? ManualPrice{ get; set; }
        public double TaxValue{ get; set; }
        public double Discount{ get; set; }
        public DateTime? BillTillDate{ get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime ChangeDate{ get; set; }
        public DateTime? DeleteDate{ get; set; }
        public bool IsSellInvoice{ get; set; }
        public int ReminderCount{ get; set; }
        public DateTime? DateVExportDate{ get; set; }
        public string DateVExportFile{ get; set; }
        public int PayInDays{ get; set; }
        public int? PayPartOne{ get; set; }
        public int? PayPartTwo{ get; set; }
        public int? PayPartTree{ get; set; }
        public DateTime? LastReminderDate{ get; set; }
        public virtual Orders Orders{ get; set; }
        public virtual ICollection<InvoicePositions> InvoicePositions{ get; set; }
        public virtual ICollection<InvoicePayments> InvoicePayments{ get; set; }
        public virtual ICollection<InvoiceStornos> InvoiceStornos{ get; set; }
        public bool HasOrders
        {
            get { return !ReferenceEquals(Orders, null); }
        }
        DateTime ISystemFields.CreateDate
        {
            get { return CreateDate; }
            set { CreateDate = value; }
        }
        DateTime ISystemFields.ChangeDate
        {
            get { return ChangeDate; }
            set { ChangeDate = value; }
        }
                
        
        /// <summary>
        /// Shallow copy of object. Exclude navigation properties and PK properties
        /// </summary>
        public Invoices ShallowCopy()
        {
            return new Invoices {
                       OrderId = OrderId,
                       InvoiceNumber = InvoiceNumber,
                       PayDate = PayDate,
                       WithTaxes = WithTaxes,
                       ManualPrice = ManualPrice,
                       TaxValue = TaxValue,
                       Discount = Discount,
                       BillTillDate = BillTillDate,
                       CreateDate = CreateDate,
                       ChangeDate = ChangeDate,
                       DeleteDate = DeleteDate,
                       IsSellInvoice = IsSellInvoice,
                       ReminderCount = ReminderCount,
                       DateVExportDate = DateVExportDate,
                       DateVExportFile = DateVExportFile,
                       PayInDays = PayInDays,
                       PayPartOne = PayPartOne,
                       PayPartTwo = PayPartTwo,
                       PayPartTree = PayPartTree,
                       LastReminderDate = LastReminderDate,
        	           };
        }
    }
}
