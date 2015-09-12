using CoreBase.Entities;
using ProfiCraftsman.Contracts;
using System;
using System.Collections.Generic;

namespace ProfiCraftsman.Contracts.Entities
{
    public partial class ProceedsAccounts: IHasId<int>
        ,IHasTitle<int>
        ,IRemovable
        ,ISystemFields
    {
        /// <summary>
        /// Table name
        /// </summary>
        public static readonly string EntityTableName = "dbo.ProceedsAccounts";
        #region Fields
        /// <summary>
        /// Columns names
        /// </summary>
        public static class Fields
        {
            /// <summary>
            /// Column name 'Id' for property <see cref="ProceedsAccounts.Id"/>
            /// </summary>
            public static readonly string Id = "Id";
            /// <summary>
            /// Column name 'Value' for property <see cref="ProceedsAccounts.Value"/>
            /// </summary>
            public static readonly string Value = "Value";
            /// <summary>
            /// Column name 'CreateDate' for property <see cref="ProceedsAccounts.CreateDate"/>
            /// </summary>
            public static readonly string CreateDate = "CreateDate";
            /// <summary>
            /// Column name 'ChangeDate' for property <see cref="ProceedsAccounts.ChangeDate"/>
            /// </summary>
            public static readonly string ChangeDate = "ChangeDate";
            /// <summary>
            /// Column name 'DeleteDate' for property <see cref="ProceedsAccounts.DeleteDate"/>
            /// </summary>
            public static readonly string DeleteDate = "DeleteDate";
          
        }
        #endregion
        public int Id{ get; set; }
        public int Value{ get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime ChangeDate{ get; set; }
        public DateTime? DeleteDate{ get; set; }
        public virtual ICollection<TermCosts> TermCosts{ get; set; }
        public virtual ICollection<CustomProducts> CustomProducts{ get; set; }
        public virtual ICollection<Materials> Materials{ get; set; }
        public virtual ICollection<AdditionalCosts> AdditionalCosts{ get; set; }
        public virtual ICollection<Instruments> Instruments{ get; set; }
        public virtual ICollection<Products> Products{ get; set; }
        string IHasTitle<int>.EntityTitle
        {
            get { return Value.ToString(); }
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
        public ProceedsAccounts ShallowCopy()
        {
            return new ProceedsAccounts {
                       Value = Value,
                       CreateDate = CreateDate,
                       ChangeDate = ChangeDate,
                       DeleteDate = DeleteDate,
        	           };
        }
    }
}
