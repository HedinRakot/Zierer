﻿using ProfiCraftsman.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ProfiCraftsman.Contracts.Entities
{
    /// <summary>
    ///  Transport Order
    /// </summary>
    public partial class TransportOrders
    {
        /// <summary>
        /// Customer Name
        /// </summary>
        public string CustomerName
        {
            get
            {
                var result = "";

                if (Customers != null)
                {
                    result = Customers.Name;
                }

                return result;
            }
        }

        /// <summary>
        /// Communication Partner Title
        /// </summary>
        public string CommunicationPartnerTitle
        {
            get
            {
                var result = "";

                if (CommunicationPartners != null)
                {
                    result = CommunicationPartners.Title;
                }

                return result;
            }
        }

        public OrderStatusTypes OrderStatus
        {
            get
            {
                return (OrderStatusTypes)Status;
            }
        }
    }
}
