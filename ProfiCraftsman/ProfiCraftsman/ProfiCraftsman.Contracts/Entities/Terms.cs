using CoreBase.Entities;
using ProfiCraftsman.Contracts;
using System;

namespace ProfiCraftsman.Contracts.Entities
{
    public partial class Terms: IHasId<int>
        ,IRemovable
        ,ISystemFields
    {
        /// <summary>
        /// Table name
        /// </summary>
        public static readonly string EntityTableName = "dbo.Terms";
        #region Fields
        /// <summary>
        /// Columns names
        /// </summary>
        public static class Fields
        {
            /// <summary>
            /// Column name 'Id' for property <see cref="Terms.Id"/>
            /// </summary>
            public static readonly string Id = "Id";
            /// <summary>
            /// Column name 'Date' for property <see cref="Terms.Date"/>
            /// </summary>
            public static readonly string Date = "Date";
            /// <summary>
            /// Column name 'EmployeeId' for property <see cref="Terms.EmployeeId"/>
            /// </summary>
            public static readonly string EmployeeId = "EmployeeId";
            /// <summary>
            /// Column name 'AutoId' for property <see cref="Terms.AutoId"/>
            /// </summary>
            public static readonly string AutoId = "AutoId";
            /// <summary>
            /// Column name 'Comment' for property <see cref="Terms.Comment"/>
            /// </summary>
            public static readonly string Comment = "Comment";
            /// <summary>
            /// Column name 'CreateDate' for property <see cref="Terms.CreateDate"/>
            /// </summary>
            public static readonly string CreateDate = "CreateDate";
            /// <summary>
            /// Column name 'ChangeDate' for property <see cref="Terms.ChangeDate"/>
            /// </summary>
            public static readonly string ChangeDate = "ChangeDate";
            /// <summary>
            /// Column name 'DeleteDate' for property <see cref="Terms.DeleteDate"/>
            /// </summary>
            public static readonly string DeleteDate = "DeleteDate";
            /// <summary>
            /// Column name 'Status' for property <see cref="Terms.Status"/>
            /// </summary>
            public static readonly string Status = "Status";
            /// <summary>
            /// Column name 'OrderId' for property <see cref="Terms.OrderId"/>
            /// </summary>
            public static readonly string OrderId = "OrderId";
          
        }
        #endregion
        public int Id{ get; set; }
        public DateTime Date{ get; set; }
        public int EmployeeId{ get; set; }
        public int AutoId{ get; set; }
        public string Comment{ get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime ChangeDate{ get; set; }
        public DateTime? DeleteDate{ get; set; }
        public int Status{ get; set; }
        public int OrderId{ get; set; }
        public virtual Autos Autos{ get; set; }
        public virtual Employees Employees{ get; set; }
        public virtual Orders Orders{ get; set; }
        public bool HasAutos
        {
            get { return !ReferenceEquals(Autos, null); }
        }
        public bool HasEmployees
        {
            get { return !ReferenceEquals(Employees, null); }
        }
        public bool HasOrders
        {
            get { return !ReferenceEquals(Orders, null); }
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
        public Terms ShallowCopy()
        {
            return new Terms {
                       Date = Date,
                       EmployeeId = EmployeeId,
                       AutoId = AutoId,
                       Comment = Comment,
                       CreateDate = CreateDate,
                       ChangeDate = ChangeDate,
                       DeleteDate = DeleteDate,
                       Status = Status,
                       OrderId = OrderId,
        	           };
        }
    }
}
