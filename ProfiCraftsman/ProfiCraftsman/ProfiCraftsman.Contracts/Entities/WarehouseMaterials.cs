using CoreBase.Entities;
using ProfiCraftsman.Contracts;
using System;

namespace ProfiCraftsman.Contracts.Entities
{
    public partial class WarehouseMaterials: IHasId<int>
        ,IRemovable
        ,ISystemFields
    {
        /// <summary>
        /// Table name
        /// </summary>
        public static readonly string EntityTableName = "dbo.WarehouseMaterials";
        #region Fields
        /// <summary>
        /// Columns names
        /// </summary>
        public static class Fields
        {
            /// <summary>
            /// Column name 'Id' for property <see cref="WarehouseMaterials.Id"/>
            /// </summary>
            public static readonly string Id = "Id";
            /// <summary>
            /// Column name 'MaterialId' for property <see cref="WarehouseMaterials.MaterialId"/>
            /// </summary>
            public static readonly string MaterialId = "MaterialId";
            /// <summary>
            /// Column name 'IsAmount' for property <see cref="WarehouseMaterials.IsAmount"/>
            /// </summary>
            public static readonly string IsAmount = "IsAmount";
            /// <summary>
            /// Column name 'MustAmount' for property <see cref="WarehouseMaterials.MustAmount"/>
            /// </summary>
            public static readonly string MustAmount = "MustAmount";
            /// <summary>
            /// Column name 'CreateDate' for property <see cref="WarehouseMaterials.CreateDate"/>
            /// </summary>
            public static readonly string CreateDate = "CreateDate";
            /// <summary>
            /// Column name 'ChangeDate' for property <see cref="WarehouseMaterials.ChangeDate"/>
            /// </summary>
            public static readonly string ChangeDate = "ChangeDate";
            /// <summary>
            /// Column name 'DeleteDate' for property <see cref="WarehouseMaterials.DeleteDate"/>
            /// </summary>
            public static readonly string DeleteDate = "DeleteDate";
          
        }
        #endregion
        public int Id{ get; set; }
        public int MaterialId{ get; set; }
        public int IsAmount{ get; set; }
        public int MustAmount{ get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime ChangeDate{ get; set; }
        public DateTime? DeleteDate{ get; set; }
        public virtual Materials Materials{ get; set; }
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
        public WarehouseMaterials ShallowCopy()
        {
            return new WarehouseMaterials {
                       MaterialId = MaterialId,
                       IsAmount = IsAmount,
                       MustAmount = MustAmount,
                       CreateDate = CreateDate,
                       ChangeDate = ChangeDate,
                       DeleteDate = DeleteDate,
        	           };
        }
    }
}
