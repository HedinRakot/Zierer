using CoreBase.Entities;
using ProfiCraftsman.Contracts;
using System;
using System.Collections.Generic;

namespace ProfiCraftsman.Contracts.Entities
{
    public partial class Materials: IHasId<int>
        ,IHasTitle<int>
        ,IRemovable
        ,ISystemFields
    {
        /// <summary>
        /// Table name
        /// </summary>
        public static readonly string EntityTableName = "dbo.Materials";
        #region Fields
        /// <summary>
        /// Columns names
        /// </summary>
        public static class Fields
        {
            /// <summary>
            /// Column name 'Id' for property <see cref="Materials.Id"/>
            /// </summary>
            public static readonly string Id = "Id";
            /// <summary>
            /// Column name 'Name' for property <see cref="Materials.Name"/>
            /// </summary>
            public static readonly string Name = "Name";
            /// <summary>
            /// Column name 'Number' for property <see cref="Materials.Number"/>
            /// </summary>
            public static readonly string Number = "Number";
            /// <summary>
            /// Column name 'Length' for property <see cref="Materials.Length"/>
            /// </summary>
            public static readonly string Length = "Length";
            /// <summary>
            /// Column name 'Width' for property <see cref="Materials.Width"/>
            /// </summary>
            public static readonly string Width = "Width";
            /// <summary>
            /// Column name 'Height' for property <see cref="Materials.Height"/>
            /// </summary>
            public static readonly string Height = "Height";
            /// <summary>
            /// Column name 'Color' for property <see cref="Materials.Color"/>
            /// </summary>
            public static readonly string Color = "Color";
            /// <summary>
            /// Column name 'Price' for property <see cref="Materials.Price"/>
            /// </summary>
            public static readonly string Price = "Price";
            /// <summary>
            /// Column name 'ProceedsAccount' for property <see cref="Materials.ProceedsAccount"/>
            /// </summary>
            public static readonly string ProceedsAccount = "ProceedsAccount";
            /// <summary>
            /// Column name 'IsVirtual' for property <see cref="Materials.IsVirtual"/>
            /// </summary>
            public static readonly string IsVirtual = "IsVirtual";
            /// <summary>
            /// Column name 'BoughtFrom' for property <see cref="Materials.BoughtFrom"/>
            /// </summary>
            public static readonly string BoughtFrom = "BoughtFrom";
            /// <summary>
            /// Column name 'BoughtPrice' for property <see cref="Materials.BoughtPrice"/>
            /// </summary>
            public static readonly string BoughtPrice = "BoughtPrice";
            /// <summary>
            /// Column name 'Comment' for property <see cref="Materials.Comment"/>
            /// </summary>
            public static readonly string Comment = "Comment";
            /// <summary>
            /// Column name 'CreateDate' for property <see cref="Materials.CreateDate"/>
            /// </summary>
            public static readonly string CreateDate = "CreateDate";
            /// <summary>
            /// Column name 'ChangeDate' for property <see cref="Materials.ChangeDate"/>
            /// </summary>
            public static readonly string ChangeDate = "ChangeDate";
            /// <summary>
            /// Column name 'DeleteDate' for property <see cref="Materials.DeleteDate"/>
            /// </summary>
            public static readonly string DeleteDate = "DeleteDate";
            /// <summary>
            /// Column name 'MaterialAmountType' for property <see cref="Materials.MaterialAmountType"/>
            /// </summary>
            public static readonly string MaterialAmountType = "MaterialAmountType";
          
        }
        #endregion
        public int Id{ get; set; }
        public string Name{ get; set; }
        public string Number{ get; set; }
        public int? Length{ get; set; }
        public int? Width{ get; set; }
        public int? Height{ get; set; }
        public string Color{ get; set; }
        public double Price{ get; set; }
        public int ProceedsAccount{ get; set; }
        public bool IsVirtual{ get; set; }
        public string BoughtFrom{ get; set; }
        public double BoughtPrice{ get; set; }
        public string Comment{ get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime ChangeDate{ get; set; }
        public DateTime? DeleteDate{ get; set; }
        public int MaterialAmountType{ get; set; }
        public virtual ICollection<Positions> Positions{ get; set; }
        public virtual ICollection<PositionMaterialRsp> PositionMaterialRsps{ get; set; }
        public virtual ICollection<ProductMaterialRsp> ProductMaterialRsps{ get; set; }
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
        public Materials ShallowCopy()
        {
            return new Materials {
                       Name = Name,
                       Number = Number,
                       Length = Length,
                       Width = Width,
                       Height = Height,
                       Color = Color,
                       Price = Price,
                       ProceedsAccount = ProceedsAccount,
                       IsVirtual = IsVirtual,
                       BoughtFrom = BoughtFrom,
                       BoughtPrice = BoughtPrice,
                       Comment = Comment,
                       CreateDate = CreateDate,
                       ChangeDate = ChangeDate,
                       DeleteDate = DeleteDate,
                       MaterialAmountType = MaterialAmountType,
        	           };
        }
    }
}
