using CoreBase.Entities;
using ProfiCraftsman.Contracts;
using System;
using System.Collections.Generic;

namespace ProfiCraftsman.Contracts.Entities
{
    public partial class Autos: IHasId<int>
        ,IHasTitle<int>
        ,IRemovable
        ,ISystemFields
    {
        /// <summary>
        /// Table name
        /// </summary>
        public static readonly string EntityTableName = "dbo.Autos";
        #region Fields
        /// <summary>
        /// Columns names
        /// </summary>
        public static class Fields
        {
            /// <summary>
            /// Column name 'Id' for property <see cref="Autos.Id"/>
            /// </summary>
            public static readonly string Id = "Id";
            /// <summary>
            /// Column name 'Number' for property <see cref="Autos.Number"/>
            /// </summary>
            public static readonly string Number = "Number";
            /// <summary>
            /// Column name 'Comment' for property <see cref="Autos.Comment"/>
            /// </summary>
            public static readonly string Comment = "Comment";
            /// <summary>
            /// Column name 'LastInspectionDate' for property <see cref="Autos.LastInspectionDate"/>
            /// </summary>
            public static readonly string LastInspectionDate = "LastInspectionDate";
            /// <summary>
            /// Column name 'CreateDate' for property <see cref="Autos.CreateDate"/>
            /// </summary>
            public static readonly string CreateDate = "CreateDate";
            /// <summary>
            /// Column name 'ChangeDate' for property <see cref="Autos.ChangeDate"/>
            /// </summary>
            public static readonly string ChangeDate = "ChangeDate";
            /// <summary>
            /// Column name 'DeleteDate' for property <see cref="Autos.DeleteDate"/>
            /// </summary>
            public static readonly string DeleteDate = "DeleteDate";
          
        }
        #endregion
        public int Id{ get; set; }
        public string Number{ get; set; }
        public string Comment{ get; set; }
        public DateTime? LastInspectionDate{ get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime ChangeDate{ get; set; }
        public DateTime? DeleteDate{ get; set; }
        public virtual ICollection<Employees> Employees{ get; set; }
        public virtual ICollection<Terms> Terms{ get; set; }
        string IHasTitle<int>.EntityTitle
        {
            get { return Number; }
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
        public Autos ShallowCopy()
        {
            return new Autos {
                       Number = Number,
                       Comment = Comment,
                       LastInspectionDate = LastInspectionDate,
                       CreateDate = CreateDate,
                       ChangeDate = ChangeDate,
                       DeleteDate = DeleteDate,
        	           };
        }
    }
}
