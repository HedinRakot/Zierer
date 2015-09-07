using CoreBase.Entities;
using ProfiCraftsman.Contracts;
using System;
using System.Collections.Generic;

namespace ProfiCraftsman.Contracts.Entities
{
    public partial class Positions: IHasId<int>
        ,IRemovable
        ,ISystemFields
    {
        /// <summary>
        /// Table name
        /// </summary>
        public static readonly string EntityTableName = "dbo.Positions";
        #region Fields
        /// <summary>
        /// Columns names
        /// </summary>
        public static class Fields
        {
            /// <summary>
            /// Column name 'Id' for property <see cref="Positions.Id"/>
            /// </summary>
            public static readonly string Id = "Id";
            /// <summary>
            /// Column name 'OrderId' for property <see cref="Positions.OrderId"/>
            /// </summary>
            public static readonly string OrderId = "OrderId";
            /// <summary>
            /// Column name 'IsMaterialPosition' for property <see cref="Positions.IsMaterialPosition"/>
            /// </summary>
            public static readonly string IsMaterialPosition = "IsMaterialPosition";
            /// <summary>
            /// Column name 'ProductId' for property <see cref="Positions.ProductId"/>
            /// </summary>
            public static readonly string ProductId = "ProductId";
            /// <summary>
            /// Column name 'MaterialId' for property <see cref="Positions.MaterialId"/>
            /// </summary>
            public static readonly string MaterialId = "MaterialId";
            /// <summary>
            /// Column name 'Price' for property <see cref="Positions.Price"/>
            /// </summary>
            public static readonly string Price = "Price";
            /// <summary>
            /// Column name 'CreateDate' for property <see cref="Positions.CreateDate"/>
            /// </summary>
            public static readonly string CreateDate = "CreateDate";
            /// <summary>
            /// Column name 'ChangeDate' for property <see cref="Positions.ChangeDate"/>
            /// </summary>
            public static readonly string ChangeDate = "ChangeDate";
            /// <summary>
            /// Column name 'DeleteDate' for property <see cref="Positions.DeleteDate"/>
            /// </summary>
            public static readonly string DeleteDate = "DeleteDate";
            /// <summary>
            /// Column name 'Amount' for property <see cref="Positions.Amount"/>
            /// </summary>
            public static readonly string Amount = "Amount";
            /// <summary>
            /// Column name 'IsAlternative' for property <see cref="Positions.IsAlternative"/>
            /// </summary>
            public static readonly string IsAlternative = "IsAlternative";
            /// <summary>
            /// Column name 'PaymentType' for property <see cref="Positions.PaymentType"/>
            /// </summary>
            public static readonly string PaymentType = "PaymentType";
            /// <summary>
            /// Column name 'Description' for property <see cref="Positions.Description"/>
            /// </summary>
            public static readonly string Description = "Description";
            /// <summary>
            /// Column name 'ParentId' for property <see cref="Positions.ParentId"/>
            /// </summary>
            public static readonly string ParentId = "ParentId";
          
        }
        #endregion
        public int Id{ get; set; }
        public int OrderId{ get; set; }
        public bool IsMaterialPosition{ get; set; }
        public int? ProductId{ get; set; }
        public int? MaterialId{ get; set; }
        public double Price{ get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime ChangeDate{ get; set; }
        public DateTime? DeleteDate{ get; set; }
        public int Amount{ get; set; }
        public bool IsAlternative{ get; set; }
        public int PaymentType{ get; set; }
        public string Description{ get; set; }
        public int? ParentId{ get; set; }
        public virtual Orders Orders{ get; set; }
        public virtual Products Products{ get; set; }
        public virtual Materials Materials{ get; set; }
        public virtual ICollection<InvoicePositions> InvoicePositions{ get; set; }
        public virtual ICollection<TermPositions> TermPositions{ get; set; }
        public bool HasOrders
        {
            get { return !ReferenceEquals(Orders, null); }
        }
        public bool HasProducts
        {
            get { return !ReferenceEquals(Products, null); }
        }
        public bool HasMaterials
        {
            get { return !ReferenceEquals(Materials, null); }
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
        public Positions ShallowCopy()
        {
            return new Positions {
                       OrderId = OrderId,
                       IsMaterialPosition = IsMaterialPosition,
                       ProductId = ProductId,
                       MaterialId = MaterialId,
                       Price = Price,
                       CreateDate = CreateDate,
                       ChangeDate = ChangeDate,
                       DeleteDate = DeleteDate,
                       Amount = Amount,
                       IsAlternative = IsAlternative,
                       PaymentType = PaymentType,
                       Description = Description,
                       ParentId = ParentId,
        	           };
        }
    }
}
