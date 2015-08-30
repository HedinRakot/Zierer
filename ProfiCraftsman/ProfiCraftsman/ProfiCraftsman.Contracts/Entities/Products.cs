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
            /// Column name 'Price' for property <see cref="Products.Price"/>
            /// </summary>
            public static readonly string Price = "Price";
            /// <summary>
            /// Column name 'ProceedsAccount' for property <see cref="Products.ProceedsAccount"/>
            /// </summary>
            public static readonly string ProceedsAccount = "ProceedsAccount";
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
            /// Column name 'Name' for property <see cref="Products.Name"/>
            /// </summary>
            public static readonly string Name = "Name";
            /// <summary>
            /// Column name 'ProductAmountType' for property <see cref="Products.ProductAmountType"/>
            /// </summary>
            public static readonly string ProductAmountType = "ProductAmountType";
          
        }
        #endregion
        public int Id{ get; set; }
        public string Number{ get; set; }
        public int? ProductTypeId{ get; set; }
        public double Price{ get; set; }
        public int ProceedsAccount{ get; set; }
        public string Comment{ get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime ChangeDate{ get; set; }
        public DateTime? DeleteDate{ get; set; }
        public string Name{ get; set; }
        public int ProductAmountType{ get; set; }
        public virtual ICollection<Positions> Positions{ get; set; }
        public virtual ICollection<ProductMaterialRsp> ProductMaterialRsps{ get; set; }
        public virtual ProductTypes ProductTypes{ get; set; }
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
                       Price = Price,
                       ProceedsAccount = ProceedsAccount,
                       Comment = Comment,
                       CreateDate = CreateDate,
                       ChangeDate = ChangeDate,
                       DeleteDate = DeleteDate,
                       Name = Name,
                       ProductAmountType = ProductAmountType,
        	           };
        }
    }
}
