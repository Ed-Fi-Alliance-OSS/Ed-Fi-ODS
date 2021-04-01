ALTER TABLE samplestudenttransportation.StudentTransportation
ADD ChangeVersion BIGINT DEFAULT nextval('changes.ChangeVersionSequence') NOT NULL;

