ALTER TABLE samplestudenttranscript.PostSecondaryOrganization
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;

