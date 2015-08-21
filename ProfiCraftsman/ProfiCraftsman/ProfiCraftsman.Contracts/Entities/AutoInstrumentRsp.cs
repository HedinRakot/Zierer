using CoreBase.Entities;
using ProfiCraftsman.Contracts;
using System;

namespace ProfiCraftsman.Contracts.Entities
{
    public partial class AutoInstrumentRsp: IHasId<int>
        ,IRemovable
        ,ISystemFields
    {
        /// <summary>
        /// Table name
        /// </summary>
        public static readonly string EntityTableName = "dbo.Auto_Instrument_Rsp";
        #region Fields
        /// <summary>
        /// Columns names
        /// </summary>
        public static class Fields
        {
            /// <summary>
            /// Column name 'Id' for property <see cref="AutoInstrumentRsp.Id"/>
            /// </summary>
            public static readonly string Id = "Id";
            /// <summary>
            /// Column name 'AutoId' for property <see cref="AutoInstrumentRsp.AutoId"/>
            /// </summary>
            public static readonly string AutoId = "AutoId";
            /// <summary>
            /// Column name 'InstrumentId' for property <see cref="AutoInstrumentRsp.InstrumentId"/>
            /// </summary>
            public static readonly string InstrumentId = "InstrumentId";
            /// <summary>
            /// Column name 'Amount' for property <see cref="AutoInstrumentRsp.Amount"/>
            /// </summary>
            public static readonly string Amount = "Amount";
            /// <summary>
            /// Column name 'CreateDate' for property <see cref="AutoInstrumentRsp.CreateDate"/>
            /// </summary>
            public static readonly string CreateDate = "CreateDate";
            /// <summary>
            /// Column name 'ChangeDate' for property <see cref="AutoInstrumentRsp.ChangeDate"/>
            /// </summary>
            public static readonly string ChangeDate = "ChangeDate";
            /// <summary>
            /// Column name 'DeleteDate' for property <see cref="AutoInstrumentRsp.DeleteDate"/>
            /// </summary>
            public static readonly string DeleteDate = "DeleteDate";
          
        }
        #endregion
        public int Id{ get; set; }
        public int AutoId{ get; set; }
        public int InstrumentId{ get; set; }
        public int Amount{ get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime ChangeDate{ get; set; }
        public DateTime? DeleteDate{ get; set; }
        public virtual Instruments Instruments{ get; set; }
        public virtual Autos Autos{ get; set; }
        public bool HasInstruments
        {
            get { return !ReferenceEquals(Instruments, null); }
        }
        public bool HasAutos
        {
            get { return !ReferenceEquals(Autos, null); }
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
        public AutoInstrumentRsp ShallowCopy()
        {
            return new AutoInstrumentRsp {
                       AutoId = AutoId,
                       InstrumentId = InstrumentId,
                       Amount = Amount,
                       CreateDate = CreateDate,
                       ChangeDate = ChangeDate,
                       DeleteDate = DeleteDate,
        	           };
        }
    }
}
