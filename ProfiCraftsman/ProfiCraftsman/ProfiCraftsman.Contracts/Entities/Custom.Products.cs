using ProfiCraftsman.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ProfiCraftsman.Contracts.Entities
{
    /// <summary>
    ///  Product
    /// </summary>
    public partial class Products
    {
        public ProductAmountTypes ProductAmountTypes
        {
            get
            {
                return (ProductAmountTypes)ProductAmountType;
            }
        }

        public string ProductAmountTypeString
        {
            get
            {
                var result = String.Empty;

                switch(ProductAmountTypes)
                {
                    case ProductAmountTypes.Item:
                        result = "Stück";
                        break;
                    case ProductAmountTypes.Hour:
                        result = "Stunde";
                        break;
                }

                return result;
            }
        }
    }
}
