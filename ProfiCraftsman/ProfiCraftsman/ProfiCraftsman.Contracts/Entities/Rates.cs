using CoreBase.Entities;
using ProfiCraftsman.Contracts;
using System;

namespace ProfiCraftsman.Contracts.Entities
{
    public partial class Rates: IHasId<int>
        ,IIntervalFields
        ,IRemovable
        ,ISystemFields
    {
        /// <summary>
        /// Table name
        /// </summary>
        public static readonly string EntityTableName = "dbo.Rates";
        #region Fields
        /// <summary>
        /// Columns names
        /// </summary>
        public static class Fields
        {
            /// <summary>
            /// Column name 'Id' for property <see cref="Rates.Id"/>
            /// </summary>
            public static readonly string Id = "Id";
            /// <summary>
            /// Column name 'JobPositionId' for property <see cref="Rates.JobPositionId"/>
            /// </summary>
            public static readonly string JobPositionId = "JobPositionId";
            /// <summary>
            /// Column name 'Price' for property <see cref="Rates.Price"/>
            /// </summary>
            public static readonly string Price = "Price";
            /// <summary>
            /// Column name 'CreateDate' for property <see cref="Rates.CreateDate"/>
            /// </summary>
            public static readonly string CreateDate = "CreateDate";
            /// <summary>
            /// Column name 'ChangeDate' for property <see cref="Rates.ChangeDate"/>
            /// </summary>
            public static readonly string ChangeDate = "ChangeDate";
            /// <summary>
            /// Column name 'DeleteDate' for property <see cref="Rates.DeleteDate"/>
            /// </summary>
            public static readonly string DeleteDate = "DeleteDate";
            /// <summary>
            /// Column name 'FromDate' for property <see cref="Rates.FromDate"/>
            /// </summary>
            public static readonly string FromDate = "FromDate";
            /// <summary>
            /// Column name 'ToDate' for property <see cref="Rates.ToDate"/>
            /// </summary>
            public static readonly string ToDate = "ToDate";
          
        }
        #endregion
        public int Id{ get; set; }
        public int JobPositionId{ get; set; }
        public double Price{ get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime ChangeDate{ get; set; }
        public DateTime? DeleteDate{ get; set; }
        public DateTime FromDate{ get; set; }
        public DateTime ToDate{ get; set; }
        public virtual JobPositions JobPositions{ get; set; }
        public bool HasJobPositions
        {
            get { return !ReferenceEquals(JobPositions, null); }
        }
        DateTime? IIntervalFields.FromDate
        {
            get { return FromDate; }
            set { if(value.HasValue)FromDate = value.Value; else throw new ArgumentNullException("value"); }
        }
        DateTime? IIntervalFields.ToDate
        {
            get { return ToDate; }
            set { if(value.HasValue)ToDate = value.Value; else throw new ArgumentNullException("value"); }
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
        public Rates ShallowCopy()
        {
            return new Rates {
                       JobPositionId = JobPositionId,
                       Price = Price,
                       CreateDate = CreateDate,
                       ChangeDate = ChangeDate,
                       DeleteDate = DeleteDate,
                       FromDate = FromDate,
                       ToDate = ToDate,
        	           };
        }
    }
}
