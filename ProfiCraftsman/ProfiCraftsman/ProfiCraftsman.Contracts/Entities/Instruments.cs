using CoreBase.Entities;
using ProfiCraftsman.Contracts;
using System;
using System.Collections.Generic;

namespace ProfiCraftsman.Contracts.Entities
{
    public partial class Instruments: IHasId<int>
        ,IHasTitle<int>
        ,IRemovable
        ,ISystemFields
    {
        /// <summary>
        /// Table name
        /// </summary>
        public static readonly string EntityTableName = "dbo.Instruments";
        #region Fields
        /// <summary>
        /// Columns names
        /// </summary>
        public static class Fields
        {
            /// <summary>
            /// Column name 'Id' for property <see cref="Instruments.Id"/>
            /// </summary>
            public static readonly string Id = "Id";
            /// <summary>
            /// Column name 'Name' for property <see cref="Instruments.Name"/>
            /// </summary>
            public static readonly string Name = "Name";
            /// <summary>
            /// Column name 'Number' for property <see cref="Instruments.Number"/>
            /// </summary>
            public static readonly string Number = "Number";
            /// <summary>
            /// Column name 'IsForAuto' for property <see cref="Instruments.IsForAuto"/>
            /// </summary>
            public static readonly string IsForAuto = "IsForAuto";
            /// <summary>
            /// Column name 'BoughtFrom' for property <see cref="Instruments.BoughtFrom"/>
            /// </summary>
            public static readonly string BoughtFrom = "BoughtFrom";
            /// <summary>
            /// Column name 'BoughtPrice' for property <see cref="Instruments.BoughtPrice"/>
            /// </summary>
            public static readonly string BoughtPrice = "BoughtPrice";
            /// <summary>
            /// Column name 'Comment' for property <see cref="Instruments.Comment"/>
            /// </summary>
            public static readonly string Comment = "Comment";
            /// <summary>
            /// Column name 'CreateDate' for property <see cref="Instruments.CreateDate"/>
            /// </summary>
            public static readonly string CreateDate = "CreateDate";
            /// <summary>
            /// Column name 'ChangeDate' for property <see cref="Instruments.ChangeDate"/>
            /// </summary>
            public static readonly string ChangeDate = "ChangeDate";
            /// <summary>
            /// Column name 'DeleteDate' for property <see cref="Instruments.DeleteDate"/>
            /// </summary>
            public static readonly string DeleteDate = "DeleteDate";
            /// <summary>
            /// Column name 'ProceedsAccountId' for property <see cref="Instruments.ProceedsAccountId"/>
            /// </summary>
            public static readonly string ProceedsAccountId = "ProceedsAccountId";
          
        }
        #endregion
        public int Id{ get; set; }
        public string Name{ get; set; }
        public string Number{ get; set; }
        public bool IsForAuto{ get; set; }
        public string BoughtFrom{ get; set; }
        public double BoughtPrice{ get; set; }
        public string Comment{ get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime ChangeDate{ get; set; }
        public DateTime? DeleteDate{ get; set; }
        public int ProceedsAccountId{ get; set; }
        public virtual ProceedsAccounts ProceedsAccounts{ get; set; }
        public virtual ICollection<AutoInstrumentRsp> AutoInstrumentRsps{ get; set; }
        public virtual ICollection<TermInstruments> TermInstruments{ get; set; }
        public bool HasProceedsAccounts
        {
            get { return !ReferenceEquals(ProceedsAccounts, null); }
        }
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
        public Instruments ShallowCopy()
        {
            return new Instruments {
                       Name = Name,
                       Number = Number,
                       IsForAuto = IsForAuto,
                       BoughtFrom = BoughtFrom,
                       BoughtPrice = BoughtPrice,
                       Comment = Comment,
                       CreateDate = CreateDate,
                       ChangeDate = ChangeDate,
                       DeleteDate = DeleteDate,
                       ProceedsAccountId = ProceedsAccountId,
        	           };
        }
    }
}
