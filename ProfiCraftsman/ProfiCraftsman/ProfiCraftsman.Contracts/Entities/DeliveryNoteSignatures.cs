using CoreBase.Entities;
using ProfiCraftsman.Contracts;
using System;

namespace ProfiCraftsman.Contracts.Entities
{
    public partial class DeliveryNoteSignatures: IHasId<int>
        ,IRemovable
        ,ISystemFields
    {
        /// <summary>
        /// Table name
        /// </summary>
        public static readonly string EntityTableName = "dbo.DeliveryNoteSignatures";
        #region Fields
        /// <summary>
        /// Columns names
        /// </summary>
        public static class Fields
        {
            /// <summary>
            /// Column name 'Id' for property <see cref="DeliveryNoteSignatures.Id"/>
            /// </summary>
            public static readonly string Id = "Id";
            /// <summary>
            /// Column name 'TermId' for property <see cref="DeliveryNoteSignatures.TermId"/>
            /// </summary>
            public static readonly string TermId = "TermId";
            /// <summary>
            /// Column name 'CreateDate' for property <see cref="DeliveryNoteSignatures.CreateDate"/>
            /// </summary>
            public static readonly string CreateDate = "CreateDate";
            /// <summary>
            /// Column name 'ChangeDate' for property <see cref="DeliveryNoteSignatures.ChangeDate"/>
            /// </summary>
            public static readonly string ChangeDate = "ChangeDate";
            /// <summary>
            /// Column name 'DeleteDate' for property <see cref="DeliveryNoteSignatures.DeleteDate"/>
            /// </summary>
            public static readonly string DeleteDate = "DeleteDate";
            /// <summary>
            /// Column name 'Signature' for property <see cref="DeliveryNoteSignatures.Signature"/>
            /// </summary>
            public static readonly string Signature = "Signature";
          
        }
        #endregion
        public int Id{ get; set; }
        public int TermId{ get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime ChangeDate{ get; set; }
        public DateTime? DeleteDate{ get; set; }
        public string Signature{ get; set; }
        public virtual Terms Terms{ get; set; }
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
        public DeliveryNoteSignatures ShallowCopy()
        {
            return new DeliveryNoteSignatures {
                       TermId = TermId,
                       CreateDate = CreateDate,
                       ChangeDate = ChangeDate,
                       DeleteDate = DeleteDate,
                       Signature = Signature,
        	           };
        }
    }
}
