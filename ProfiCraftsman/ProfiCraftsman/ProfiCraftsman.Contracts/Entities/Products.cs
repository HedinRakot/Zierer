using CoreBase.Entities;
using ProfiCraftsman.Contracts;
using System;
using System.Collections.Generic;

namespace ProfiCraftsman.Contracts.Entities
{
    public partial class Products: IHasId<int>
        ,IRemovable
        ,ISystemFields
    {
        /// <summary>
        /// Table name
        /// </summary>
        public static readonly string EntityTableName = "dbo.Products";
        #region Fields
        /// <summary>
        /// Columns names
        /// </summary>
        public static class Fields
        {
            /// <summary>
            /// Column name 'Id' for property <see cref="Products.Id"/>
            /// </summary>
            public static readonly string Id = "Id";
            /// <summary>
            /// Column name 'Number' for property <see cref="Products.Number"/>
            /// </summary>
            public static readonly string Number = "Number";
            /// <summary>
            /// Column name 'ProductTypeId' for property <see cref="Products.ProductTypeId"/>
            /// </summary>
            public static readonly string ProductTypeId = "ProductTypeId";
            /// <summary>
            /// Column name 'Length' for property <see cref="Products.Length"/>
            /// </summary>
            public static readonly string Length = "Length";
            /// <summary>
            /// Column name 'Width' for property <see cref="Products.Width"/>
            /// </summary>
            public static readonly string Width = "Width";
            /// <summary>
            /// Column name 'Height' for property <see cref="Products.Height"/>
            /// </summary>
            public static readonly string Height = "Height";
            /// <summary>
            /// Column name 'Color' for property <see cref="Products.Color"/>
            /// </summary>
            public static readonly string Color = "Color";
            /// <summary>
            /// Column name 'Price' for property <see cref="Products.Price"/>
            /// </summary>
            public static readonly string Price = "Price";
            /// <summary>
            /// Column name 'ProceedsAccount' for property <see cref="Products.ProceedsAccount"/>
            /// </summary>
            public static readonly string ProceedsAccount = "ProceedsAccount";
            /// <summary>
            /// Column name 'IsVirtual' for property <see cref="Products.IsVirtual"/>
            /// </summary>
            public static readonly string IsVirtual = "IsVirtual";
            /// <summary>
            /// Column name 'ManufactureDate' for property <see cref="Products.ManufactureDate"/>
            /// </summary>
            public static readonly string ManufactureDate = "ManufactureDate";
            /// <summary>
            /// Column name 'BoughtFrom' for property <see cref="Products.BoughtFrom"/>
            /// </summary>
            public static readonly string BoughtFrom = "BoughtFrom";
            /// <summary>
            /// Column name 'BoughtPrice' for property <see cref="Products.BoughtPrice"/>
            /// </summary>
            public static readonly string BoughtPrice = "BoughtPrice";
            /// <summary>
            /// Column name 'Comment' for property <see cref="Products.Comment"/>
            /// </summary>
            public static readonly string Comment = "Comment";
            /// <summary>
            /// Column name 'CreateDate' for property <see cref="Products.CreateDate"/>
            /// </summary>
            public static readonly string CreateDate = "CreateDate";
            /// <summary>
            /// Column name 'ChangeDate' for property <see cref="Products.ChangeDate"/>
            /// </summary>
            public static readonly string ChangeDate = "ChangeDate";
            /// <summary>
            /// Column name 'DeleteDate' for property <see cref="Products.DeleteDate"/>
            /// </summary>
            public static readonly string DeleteDate = "DeleteDate";
            /// <summary>
            /// Column name 'SellPrice' for property <see cref="Products.SellPrice"/>
            /// </summary>
            public static readonly string SellPrice = "SellPrice";
            /// <summary>
            /// Column name 'IsSold' for property <see cref="Products.IsSold"/>
            /// </summary>
            public static readonly string IsSold = "IsSold";
            /// <summary>
            /// Column name 'MinPrice' for property <see cref="Products.MinPrice"/>
            /// </summary>
            public static readonly string MinPrice = "MinPrice";
            /// <summary>
            /// Column name 'NewPrice' for property <see cref="Products.NewPrice"/>
            /// </summary>
            public static readonly string NewPrice = "NewPrice";
          
        }
        #endregion
        public int Id{ get; set; }
        public string Number{ get; set; }
        public int ProductTypeId{ get; set; }
        public int Length{ get; set; }
        public int Width{ get; set; }
        public int Height{ get; set; }
        public string Color{ get; set; }
        public double Price{ get; set; }
        public int ProceedsAccount{ get; set; }
        public bool IsVirtual{ get; set; }
        public DateTime? ManufactureDate{ get; set; }
        public string BoughtFrom{ get; set; }
        public double? BoughtPrice{ get; set; }
        public string Comment{ get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime ChangeDate{ get; set; }
        public DateTime? DeleteDate{ get; set; }
        public double SellPrice{ get; set; }
        public bool IsSold{ get; set; }
        public double MinPrice{ get; set; }
        public double NewPrice{ get; set; }
        public virtual ICollection<Positions> Positions{ get; set; }
        public virtual ICollection<OrderProductEquipmentRsp> OrderProductEquipmentRsps{ get; set; }
        public virtual ProductTypes ProductTypes{ get; set; }
        public virtual ICollection<ProductEquipmentRsp> ProductEquipmentRsps{ get; set; }
        public bool HasProductTypes
        {
            get { return !ReferenceEquals(ProductTypes, null); }
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
        public Products ShallowCopy()
        {
            return new Products {
                       Number = Number,
                       ProductTypeId = ProductTypeId,
                       Length = Length,
                       Width = Width,
                       Height = Height,
                       Color = Color,
                       Price = Price,
                       ProceedsAccount = ProceedsAccount,
                       IsVirtual = IsVirtual,
                       ManufactureDate = ManufactureDate,
                       BoughtFrom = BoughtFrom,
                       BoughtPrice = BoughtPrice,
                       Comment = Comment,
                       CreateDate = CreateDate,
                       ChangeDate = ChangeDate,
                       DeleteDate = DeleteDate,
                       SellPrice = SellPrice,
                       IsSold = IsSold,
                       MinPrice = MinPrice,
                       NewPrice = NewPrice,
        	           };
        }
    }
}
