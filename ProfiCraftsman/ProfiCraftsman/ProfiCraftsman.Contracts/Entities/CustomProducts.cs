using CoreBase.Entities;
using ProfiCraftsman.Contracts;
using System;

namespace ProfiCraftsman.Contracts.Entities
{
    public partial class CustomProducts: IHasId<int>
        ,IRemovable
        ,ISystemFields
    {
        /// <summary>
        /// Table name
        /// </summary>
        public static readonly string EntityTableName = "dbo.CustomProducts";
        #region Fields
        /// <summary>
        /// Columns names
        /// </summary>
        public static class Fields
        {
            /// <summary>
            /// Column name 'Id' for property <see cref="CustomProducts.Id"/>
            /// </summary>
            public static readonly string Id = "Id";
            /// <summary>
            /// Column name 'Name' for property <see cref="CustomProducts.Name"/>
            /// </summary>
            public static readonly string Name = "Name";
            /// <summary>
            /// Column name 'Price' for property <see cref="CustomProducts.Price"/>
            /// </summary>
            public static readonly string Price = "Price";
            /// <summary>
            /// Column name 'CreateDate' for property <see cref="CustomProducts.CreateDate"/>
            /// </summary>
            public static readonly string CreateDate = "CreateDate";
            /// <summary>
            /// Column name 'ChangeDate' for property <see cref="CustomProducts.ChangeDate"/>
            /// </summary>
            public static readonly string ChangeDate = "ChangeDate";
            /// <summary>
            /// Column name 'DeleteDate' for property <see cref="CustomProducts.DeleteDate"/>
            /// </summary>
            public static readonly string DeleteDate = "DeleteDate";
            /// <summary>
            /// Column name 'Auto' for property <see cref="CustomProducts.Auto"/>
            /// </summary>
            public static readonly string Auto = "Auto";
            /// <summary>
            /// Column name 'ProceedsAccountId' for property <see cref="CustomProducts.ProceedsAccountId"/>
            /// </summary>
            public static readonly string ProceedsAccountId = "ProceedsAccountId";
          
        }
        #endregion
        public int Id{ get; set; }
        public string Name{ get; set; }
        public double Price{ get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime ChangeDate{ get; set; }
        public DateTime? DeleteDate{ get; set; }
        public bool Auto{ get; set; }
        public int? ProceedsAccountId{ get; set; }
        public virtual ProceedsAccounts ProceedsAccounts{ get; set; }
        public bool HasProceedsAccounts
        {
            get { return !ReferenceEquals(ProceedsAccounts, null); }
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
        public CustomProducts ShallowCopy()
        {
            return new CustomProducts {
                       Name = Name,
                       Price = Price,
                       CreateDate = CreateDate,
                       ChangeDate = ChangeDate,
                       DeleteDate = DeleteDate,
                       Auto = Auto,
                       ProceedsAccountId = ProceedsAccountId,
        	           };
        }
    }
}
