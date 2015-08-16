using MetadataLoader.Contracts.CSharp;

namespace ProfiCraftsman.Generation
{
    public static class AttributeDictionary
    {
        public static readonly AttributeUsageInfo Required = new AttributeUsageInfo("Required", null, "CoreBase.Validation");

        public static readonly AttributeUsageInfo DataContract = new AttributeUsageInfo("DataContract", null, "System.Runtime.Serialization");
        public static readonly AttributeUsageInfo DataMember = new AttributeUsageInfo("DataMember", null, "System.Runtime.Serialization");
    }
}