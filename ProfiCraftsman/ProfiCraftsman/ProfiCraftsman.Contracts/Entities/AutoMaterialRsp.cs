using CoreBase.Entities;
using ProfiCraftsman.Contracts;
using System;

namespace ProfiCraftsman.Contracts.Entities
{
    public partial class AutoMaterialRsp: IHasId<int>
        ,IRemovable
        ,ISystemFields
    {
        /// <summary>
        /// Table name
        /// </summary>
        public static readonly string EntityTableName = "dbo.Auto_Material_Rsp";
        #region Fields
        /// <summary>
        /// Columns names
        /// </summary>
        public static class Fields
        {
            /// <summary>
            /// Column name 'Id' for property <see cref="AutoMaterialRsp.Id"/>
            /// </summary>
            public static readonly string Id = "Id";
            /// <summary>
            /// Column name 'AutoId' for property <see cref="AutoMaterialRsp.AutoId"/>
            /// </summary>
            public static readonly string AutoId = "AutoId";
            /// <summary>
            /// Column name 'MaterialId' for property <see cref="AutoMaterialRsp.MaterialId"/>
            /// </summary>
            public static readonly string MaterialId = "MaterialId";
            /// <summary>
            /// Column name 'Amount' for property <see cref="AutoMaterialRsp.Amount"/>
            /// </summary>
            public static readonly string Amount = "Amount";
            /// <summary>
            /// Column name 'CreateDate' for property <see cref="AutoMaterialRsp.CreateDate"/>
            /// </summary>
            public static readonly string CreateDate = "CreateDate";
            /// <summary>
            /// Column name 'ChangeDate' for property <see cref="AutoMaterialRsp.ChangeDate"/>
            /// </summary>
            public static readonly string ChangeDate = "ChangeDate";
            /// <summary>
            /// Column name 'DeleteDate' for property <see cref="AutoMaterialRsp.DeleteDate"/>
            /// </summary>
            public static readonly string DeleteDate = "DeleteDate";
            /// <summary>
            /// Column name 'RestAmount' for property <see cref="AutoMaterialRsp.RestAmount"/>
            /// </summary>
            public static readonly string RestAmount = "RestAmount";
          
        }
        #endregion
        public int Id{ get; set; }
        public int AutoId{ get; set; }
        public int MaterialId{ get; set; }
        public int Amount{ get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime ChangeDate{ get; set; }
        public DateTime? DeleteDate{ get; set; }
        public double? RestAmount{ get; set; }
        public virtual Materials Materials{ get; set; }
        public virtual Autos Autos{ get; set; }
        public bool HasMaterials
        {
            get { return !ReferenceEquals(Materials, null); }
        }
        public bool HasAutos
        {
            get { return !ReferenceEquals(Autos, null); }
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
        public AutoMaterialRsp ShallowCopy()
        {
            return new AutoMaterialRsp {
                       AutoId = AutoId,
                       MaterialId = MaterialId,
                       Amount = Amount,
                       CreateDate = CreateDate,
                       ChangeDate = ChangeDate,
                       DeleteDate = DeleteDate,
                       RestAmount = RestAmount,
        	           };
        }
    }
}
