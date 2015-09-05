using CoreBase.Entities;
using ProfiCraftsman.Contracts;
using System;
using System.Collections.Generic;

namespace ProfiCraftsman.Contracts.Entities
{
    public partial class Employees: IHasId<int>
        ,IHasTitle<int>
        ,IRemovable
        ,ISystemFields
    {
        /// <summary>
        /// Table name
        /// </summary>
        public static readonly string EntityTableName = "dbo.Employees";
        #region Fields
        /// <summary>
        /// Columns names
        /// </summary>
        public static class Fields
        {
            /// <summary>
            /// Column name 'Id' for property <see cref="Employees.Id"/>
            /// </summary>
            public static readonly string Id = "Id";
            /// <summary>
            /// Column name 'Number' for property <see cref="Employees.Number"/>
            /// </summary>
            public static readonly string Number = "Number";
            /// <summary>
            /// Column name 'JobPositionId' for property <see cref="Employees.JobPositionId"/>
            /// </summary>
            public static readonly string JobPositionId = "JobPositionId";
            /// <summary>
            /// Column name 'AutoId' for property <see cref="Employees.AutoId"/>
            /// </summary>
            public static readonly string AutoId = "AutoId";
            /// <summary>
            /// Column name 'Name' for property <see cref="Employees.Name"/>
            /// </summary>
            public static readonly string Name = "Name";
            /// <summary>
            /// Column name 'FirstName' for property <see cref="Employees.FirstName"/>
            /// </summary>
            public static readonly string FirstName = "FirstName";
            /// <summary>
            /// Column name 'Street' for property <see cref="Employees.Street"/>
            /// </summary>
            public static readonly string Street = "Street";
            /// <summary>
            /// Column name 'ZIP' for property <see cref="Employees.Zip"/>
            /// </summary>
            public static readonly string Zip = "ZIP";
            /// <summary>
            /// Column name 'City' for property <see cref="Employees.City"/>
            /// </summary>
            public static readonly string City = "City";
            /// <summary>
            /// Column name 'Country' for property <see cref="Employees.Country"/>
            /// </summary>
            public static readonly string Country = "Country";
            /// <summary>
            /// Column name 'Phone' for property <see cref="Employees.Phone"/>
            /// </summary>
            public static readonly string Phone = "Phone";
            /// <summary>
            /// Column name 'Mobile' for property <see cref="Employees.Mobile"/>
            /// </summary>
            public static readonly string Mobile = "Mobile";
            /// <summary>
            /// Column name 'Fax' for property <see cref="Employees.Fax"/>
            /// </summary>
            public static readonly string Fax = "Fax";
            /// <summary>
            /// Column name 'Email' for property <see cref="Employees.Email"/>
            /// </summary>
            public static readonly string Email = "Email";
            /// <summary>
            /// Column name 'Comment' for property <see cref="Employees.Comment"/>
            /// </summary>
            public static readonly string Comment = "Comment";
            /// <summary>
            /// Column name 'CreateDate' for property <see cref="Employees.CreateDate"/>
            /// </summary>
            public static readonly string CreateDate = "CreateDate";
            /// <summary>
            /// Column name 'ChangeDate' for property <see cref="Employees.ChangeDate"/>
            /// </summary>
            public static readonly string ChangeDate = "ChangeDate";
            /// <summary>
            /// Column name 'DeleteDate' for property <see cref="Employees.DeleteDate"/>
            /// </summary>
            public static readonly string DeleteDate = "DeleteDate";
            /// <summary>
            /// Column name 'Color' for property <see cref="Employees.Color"/>
            /// </summary>
            public static readonly string Color = "Color";
          
        }
        #endregion
        public int Id{ get; set; }
        public int Number{ get; set; }
        public int JobPositionId{ get; set; }
        public int AutoId{ get; set; }
        public string Name{ get; set; }
        public string FirstName{ get; set; }
        public string Street{ get; set; }
        public string Zip{ get; set; }
        public string City{ get; set; }
        public string Country{ get; set; }
        public string Phone{ get; set; }
        public string Mobile{ get; set; }
        public string Fax{ get; set; }
        public string Email{ get; set; }
        public string Comment{ get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime ChangeDate{ get; set; }
        public DateTime? DeleteDate{ get; set; }
        public string Color{ get; set; }
        public virtual ICollection<TermEmployees> TermEmployees{ get; set; }
        public virtual JobPositions JobPositions{ get; set; }
        public virtual Autos Autos{ get; set; }
        public virtual ICollection<User> Users{ get; set; }
        public bool HasJobPositions
        {
            get { return !ReferenceEquals(JobPositions, null); }
        }
        public bool HasAutos
        {
            get { return !ReferenceEquals(Autos, null); }
        }
        string IHasTitle<int>.EntityTitle
        {
            get { return Name; }
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
        public Employees ShallowCopy()
        {
            return new Employees {
                       Number = Number,
                       JobPositionId = JobPositionId,
                       AutoId = AutoId,
                       Name = Name,
                       FirstName = FirstName,
                       Street = Street,
                       Zip = Zip,
                       City = City,
                       Country = Country,
                       Phone = Phone,
                       Mobile = Mobile,
                       Fax = Fax,
                       Email = Email,
                       Comment = Comment,
                       CreateDate = CreateDate,
                       ChangeDate = ChangeDate,
                       DeleteDate = DeleteDate,
                       Color = Color,
        	           };
        }
    }
}
