CREATE SEQUENCE IF NOT EXISTS changes.ChangeVersionSequence START WITH 1;

CREATE OR REPLACE FUNCTION changes.updateChangeVersion()
    RETURNS trigger AS
$BODY$
BEGIN
    new.ChangeVersion := nextval('changes.ChangeVersionSequence');
    RETURN new;
END;
$BODY$ LANGUAGE plpgsql;
