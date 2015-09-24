using CoreBase.Entities;
using ProfiCraftsman.Contracts;
using System;

namespace ProfiCraftsman.Contracts.Entities
{
    public partial class OwnProducts: IHasId<int>
        ,IIntervalFields
        ,IRemovable
        ,ISystemFields
    {
        /// <summary>
        /// Table name
        /// </summary>
        public static readonly string EntityTableName = "dbo.OwnProducts";
        #region Fields
        /// <summary>
        /// Columns names
        /// </summary>
        public static class Fields
        {
            /// <summary>
            /// Column name 'Id' for property <see cref="OwnProducts.Id"/>
            /// </summary>
            public static readonly string Id = "Id";
            /// <summary>
            /// Column name 'Description' for property <see cref="OwnProducts.Description"/>
            /// </summary>
            public static readonly string Description = "Description";
            /// <summary>
            /// Column name 'Price' for property <see cref="OwnProducts.Price"/>
            /// </summary>
            public static readonly string Price = "Price";
            /// <summary>
            /// Column name 'CreateDate' for property <see cref="OwnProducts.CreateDate"/>
            /// </summary>
            public static readonly string CreateDate = "CreateDate";
            /// <summary>
            /// Column name 'ChangeDate' for property <see cref="OwnProducts.ChangeDate"/>
            /// </summary>
            public static readonly string ChangeDate = "ChangeDate";
            /// <summary>
            /// Column name 'DeleteDate' for property <see cref="OwnProducts.DeleteDate"/>
            /// </summary>
            public static readonly string DeleteDate = "DeleteDate";
            /// <summary>
            /// Column name 'FromDate' for property <see cref="OwnProducts.FromDate"/>
            /// </summary>
            public static readonly string FromDate = "FromDate";
            /// <summary>
            /// Column name 'ToDate' for property <see cref="OwnProducts.ToDate"/>
            /// </summary>
            public static readonly string ToDate = "ToDate";
            /// <summary>
            /// Column name 'ProceedsAccountId' for property <see cref="OwnProducts.ProceedsAccountId"/>
            /// </summary>
            public static readonly string ProceedsAccountId = "ProceedsAccountId";
          
        }
        #endregion
        public int Id{ get; set; }
        public string Description{ get; set; }
        public double Price{ get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime ChangeDate{ get; set; }
        public DateTime? DeleteDate{ get; set; }
        public DateTime FromDate{ get; set; }
        public DateTime? ToDate{ get; set; }
        public int ProceedsAccountId{ get; set; }
        public virtual ProceedsAccounts ProceedsAccounts{ get; set; }
        public bool HasProceedsAccounts
        {
            get { return !ReferenceEquals(ProceedsAccounts, null); }
        }
        DateTime? IIntervalFields.FromDate
        {
            get { return FromDate; }
            set { if(value.HasValue)FromDate = value.Value; else throw new ArgumentNullException("value"); }
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
        public OwnProducts ShallowCopy()
        {
            return new OwnProducts {
                       Description = Description,
                       Price = Price,
                       CreateDate = CreateDate,
                       ChangeDate = ChangeDate,
                       DeleteDate = DeleteDate,
                       FromDate = FromDate,
                       ToDate = ToDate,
                       ProceedsAccountId = ProceedsAccountId,
        	           };
        }
    }
}
