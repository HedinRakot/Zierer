using CoreBase.Entities;
using ProfiCraftsman.Contracts;
using System;

namespace ProfiCraftsman.Contracts.Entities
{
    public partial class SearchPositionView: IHasId<int>
        ,IRemovable
        ,ISystemFields
    {
        /// <summary>
        /// Table name
        /// </summary>
        public static readonly string EntityTableName = "dbo.SearchPositionView";
        #region Fields
        /// <summary>
        /// Columns names
        /// </summary>
        public static class Fields
        {
            /// <summary>
            /// Column name 'Id' for property <see cref="SearchPositionView.Id"/>
            /// </summary>
            public static readonly string Id = "Id";
            /// <summary>
            /// Column name 'OrderId' for property <see cref="SearchPositionView.OrderId"/>
            /// </summary>
            public static readonly string OrderId = "OrderId";
            /// <summary>
            /// Column name 'IsMaterialPosition' for property <see cref="SearchPositionView.IsMaterialPosition"/>
            /// </summary>
            public static readonly string IsMaterialPosition = "IsMaterialPosition";
            /// <summary>
            /// Column name 'ProductId' for property <see cref="SearchPositionView.ProductId"/>
            /// </summary>
            public static readonly string ProductId = "ProductId";
            /// <summary>
            /// Column name 'MaterialId' for property <see cref="SearchPositionView.MaterialId"/>
            /// </summary>
            public static readonly string MaterialId = "MaterialId";
            /// <summary>
            /// Column name 'Price' for property <see cref="SearchPositionView.Price"/>
            /// </summary>
            public static readonly string Price = "Price";
            /// <summary>
            /// Column name 'CreateDate' for property <see cref="SearchPositionView.CreateDate"/>
            /// </summary>
            public static readonly string CreateDate = "CreateDate";
            /// <summary>
            /// Column name 'ChangeDate' for property <see cref="SearchPositionView.ChangeDate"/>
            /// </summary>
            public static readonly string ChangeDate = "ChangeDate";
            /// <summary>
            /// Column name 'DeleteDate' for property <see cref="SearchPositionView.DeleteDate"/>
            /// </summary>
            public static readonly string DeleteDate = "DeleteDate";
            /// <summary>
            /// Column name 'Amount' for property <see cref="SearchPositionView.Amount"/>
            /// </summary>
            public static readonly string Amount = "Amount";
            /// <summary>
            /// Column name 'IsAlternative' for property <see cref="SearchPositionView.IsAlternative"/>
            /// </summary>
            public static readonly string IsAlternative = "IsAlternative";
            /// <summary>
            /// Column name 'PaymentType' for property <see cref="SearchPositionView.PaymentType"/>
            /// </summary>
            public static readonly string PaymentType = "PaymentType";
            /// <summary>
            /// Column name 'Description' for property <see cref="SearchPositionView.Description"/>
            /// </summary>
            public static readonly string Description = "Description";
            /// <summary>
            /// Column name 'ParentId' for property <see cref="SearchPositionView.ParentId"/>
            /// </summary>
            public static readonly string ParentId = "ParentId";
            /// <summary>
            /// Column name 'RestAmount' for property <see cref="SearchPositionView.RestAmount"/>
            /// </summary>
            public static readonly string RestAmount = "RestAmount";
            /// <summary>
            /// Column name 'Number' for property <see cref="SearchPositionView.Number"/>
            /// </summary>
            public static readonly string Number = "Number";
            /// <summary>
            /// Column name 'ProductAmountType' for property <see cref="SearchPositionView.ProductAmountType"/>
            /// </summary>
            public static readonly string ProductAmountType = "ProductAmountType";
          
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
        public int? RestAmount{ get; set; }
        public string Number{ get; set; }
        public int? ProductAmountType{ get; set; }
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
        public SearchPositionView ShallowCopy()
        {
            return new SearchPositionView {
                       Id = Id,
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
                       RestAmount = RestAmount,
                       Number = Number,
                       ProductAmountType = ProductAmountType,
        	           };
        }
    }
}
