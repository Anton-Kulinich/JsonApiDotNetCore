using JetBrains.Annotations;
using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;

namespace JsonApiDotNetCoreTests.IntegrationTests.ResourceInheritance
{
    [UsedImplicitly(ImplicitUseTargetFlags.Members)]
    public abstract class ContentItem : Identifiable<int>
    {
        [Attr]
        public string Title { get; set; } = null!;
    }
}
