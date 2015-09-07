using CoreBase.Entities;
using ProfiCraftsman.Contracts;
using System;
using System.Collections.Generic;

namespace ProfiCraftsman.Contracts.Entities
{
    public partial class TermPositions: IHasId<int>
        ,IRemovable
        ,ISystemFields
    {
        /// <summary>
        /// Table name
        /// </summary>
        public static readonly string EntityTableName = "dbo.TermPositions";
        #region Fields
        /// <summary>
        /// Columns names
        /// </summary>
        public static class Fields
        {
            /// <summary>
            /// Column name 'Id' for property <see cref="TermPositions.Id"/>
            /// </summary>
            public static readonly string Id = "Id";
            /// <summary>
            /// Column name 'TermId' for property <see cref="TermPositions.TermId"/>
            /// </summary>
            public static readonly string TermId = "TermId";
            /// <summary>
            /// Column name 'PositionId' for property <see cref="TermPositions.PositionId"/>
            /// </summary>
            public static readonly string PositionId = "PositionId";
            /// <summary>
            /// Column name 'Amount' for property <see cref="TermPositions.Amount"/>
            /// </summary>
            public static readonly string Amount = "Amount";
            /// <summary>
            /// Column name 'CreateDate' for property <see cref="TermPositions.CreateDate"/>
            /// </summary>
            public static readonly string CreateDate = "CreateDate";
            /// <summary>
            /// Column name 'ChangeDate' for property <see cref="TermPositions.ChangeDate"/>
            /// </summary>
            public static readonly string ChangeDate = "ChangeDate";
            /// <summary>
            /// Column name 'DeleteDate' for property <see cref="TermPositions.DeleteDate"/>
            /// </summary>
            public static readonly string DeleteDate = "DeleteDate";
            /// <summary>
            /// Column name 'ProccessedAmount' for property <see cref="TermPositions.ProccessedAmount"/>
            /// </summary>
            public static readonly string ProccessedAmount = "ProccessedAmount";
          
        }
        #endregion
        public int Id{ get; set; }
        public int TermId{ get; set; }
        public int PositionId{ get; set; }
        public int Amount{ get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime ChangeDate{ get; set; }
        public DateTime? DeleteDate{ get; set; }
        public int? ProccessedAmount{ get; set; }
        public virtual ICollection<TermPositionMaterialRsp> TermPositionMaterialRsps{ get; set; }
        public virtual Terms Terms{ get; set; }
        public virtual Positions Positions{ get; set; }
        public bool HasTerms
        {
            get { return !ReferenceEquals(Terms, null); }
        }
        public bool HasPositions
        {
            get { return !ReferenceEquals(Positions, null); }
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
        public TermPositions ShallowCopy()
        {
            return new TermPositions {
                       TermId = TermId,
                       PositionId = PositionId,
                       Amount = Amount,
                       CreateDate = CreateDate,
                       ChangeDate = ChangeDate,
                       DeleteDate = DeleteDate,
                       ProccessedAmount = ProccessedAmount,
        	           };
        }
    }
}
