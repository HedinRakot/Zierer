using CoreBase.Entities;
using ProfiCraftsman.Contracts;
using System;

namespace ProfiCraftsman.Contracts.Entities
{
    public partial class EmployeeRateRsp: IHasId<int>
        ,IIntervalFields
        ,IRemovable
        ,ISystemFields
    {
        /// <summary>
        /// Table name
        /// </summary>
        public static readonly string EntityTableName = "dbo.Employee_Rate_Rsp";
        #region Fields
        /// <summary>
        /// Columns names
        /// </summary>
        public static class Fields
        {
            /// <summary>
            /// Column name 'Id' for property <see cref="EmployeeRateRsp.Id"/>
            /// </summary>
            public static readonly string Id = "Id";
            /// <summary>
            /// Column name 'EmployeeId' for property <see cref="EmployeeRateRsp.EmployeeId"/>
            /// </summary>
            public static readonly string EmployeeId = "EmployeeId";
            /// <summary>
            /// Column name 'JobPositionId' for property <see cref="EmployeeRateRsp.JobPositionId"/>
            /// </summary>
            public static readonly string JobPositionId = "JobPositionId";
            /// <summary>
            /// Column name 'CreateDate' for property <see cref="EmployeeRateRsp.CreateDate"/>
            /// </summary>
            public static readonly string CreateDate = "CreateDate";
            /// <summary>
            /// Column name 'ChangeDate' for property <see cref="EmployeeRateRsp.ChangeDate"/>
            /// </summary>
            public static readonly string ChangeDate = "ChangeDate";
            /// <summary>
            /// Column name 'DeleteDate' for property <see cref="EmployeeRateRsp.DeleteDate"/>
            /// </summary>
            public static readonly string DeleteDate = "DeleteDate";
            /// <summary>
            /// Column name 'FromDate' for property <see cref="EmployeeRateRsp.FromDate"/>
            /// </summary>
            public static readonly string FromDate = "FromDate";
            /// <summary>
            /// Column name 'ToDate' for property <see cref="EmployeeRateRsp.ToDate"/>
            /// </summary>
            public static readonly string ToDate = "ToDate";
            /// <summary>
            /// Column name 'SalaryType' for property <see cref="EmployeeRateRsp.SalaryType"/>
            /// </summary>
            public static readonly string SalaryType = "SalaryType";
            /// <summary>
            /// Column name 'Salary' for property <see cref="EmployeeRateRsp.Salary"/>
            /// </summary>
            public static readonly string Salary = "Salary";
          
        }
        #endregion
        public int Id{ get; set; }
        public int EmployeeId{ get; set; }
        public int JobPositionId{ get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime ChangeDate{ get; set; }
        public DateTime? DeleteDate{ get; set; }
        public DateTime FromDate{ get; set; }
        public DateTime ToDate{ get; set; }
        public int SalaryType{ get; set; }
        public double Salary{ get; set; }
        public virtual JobPositions JobPositions{ get; set; }
        public virtual Employees Employees{ get; set; }
        public bool HasJobPositions
        {
            get { return !ReferenceEquals(JobPositions, null); }
        }
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
        public EmployeeRateRsp ShallowCopy()
        {
            return new EmployeeRateRsp {
                       EmployeeId = EmployeeId,
                       JobPositionId = JobPositionId,
                       CreateDate = CreateDate,
                       ChangeDate = ChangeDate,
                       DeleteDate = DeleteDate,
                       FromDate = FromDate,
                       ToDate = ToDate,
                       SalaryType = SalaryType,
                       Salary = Salary,
        	           };
        }
    }
}
