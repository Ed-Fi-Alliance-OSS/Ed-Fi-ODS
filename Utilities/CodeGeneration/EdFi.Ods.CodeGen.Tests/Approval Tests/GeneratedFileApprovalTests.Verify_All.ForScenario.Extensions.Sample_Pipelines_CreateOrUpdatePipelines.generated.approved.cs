using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Pipelines;
using EdFi.Ods.Pipelines.Factories;

namespace EdFi.Ods.Api.Pipelines.Sample
{
    [ExcludeFromCodeCoverage]
    public class ArtMediumDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.ArtMediumDescriptor.Sample.ArtMediumDescriptor, Entities.NHibernate.ArtMediumDescriptorAggregate.Sample.ArtMediumDescriptor>
    {
        public ArtMediumDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class BusCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.Bus.Sample.Bus, Entities.NHibernate.BusAggregate.Sample.Bus>
    {
        public BusCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class BusRouteCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.BusRoute.Sample.BusRoute, Entities.NHibernate.BusRouteAggregate.Sample.BusRoute>
    {
        public BusRouteCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class FavoriteBookCategoryDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.FavoriteBookCategoryDescriptor.Sample.FavoriteBookCategoryDescriptor, Entities.NHibernate.FavoriteBookCategoryDescriptorAggregate.Sample.FavoriteBookCategoryDescriptor>
    {
        public FavoriteBookCategoryDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class MembershipTypeDescriptorCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.MembershipTypeDescriptor.Sample.MembershipTypeDescriptor, Entities.NHibernate.MembershipTypeDescriptorAggregate.Sample.MembershipTypeDescriptor>
    {
        public MembershipTypeDescriptorCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StudentArtProgramAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.StudentArtProgramAssociation.Sample.StudentArtProgramAssociation, Entities.NHibernate.StudentArtProgramAssociationAggregate.Sample.StudentArtProgramAssociation>
    {
        public StudentArtProgramAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationCreateOrUpdatePipeline : CreateOrUpdatePipeline<Models.Resources.StudentGraduationPlanAssociation.Sample.StudentGraduationPlanAssociation, Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociation>
    {
        public StudentGraduationPlanAssociationCreateOrUpdatePipeline(IPipelineFactory factory) : base(factory) { }
    }

}
