using CoreBase.Entities;
using CoreBase.SaveActors;
using System.Data.Entity;
using System.Linq;

namespace ProfiCraftsman.Lib.Data
{
    /// <summary>
    ///     ProfiCraftsman Entities
    /// </summary>
    [DbConfigurationType(typeof(ProfiCraftsmanConfiguration))]
    public partial class ProfiCraftsmanEntities: EntitiesBase
    {
        /// <summary>
        /// </summary>
        /// <param name="saveActorManager"></param>
        /// <param name="connectionString"></param>
        public ProfiCraftsmanEntities(ISaveActorManagerBase saveActorManager, string connectionString)
            : base(saveActorManager, connectionString)
        {
        }

        static ProfiCraftsmanEntities()
        {
            Database.SetInitializer<ProfiCraftsmanEntities>(null);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProfiCraftsmanEntities" /> class.
        /// </summary>
        public ProfiCraftsmanEntities(ISaveActorManagerBase saveActorManager)
            : base(saveActorManager, "name=ProfiCraftsmanEntities")
        {
        }


        protected override void RegisterCustomMappings(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(NumbersMapping.Instance);
        }
    }
}