using CoreBase.Entities;
using ProfiCraftsman.Contracts;
using System;

namespace ProfiCraftsman.Contracts.Entities
{
    public partial class InvoicePositions: IHasId<int>
        ,IRemovable
        ,ISystemFields
    {
        /// <summary>
        /// Table name
        /// </summary>
        public static readonly string EntityTableName = "dbo.InvoicePositions";
        #region Fields
        /// <summary>
        /// Columns names
        /// </summary>
        public static class Fields
        {
            /// <summary>
            /// Column name 'Id' for property <see cref="InvoicePositions.Id"/>
            /// </summary>
            public static readonly string Id = "Id";
            /// <summary>
            /// Column name 'InvoiceId' for property <see cref="InvoicePositions.InvoiceId"/>
            /// </summary>
            public static readonly string InvoiceId = "InvoiceId";
            /// <summary>
            /// Column name 'PositionId' for property <see cref="InvoicePositions.PositionId"/>
            /// </summary>
            public static readonly string PositionId = "PositionId";
            /// <summary>
            /// Column name 'Price' for property <see cref="InvoicePositions.Price"/>
            /// </summary>
            public static readonly string Price = "Price";
            /// <summary>
            /// Column name 'CreateDate' for property <see cref="InvoicePositions.CreateDate"/>
            /// </summary>
            public static readonly string CreateDate = "CreateDate";
            /// <summary>
            /// Column name 'ChangeDate' for property <see cref="InvoicePositions.ChangeDate"/>
            /// </summary>
            public static readonly string ChangeDate = "ChangeDate";
            /// <summary>
            /// Column name 'DeleteDate' for property <see cref="InvoicePositions.DeleteDate"/>
            /// </summary>
            public static readonly string DeleteDate = "DeleteDate";
            /// <summary>
            /// Column name 'Amount' for property <see cref="InvoicePositions.Amount"/>
            /// </summary>
            public static readonly string Amount = "Amount";
            /// <summary>
            /// Column name 'PaymentType' for property <see cref="InvoicePositions.PaymentType"/>
            /// </summary>
            public static readonly string PaymentType = "PaymentType";
            /// <summary>
            /// Column name 'TermCostId' for property <see cref="InvoicePositions.TermCostId"/>
            /// </summary>
            public static readonly string TermCostId = "TermCostId";
            /// <summary>
            /// Column name 'TermPositionMaterialId' for property <see cref="InvoicePositions.TermPositionMaterialId"/>
            /// </summary>
            public static readonly string TermPositionMaterialId = "TermPositionMaterialId";
          
        }
        #endregion
        public int Id{ get; set; }
        public int InvoiceId{ get; set; }
        public int? PositionId{ get; set; }
        public double Price{ get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime ChangeDate{ get; set; }
        public DateTime? DeleteDate{ get; set; }
        public double Amount{ get; set; }
        public int PaymentType{ get; set; }
        public int? TermCostId{ get; set; }
        public int? TermPositionMaterialId{ get; set; }
        public virtual TermCosts TermCosts{ get; set; }
        public virtual Invoices Invoices{ get; set; }
        public virtual TermPositionMaterialRsp TermPositionMaterialRsp{ get; set; }
        public virtual Positions Positions{ get; set; }
        public bool HasTermCosts
        {
            get { return !ReferenceEquals(TermCosts, null); }
        }
        public bool HasInvoices
        {
            get { return !ReferenceEquals(Invoices, null); }
        }
        public bool HasTermPositionMaterialRsp
        {
            get { return !ReferenceEquals(TermPositionMaterialRsp, null); }
        }
        public bool HasPositions
        {
            get { return !ReferenceEquals(Positions, null); }
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
        public InvoicePositions ShallowCopy()
        {
            return new InvoicePositions {
                       InvoiceId = InvoiceId,
                       PositionId = PositionId,
                       Price = Price,
                       CreateDate = CreateDate,
                       ChangeDate = ChangeDate,
                       DeleteDate = DeleteDate,
                       Amount = Amount,
                       PaymentType = PaymentType,
                       TermCostId = TermCostId,
                       TermPositionMaterialId = TermPositionMaterialId,
        	           };
        }
    }
}
