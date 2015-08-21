using System;

namespace ProfiCraftsman.API.Controllers
{
    /// <summary>
    ///     CollectionTypesModel class
    /// </summary>
    public partial class CollectionTypesModel
    {
        public bool Materials { get; set;}
        public bool Autos { get; set;}
        public bool Permission { get; set;}
        public bool JobPositions { get; set;}
        public bool Role { get; set;}
        public bool Employees { get; set;}
        public bool TransportProducts { get; set;}
        public bool ProductTypes { get; set;}
        public bool Instruments { get; set;}
    }
}
