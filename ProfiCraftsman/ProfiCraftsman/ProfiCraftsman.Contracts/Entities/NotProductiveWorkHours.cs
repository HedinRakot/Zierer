using CoreBase.Entities;
using ProfiCraftsman.Contracts;
using System;

namespace ProfiCraftsman.Contracts.Entities
{
    public partial class NotProductiveWorkHours: IHasId<int>
        ,IIntervalFields
        ,IRemovable
        ,ISystemFields
    {
        /// <summary>
        /// Table name
        /// </summary>
        public static readonly string EntityTableName = "dbo.NotProductiveWorkHours";
        #region Fields
        /// <summary>
        /// Columns names
        /// </summary>
        public static class Fields
        {
            /// <summary>
            /// Column name 'Id' for property <see cref="NotProductiveWorkHours.Id"/>
            /// </summary>
            public static readonly string Id = "Id";
            /// <summary>
            /// Column name 'EmployeeId' for property <see cref="NotProductiveWorkHours.EmployeeId"/>
            /// </summary>
            public static readonly string EmployeeId = "EmployeeId";
            /// <summary>
            /// Column name 'Description' for property <see cref="NotProductiveWorkHours.Description"/>
            /// </summary>
            public static readonly string Description = "Description";
            /// <summary>
            /// Column name 'FromDate' for property <see cref="NotProductiveWorkHours.FromDate"/>
            /// </summary>
            public static readonly string FromDate = "FromDate";
            /// <summary>
            /// Column name 'ToDate' for property <see cref="NotProductiveWorkHours.ToDate"/>
            /// </summary>
            public static readonly string ToDate = "ToDate";
            /// <summary>
            /// Column name 'CreateDate' for property <see cref="NotProductiveWorkHours.CreateDate"/>
            /// </summary>
            public static readonly string CreateDate = "CreateDate";
            /// <summary>
            /// Column name 'ChangeDate' for property <see cref="NotProductiveWorkHours.ChangeDate"/>
            /// </summary>
            public static readonly string ChangeDate = "ChangeDate";
            /// <summary>
            /// Column name 'DeleteDate' for property <see cref="NotProductiveWorkHours.DeleteDate"/>
            /// </summary>
            public static readonly string DeleteDate = "DeleteDate";
          
        }
        #endregion
        public int Id{ get; set; }
        public int EmployeeId{ get; set; }
        public string Description{ get; set; }
        public DateTime FromDate{ get; set; }
        public DateTime ToDate{ get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime ChangeDate{ get; set; }
        public DateTime? DeleteDate{ get; set; }
        public virtual Employees Employees{ get; set; }
        public bool HasEmployees
        {
            get { return !ReferenceEquals(Employees, null); }
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
        public NotProductiveWorkHours ShallowCopy()
        {
            return new NotProductiveWorkHours {
                       EmployeeId = EmployeeId,
                       Description = Description,
                       FromDate = FromDate,
                       ToDate = ToDate,
                       CreateDate = CreateDate,
                       ChangeDate = ChangeDate,
                       DeleteDate = DeleteDate,
        	           };
        }
    }
}
