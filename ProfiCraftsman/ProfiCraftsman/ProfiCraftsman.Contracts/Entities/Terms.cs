using CoreBase.Entities;
using ProfiCraftsman.Contracts;
using System;
using System.Collections.Generic;

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
            /// <summary>
            /// Column name 'BeginTrip' for property <see cref="Terms.BeginTrip"/>
            /// </summary>
            public static readonly string BeginTrip = "BeginTrip";
            /// <summary>
            /// Column name 'EndTrip' for property <see cref="Terms.EndTrip"/>
            /// </summary>
            public static readonly string EndTrip = "EndTrip";
            /// <summary>
            /// Column name 'BeginWork' for property <see cref="Terms.BeginWork"/>
            /// </summary>
            public static readonly string BeginWork = "BeginWork";
            /// <summary>
            /// Column name 'EndWork' for property <see cref="Terms.EndWork"/>
            /// </summary>
            public static readonly string EndWork = "EndWork";
            /// <summary>
            /// Column name 'BeginReturnTrip' for property <see cref="Terms.BeginReturnTrip"/>
            /// </summary>
            public static readonly string BeginReturnTrip = "BeginReturnTrip";
            /// <summary>
            /// Column name 'EndReturnTrip' for property <see cref="Terms.EndReturnTrip"/>
            /// </summary>
            public static readonly string EndReturnTrip = "EndReturnTrip";
            /// <summary>
            /// Column name 'Duration' for property <see cref="Terms.Duration"/>
            /// </summary>
            public static readonly string Duration = "Duration";
            /// <summary>
            /// Column name 'UserId' for property <see cref="Terms.UserId"/>
            /// </summary>
            public static readonly string UserId = "UserId";
            /// <summary>
            /// Column name 'BeginTripFromOffice' for property <see cref="Terms.BeginTripFromOffice"/>
            /// </summary>
            public static readonly string BeginTripFromOffice = "BeginTripFromOffice";
            /// <summary>
            /// Column name 'DeliveryNoteFileName' for property <see cref="Terms.DeliveryNoteFileName"/>
            /// </summary>
            public static readonly string DeliveryNoteFileName = "DeliveryNoteFileName";
          
        }
        #endregion
        public int Id{ get; set; }
        public DateTime Date{ get; set; }
        public int AutoId{ get; set; }
        public string Comment{ get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime ChangeDate{ get; set; }
        public DateTime? DeleteDate{ get; set; }
        public int Status{ get; set; }
        public int OrderId{ get; set; }
        public DateTime? BeginTrip{ get; set; }
        public DateTime? EndTrip{ get; set; }
        public DateTime? BeginWork{ get; set; }
        public DateTime? EndWork{ get; set; }
        public DateTime? BeginReturnTrip{ get; set; }
        public DateTime? EndReturnTrip{ get; set; }
        public int Duration{ get; set; }
        public int? UserId{ get; set; }
        public bool? BeginTripFromOffice{ get; set; }
        public string DeliveryNoteFileName{ get; set; }
        public virtual ICollection<DeliveryNoteSignatures> DeliveryNoteSignatures{ get; set; }
        public virtual ICollection<Positions> Positions{ get; set; }
        public virtual ICollection<TermEmployees> TermEmployees{ get; set; }
        public virtual ICollection<TermCosts> TermCosts{ get; set; }
        public virtual User User{ get; set; }
        public virtual Autos Autos{ get; set; }
        public virtual Orders Orders{ get; set; }
        public virtual ICollection<TermPositions> TermPositions{ get; set; }
        public virtual ICollection<TermInstruments> TermInstruments{ get; set; }
        public bool HasUser
        {
            get { return !ReferenceEquals(User, null); }
        }
        public bool HasAutos
        {
            get { return !ReferenceEquals(Autos, null); }
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
                       AutoId = AutoId,
                       Comment = Comment,
                       CreateDate = CreateDate,
                       ChangeDate = ChangeDate,
                       DeleteDate = DeleteDate,
                       Status = Status,
                       OrderId = OrderId,
                       BeginTrip = BeginTrip,
                       EndTrip = EndTrip,
                       BeginWork = BeginWork,
                       EndWork = EndWork,
                       BeginReturnTrip = BeginReturnTrip,
                       EndReturnTrip = EndReturnTrip,
                       Duration = Duration,
                       UserId = UserId,
                       BeginTripFromOffice = BeginTripFromOffice,
                       DeliveryNoteFileName = DeliveryNoteFileName,
        	           };
        }
    }
}
