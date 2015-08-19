using ProfiCraftsman.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ProfiCraftsman.Contracts.Entities
{
    /// <summary>
    ///  Material
    /// </summary>
    public partial class Materials
    {
        public MaterialAmountTypes MaterialAmountTypes
        {
            get
            {
                return (MaterialAmountTypes)MaterialAmountType;
            }
        }

        public string MaterialAmountTypeString
        {
            get
            {
                var result = String.Empty;

                switch(MaterialAmountTypes)
                {
                    case MaterialAmountTypes.Item:
                        result = "Stück";
                        break;
                    case MaterialAmountTypes.Meter:
                        result = "Meter";
                        break;
                }

                return result;
            }
        }
    }
}
