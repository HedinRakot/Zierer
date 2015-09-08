using CoreBase.Entities;
using ProfiCraftsman.Contracts;
using System;
using System.Collections.Generic;

namespace ProfiCraftsman.Contracts.Entities
{
    public partial class AdditionalCostTypes: IHasId<int>
        ,IHasTitle<int>
        ,IRemovable
        ,ISystemFields
    {
        /// <summary>
        /// Table name
        /// </summary>
        public static readonly string EntityTableName = "dbo.AdditionalCostTypes";
        #region Fields
        /// <summary>
        /// Columns names
        /// </summary>
        public static class Fields
        {
            /// <summary>
            /// Column name 'Id' for property <see cref="AdditionalCostTypes.Id"/>
            /// </summary>
            public static readonly string Id = "Id";
            /// <summary>
            /// Column name 'Name' for property <see cref="AdditionalCostTypes.Name"/>
            /// </summary>
            public static readonly string Name = "Name";
            /// <summary>
            /// Column name 'CreateDate' for property <see cref="AdditionalCostTypes.CreateDate"/>
            /// </summary>
            public static readonly string CreateDate = "CreateDate";
            /// <summary>
            /// Column name 'ChangeDate' for property <see cref="AdditionalCostTypes.ChangeDate"/>
            /// </summary>
            public static readonly string ChangeDate = "ChangeDate";
            /// <summary>
            /// Column name 'DeleteDate' for property <see cref="AdditionalCostTypes.DeleteDate"/>
            /// </summary>
            public static readonly string DeleteDate = "DeleteDate";
          
        }
        #endregion
        public int Id{ get; set; }
        public string Name{ get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime ChangeDate{ get; set; }
        public DateTime? DeleteDate{ get; set; }
        public virtual ICollection<AdditionalCosts> AdditionalCosts{ get; set; }
        string IHasTitle<int>.EntityTitle
        {
            get { return Name; }
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
        public AdditionalCostTypes ShallowCopy()
        {
            return new AdditionalCostTypes {
                       Name = Name,
                       CreateDate = CreateDate,
                       ChangeDate = ChangeDate,
                       DeleteDate = DeleteDate,
        	           };
        }
    }
}
