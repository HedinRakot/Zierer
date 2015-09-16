using CoreBase.Entities;
using ProfiCraftsman.Contracts;
using System;
using System.Collections.Generic;

namespace ProfiCraftsman.Contracts.Entities
{
    /// <summary>
    ///     DE: Benutzer  EN: User
    /// </summary>
    public partial class User: IHasId<int>
        ,IRemovable
        ,ISystemFields
    {
        /// <summary>
        /// Table name
        /// </summary>
        public static readonly string EntityTableName = "dbo.User";
        #region Fields
        /// <summary>
        /// Columns names
        /// </summary>
        public static class Fields
        {
            /// <summary>
            /// Column name 'Id' for property <see cref="User.Id"/>
            /// </summary>
            public static readonly string Id = "Id";
            /// <summary>
            /// Column name 'RoleId' for property <see cref="User.RoleId"/>
            /// </summary>
            public static readonly string RoleId = "RoleId";
            /// <summary>
            /// Column name 'Login' for property <see cref="User.Login"/>
            /// </summary>
            public static readonly string Login = "Login";
            /// <summary>
            /// Column name 'Name' for property <see cref="User.Name"/>
            /// </summary>
            public static readonly string Name = "Name";
            /// <summary>
            /// Column name 'Password' for property <see cref="User.Password"/>
            /// </summary>
            public static readonly string Password = "Password";
            /// <summary>
            /// Column name 'CreateDate' for property <see cref="User.CreateDate"/>
            /// </summary>
            public static readonly string CreateDate = "CreateDate";
            /// <summary>
            /// Column name 'ChangeDate' for property <see cref="User.ChangeDate"/>
            /// </summary>
            public static readonly string ChangeDate = "ChangeDate";
            /// <summary>
            /// Column name 'DeleteDate' for property <see cref="User.DeleteDate"/>
            /// </summary>
            public static readonly string DeleteDate = "DeleteDate";
            /// <summary>
            /// Column name 'EmployeeId' for property <see cref="User.EmployeeId"/>
            /// </summary>
            public static readonly string EmployeeId = "EmployeeId";
            /// <summary>
            /// Column name 'Key' for property <see cref="User.Key"/>
            /// </summary>
            public static readonly string Key = "Key";
            /// <summary>
            /// Column name 'Token' for property <see cref="User.Token"/>
            /// </summary>
            public static readonly string Token = "Token";
          
        }
        #endregion
        public int Id{ get; set; }
        /// <summary>
        ///     DE: Rolle  EN: Role
        /// </summary>
        public int? RoleId{ get; set; }
        /// <summary>
        ///     DE: Login  EN: Login
        /// </summary>
        public string Login{ get; set; }
        /// <summary>
        ///     DE: Name  EN: Name
        /// </summary>
        public string Name{ get; set; }
        /// <summary>
        ///     DE: Passwort  EN: Password
        /// </summary>
        public string Password{ get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime ChangeDate{ get; set; }
        public DateTime? DeleteDate{ get; set; }
        public int? EmployeeId{ get; set; }
        public string Key{ get; set; }
        public string Token{ get; set; }
        public virtual ICollection<Terms> Terms{ get; set; }
        public virtual Role Role{ get; set; }
        public virtual Employees Employees{ get; set; }
        public bool HasRole
        {
            get { return !ReferenceEquals(Role, null); }
        }
        public bool HasEmployees
        {
            get { return !ReferenceEquals(Employees, null); }
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
        public User ShallowCopy()
        {
            return new User {
                       RoleId = RoleId,
                       Login = Login,
                       Name = Name,
                       Password = Password,
                       CreateDate = CreateDate,
                       ChangeDate = ChangeDate,
                       DeleteDate = DeleteDate,
                       EmployeeId = EmployeeId,
                       Key = Key,
                       Token = Token,
        	           };
        }
    }
}
