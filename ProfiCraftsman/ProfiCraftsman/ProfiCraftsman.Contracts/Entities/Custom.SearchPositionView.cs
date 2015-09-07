using ProfiCraftsman.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ProfiCraftsman.Contracts.Entities
{
    /// <summary>
    ///  Position
    /// </summary>
    public partial class SearchPositionView
    {
        public PaymentTypes Payment
        {
            get
            {
                return (PaymentTypes)PaymentType;
            }
        }

        public string PaymentTypeString
        {
            get
            {
                var result = String.Empty;

                switch(Payment)
                {
                    case PaymentTypes.Standard:
                        result = "Standard";
                        break;
                    case PaymentTypes.Total:
                        result = "Pauschal";
                        break;
                }

                return result;
            }
        }

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

                switch (ProductAmountTypes)
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
