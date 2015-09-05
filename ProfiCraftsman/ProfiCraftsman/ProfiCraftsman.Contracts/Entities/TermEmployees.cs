using CoreBase.Entities;
using ProfiCraftsman.Contracts;
using System;

namespace ProfiCraftsman.Contracts.Entities
{
    public partial class TermEmployees: IHasId<int>
        ,IRemovable
        ,ISystemFields
    {
        /// <summary>
        /// Table name
        /// </summary>
        public static readonly string EntityTableName = "dbo.TermEmployees";
        #region Fields
        /// <summary>
        /// Columns names
        /// </summary>
        public static class Fields
        {
            /// <summary>
            /// Column name 'Id' for property <see cref="TermEmployees.Id"/>
            /// </summary>
            public static readonly string Id = "Id";
            /// <summary>
            /// Column name 'TermId' for property <see cref="TermEmployees.TermId"/>
            /// </summary>
            public static readonly string TermId = "TermId";
            /// <summary>
            /// Column name 'EmployeeId' for property <see cref="TermEmployees.EmployeeId"/>
            /// </summary>
            public static readonly string EmployeeId = "EmployeeId";
            /// <summary>
            /// Column name 'CreateDate' for property <see cref="TermEmployees.CreateDate"/>
            /// </summary>
            public static readonly string CreateDate = "CreateDate";
            /// <summary>
            /// Column name 'ChangeDate' for property <see cref="TermEmployees.ChangeDate"/>
            /// </summary>
            public static readonly string ChangeDate = "ChangeDate";
            /// <summary>
            /// Column name 'DeleteDate' for property <see cref="TermEmployees.DeleteDate"/>
            /// </summary>
            public static readonly string DeleteDate = "DeleteDate";
          
        }
        #endregion
        public int Id{ get; set; }
        public int TermId{ get; set; }
        public int EmployeeId{ get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime ChangeDate{ get; set; }
        public DateTime? DeleteDate{ get; set; }
        public virtual Employees Employees{ get; set; }
        public virtual Terms Terms{ get; set; }
        public bool HasEmployees
        {
            get { return !ReferenceEquals(Employees, null); }
        }
        public bool HasTerms
        {
            get { return !ReferenceEquals(Terms, null); }
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
        public TermEmployees ShallowCopy()
        {
            return new TermEmployees {
                       TermId = TermId,
                       EmployeeId = EmployeeId,
                       CreateDate = CreateDate,
                       ChangeDate = ChangeDate,
                       DeleteDate = DeleteDate,
        	           };
        }
    }
}
