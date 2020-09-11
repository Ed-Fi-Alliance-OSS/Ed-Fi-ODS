using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Features.OpenApiMetadata.Strategies.ResourceStrategies;

namespace EdFi.Ods.Features.OpenApiMetadata.Factories
{
    public interface IOpenApiMetadataDocumentFactory
    {
        string Create(IOpenApiMetadataResourceStrategy resourceStrategy,
            OpenApiMetadataDocumentContext openApiMetadataDocumentContext);
    }
}
