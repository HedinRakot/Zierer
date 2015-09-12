using CoreBase.Entities;
using ProfiCraftsman.Contracts;
using System;
using System.Collections.Generic;

namespace ProfiCraftsman.Contracts.Entities
{
    public partial class JobPositions: IHasId<int>
        ,IHasTitle<int>
        ,IRemovable
        ,ISystemFields
    {
        /// <summary>
        /// Table name
        /// </summary>
        public static readonly string EntityTableName = "dbo.JobPositions";
        #region Fields
        /// <summary>
        /// Columns names
        /// </summary>
        public static class Fields
        {
            /// <summary>
            /// Column name 'Id' for property <see cref="JobPositions.Id"/>
            /// </summary>
            public static readonly string Id = "Id";
            /// <summary>
            /// Column name 'Name' for property <see cref="JobPositions.Name"/>
            /// </summary>
            public static readonly string Name = "Name";
            /// <summary>
            /// Column name 'Comment' for property <see cref="JobPositions.Comment"/>
            /// </summary>
            public static readonly string Comment = "Comment";
            /// <summary>
            /// Column name 'CreateDate' for property <see cref="JobPositions.CreateDate"/>
            /// </summary>
            public static readonly string CreateDate = "CreateDate";
            /// <summary>
            /// Column name 'ChangeDate' for property <see cref="JobPositions.ChangeDate"/>
            /// </summary>
            public static readonly string ChangeDate = "ChangeDate";
            /// <summary>
            /// Column name 'DeleteDate' for property <see cref="JobPositions.DeleteDate"/>
            /// </summary>
            public static readonly string DeleteDate = "DeleteDate";
          
        }
        #endregion
        public int Id{ get; set; }
        public string Name{ get; set; }
        public string Comment{ get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime ChangeDate{ get; set; }
        public DateTime? DeleteDate{ get; set; }
        public virtual ICollection<Rates> Rates{ get; set; }
        public virtual ICollection<EmployeeRateRsp> EmployeeRateRsps{ get; set; }
        string IHasTitle<int>.EntityTitle
        {
            get { return Name.ToString(); }
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
        public JobPositions ShallowCopy()
        {
            return new JobPositions {
                       Name = Name,
                       Comment = Comment,
                       CreateDate = CreateDate,
                       ChangeDate = ChangeDate,
                       DeleteDate = DeleteDate,
        	           };
        }
    }
}
