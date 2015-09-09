using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfiCraftsman.Contracts.Enums
{
    public partial class Permissions
    {

        ///<summary>
        /// Grant for view home page
        ///</summary>
        public const int Home = 1000;

        ///<summary>
        /// Grant for view Warehouse Materials
        ///</summary>
        public const int WarehouseMaterials = 1001;

        ///<summary>
        /// Grant for view trips
        ///</summary>
        public const int Trips = 1002;
        
        ///<summary>
        /// Grant for view trips
        ///</summary>
        public const int ReportOrders = 1003;
    }
}
