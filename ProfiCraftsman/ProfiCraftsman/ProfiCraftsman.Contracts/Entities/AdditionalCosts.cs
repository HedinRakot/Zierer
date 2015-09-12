using CoreBase.Entities;
using ProfiCraftsman.Contracts;
using System;

namespace ProfiCraftsman.Contracts.Entities
{
    public partial class AdditionalCosts: IHasId<int>
        ,IIntervalFields
        ,IRemovable
        ,ISystemFields
    {
        /// <summary>
        /// Table name
        /// </summary>
        public static readonly string EntityTableName = "dbo.AdditionalCosts";
        #region Fields
        /// <summary>
        /// Columns names
        /// </summary>
        public static class Fields
        {
            /// <summary>
            /// Column name 'Id' for property <see cref="AdditionalCosts.Id"/>
            /// </summary>
            public static readonly string Id = "Id";
            /// <summary>
            /// Column name 'Description' for property <see cref="AdditionalCosts.Description"/>
            /// </summary>
            public static readonly string Description = "Description";
            /// <summary>
            /// Column name 'Price' for property <see cref="AdditionalCosts.Price"/>
            /// </summary>
            public static readonly string Price = "Price";
            /// <summary>
            /// Column name 'Automatic' for property <see cref="AdditionalCosts.Automatic"/>
            /// </summary>
            public static readonly string Automatic = "Automatic";
            /// <summary>
            /// Column name 'CreateDate' for property <see cref="AdditionalCosts.CreateDate"/>
            /// </summary>
            public static readonly string CreateDate = "CreateDate";
            /// <summary>
            /// Column name 'ChangeDate' for property <see cref="AdditionalCosts.ChangeDate"/>
            /// </summary>
            public static readonly string ChangeDate = "ChangeDate";
            /// <summary>
            /// Column name 'DeleteDate' for property <see cref="AdditionalCosts.DeleteDate"/>
            /// </summary>
            public static readonly string DeleteDate = "DeleteDate";
            /// <summary>
            /// Column name 'FromDate' for property <see cref="AdditionalCosts.FromDate"/>
            /// </summary>
            public static readonly string FromDate = "FromDate";
            /// <summary>
            /// Column name 'ToDate' for property <see cref="AdditionalCosts.ToDate"/>
            /// </summary>
            public static readonly string ToDate = "ToDate";
            /// <summary>
            /// Column name 'AdditionalCostTypeId' for property <see cref="AdditionalCosts.AdditionalCostTypeId"/>
            /// </summary>
            public static readonly string AdditionalCostTypeId = "AdditionalCostTypeId";
            /// <summary>
            /// Column name 'ProceedsAccountId' for property <see cref="AdditionalCosts.ProceedsAccountId"/>
            /// </summary>
            public static readonly string ProceedsAccountId = "ProceedsAccountId";
          
        }
        #endregion
        public int Id{ get; set; }
        public string Description{ get; set; }
        public double Price{ get; set; }
        public bool Automatic{ get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime ChangeDate{ get; set; }
        public DateTime? DeleteDate{ get; set; }
        public DateTime FromDate{ get; set; }
        public DateTime? ToDate{ get; set; }
        public int AdditionalCostTypeId{ get; set; }
        public int ProceedsAccountId{ get; set; }
        public virtual AdditionalCostTypes AdditionalCostTypes{ get; set; }
        public virtual ProceedsAccounts ProceedsAccounts{ get; set; }
        public bool HasAdditionalCostTypes
        {
            get { return !ReferenceEquals(AdditionalCostTypes, null); }
        }
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
        public AdditionalCosts ShallowCopy()
        {
            return new AdditionalCosts {
                       Description = Description,
                       Price = Price,
                       Automatic = Automatic,
                       CreateDate = CreateDate,
                       ChangeDate = ChangeDate,
                       DeleteDate = DeleteDate,
                       FromDate = FromDate,
                       ToDate = ToDate,
                       AdditionalCostTypeId = AdditionalCostTypeId,
                       ProceedsAccountId = ProceedsAccountId,
        	           };
        }
    }
}
