using CoreBase.Entities;
using ProfiCraftsman.Contracts;
using System;
using System.Collections.Generic;

namespace ProfiCraftsman.Contracts.Entities
{
    public partial class TermCosts: IHasId<int>
        ,IRemovable
        ,ISystemFields
    {
        /// <summary>
        /// Table name
        /// </summary>
        public static readonly string EntityTableName = "dbo.TermCosts";
        #region Fields
        /// <summary>
        /// Columns names
        /// </summary>
        public static class Fields
        {
            /// <summary>
            /// Column name 'Id' for property <see cref="TermCosts.Id"/>
            /// </summary>
            public static readonly string Id = "Id";
            /// <summary>
            /// Column name 'TermId' for property <see cref="TermCosts.TermId"/>
            /// </summary>
            public static readonly string TermId = "TermId";
            /// <summary>
            /// Column name 'Price' for property <see cref="TermCosts.Price"/>
            /// </summary>
            public static readonly string Price = "Price";
            /// <summary>
            /// Column name 'CreateDate' for property <see cref="TermCosts.CreateDate"/>
            /// </summary>
            public static readonly string CreateDate = "CreateDate";
            /// <summary>
            /// Column name 'ChangeDate' for property <see cref="TermCosts.ChangeDate"/>
            /// </summary>
            public static readonly string ChangeDate = "ChangeDate";
            /// <summary>
            /// Column name 'DeleteDate' for property <see cref="TermCosts.DeleteDate"/>
            /// </summary>
            public static readonly string DeleteDate = "DeleteDate";
            /// <summary>
            /// Column name 'Name' for property <see cref="TermCosts.Name"/>
            /// </summary>
            public static readonly string Name = "Name";
            /// <summary>
            /// Column name 'ProceedsAccountId' for property <see cref="TermCosts.ProceedsAccountId"/>
            /// </summary>
            public static readonly string ProceedsAccountId = "ProceedsAccountId";
            /// <summary>
            /// Column name 'Costs' for property <see cref="TermCosts.Costs"/>
            /// </summary>
            public static readonly string Costs = "Costs";
          
        }
        #endregion
        public int Id{ get; set; }
        public int TermId{ get; set; }
        public double Price{ get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime ChangeDate{ get; set; }
        public DateTime? DeleteDate{ get; set; }
        public string Name{ get; set; }
        public int ProceedsAccountId{ get; set; }
        public double Costs{ get; set; }
        public virtual Terms Terms{ get; set; }
        public virtual ProceedsAccounts ProceedsAccounts{ get; set; }
        public virtual ICollection<InvoicePositions> InvoicePositions{ get; set; }
        public bool HasTerms
        {
            get { return !ReferenceEquals(Terms, null); }
        }
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
        public TermCosts ShallowCopy()
        {
            return new TermCosts {
                       TermId = TermId,
                       Price = Price,
                       CreateDate = CreateDate,
                       ChangeDate = ChangeDate,
                       DeleteDate = DeleteDate,
                       Name = Name,
                       ProceedsAccountId = ProceedsAccountId,
                       Costs = Costs,
        	           };
        }
    }
}
