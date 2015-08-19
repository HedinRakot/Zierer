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
    public partial class Positions
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
    }
}
