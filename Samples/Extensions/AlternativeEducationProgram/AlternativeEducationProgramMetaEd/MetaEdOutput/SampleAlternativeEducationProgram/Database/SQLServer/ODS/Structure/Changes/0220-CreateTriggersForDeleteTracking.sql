DROP TRIGGER IF EXISTS [samplealternativeeducationprogram].[samplealternativeeducationprogram_AlternativeEducationEligibilityReasonDescriptor_TR_DeleteTracking]
GO

CREATE TRIGGER [samplealternativeeducationprogram].[samplealternativeeducationprogram_AlternativeEducationEligibilityReasonDescriptor_TR_DeleteTracking] ON [samplealternativeeducationprogram].[AlternativeEducationEligibilityReasonDescriptor] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_edfi].[Descriptor](OldDescriptorId, OldCodeValue, OldNamespace, Id, Discriminator, ChangeVersion)
    SELECT  d.AlternativeEducationEligibilityReasonDescriptorId, b.CodeValue, b.Namespace, b.Id, 'samplealternativeeducationprogram.AlternativeEducationEligibilityReasonDescriptor', (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
            INNER JOIN edfi.Descriptor b ON d.AlternativeEducationEligibilityReasonDescriptorId = b.DescriptorId
END
GO

ALTER TABLE [samplealternativeeducationprogram].[AlternativeEducationEligibilityReasonDescriptor] ENABLE TRIGGER [samplealternativeeducationprogram_AlternativeEducationEligibilityReasonDescriptor_TR_DeleteTracking]
GO


